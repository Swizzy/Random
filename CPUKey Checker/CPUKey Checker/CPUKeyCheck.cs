using System;

namespace CPUKey_Checker
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;

    static class CPUKeyCheck
    {
        private static CPUKeyCheckErrors _lastError;

        private static bool CompareByteArrays(IList<byte> a1, IList<byte> a2)
        {
            if (a1 == a2)
                return true;
            if (a1 == null || a2 == null || a1.Count != a2.Count)
                return false;
            for (var i = 0; i < a1.Count; i++)
                if (a1[i] != a2[i])
                    return false;
            return true;
        }

        private enum CPUKeyCheckErrors {
            Success,
            TooShort,
            TooLong,
            BadKeyData1,
            BadKeyData2,
            BadHamming,
            BadECD,
            Unkown = int.MaxValue
        }

        internal static string GetLastError() {
            switch (_lastError) {
                case CPUKeyCheckErrors.Success:
                    return "No Error";
                case CPUKeyCheckErrors.TooShort:
                    return "Key is too short!";
                case CPUKeyCheckErrors.TooLong:
                    return "Key is too long!";
                case CPUKeyCheckErrors.BadKeyData1:
                case CPUKeyCheckErrors.BadKeyData2:
                    return "Key contains invalid characters!";
                case CPUKeyCheckErrors.BadHamming:
                    return "Key don't have 53 bits set (for the UUID part)!";
                case CPUKeyCheckErrors.BadECD:
                    return "Key ECD doesn't match";
                default:
                    return "Undefined error";
            }
        }

        static uint CountBits(UInt64 n) {
            uint c;
            for (c = 0; n > 0; c++) 
                n &= n - 1;
            return c;
        }

        static bool CalcCPUKeyECD(ref byte[] key) {
            if (key.Length != 0x10)
                return false;
            uint acc1 = 0, acc2 = 0;
            for (int cnt = 0; cnt < 0x80; cnt++, acc1 >>=1) {
                var bTmp = key[cnt>>3];
                var dwTmp = (uint) ((bTmp >> (cnt & 7)) & 1);
                if (cnt < 0x6A) {
                    acc1 = dwTmp ^ acc1;
                    if ((acc1 & 1) > 0)
                        acc1 = acc1 ^ 0x360325;
                    acc2 = dwTmp^acc2;
                }
                else if (cnt < 0x7F) {
                    if (dwTmp != (acc1 & 1))
                        key[(cnt >> 3)] = (byte) ((1 << (cnt & 7)) ^ (bTmp & 0xFF));
                    acc2 = (acc1 & 1)^acc2;
                }
                else if (dwTmp != acc2) 
                    key[0xF] = (byte) ((0x80 ^ bTmp) & 0xFF);
            }
            return true;
        }

        private static byte[] Keytoarray(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;
            var ret = new byte[key.Length / 2];
            for (var i = 0; i < key.Length; i += 2)
                ret[i / 2] = byte.Parse(key.Substring(i, 2), NumberStyles.HexNumber);
            return ret;
        }

        internal static bool VerifyKey(string key) {
            _lastError = CPUKeyCheckErrors.Success;
            if (key.Length < 32) {
                _lastError = CPUKeyCheckErrors.TooShort;
                return false;
            }
            if (key.Length > 32) {
                _lastError = CPUKeyCheckErrors.TooLong;
                return false;
            }
            UInt64 tmp1, tmp2;
            if (!UInt64.TryParse(key.Substring(0, 16), NumberStyles.AllowHexSpecifier, null, out tmp1)) {
                _lastError = CPUKeyCheckErrors.BadKeyData1;
                return false;
            }
            if (!UInt64.TryParse(key.Substring(16), NumberStyles.AllowHexSpecifier, null, out tmp2)) {
                _lastError = CPUKeyCheckErrors.BadKeyData2;
                return false;
            }
            var hamming = CountBits(tmp1);
            hamming += CountBits(tmp2 & 0xFFFFFFFFFF030000);
            if (hamming != 53) {
                _lastError = CPUKeyCheckErrors.BadHamming;
                return false;
            }
            var keydata = Keytoarray(key);
            var keytmp = new byte[keydata.Length];
            Buffer.BlockCopy(keydata, 0, keytmp, 0, keydata.Length);
            if (!CalcCPUKeyECD(ref keytmp))
            {
                _lastError = CPUKeyCheckErrors.Unkown;
                return false;
            }
            if (!CompareByteArrays(keydata, keytmp)) {
                _lastError = CPUKeyCheckErrors.BadECD;
                return false;
            }
            return true;
        }

        private static bool Readfusefile(string file, out string cpukey)
        {
            cpukey = "";
            var val = "";
            UInt64 key1 = 0, key2 = 0, key3 = 0, key4 = 0;
            using (var sr = new StreamReader(file))
            {
                while (val != null)
                {
                    val = sr.ReadLine();
                    if (string.IsNullOrEmpty(val))
                        continue;
                    if (val.StartsWith("fuseset 03:", StringComparison.CurrentCultureIgnoreCase))
                        UInt64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key1);
                    else if (val.StartsWith("fuseset 04:", StringComparison.CurrentCultureIgnoreCase))
                        UInt64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key2);
                    else if (val.StartsWith("fuseset 05:", StringComparison.CurrentCultureIgnoreCase))
                        UInt64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key3);
                    else if (val.StartsWith("fuseset 06:", StringComparison.CurrentCultureIgnoreCase))
                        UInt64.TryParse(val.Remove(0, 11), NumberStyles.HexNumber, null, out key4);
                }
                sr.Close();
            }
            if (key1 == 0 || key2 == 0 || key3 == 0 || key4 == 0)
                return false;
            cpukey = (key1 | key2).ToString("X16") + (key3 | key4).ToString("X16");
            return true;
        }

        private static bool IsHexString(string input)
        {
            return Regex.IsMatch(input, "^[0-9A-Fa-f]+$");
        }

        private static bool IsValidKey(string key)
        {
            if (key != null) {
                key = key.Trim();
                if (key.Length == 0x20) {
                    if (IsHexString(key))
                        return true;
                }
            }
            return false;
        }

        private static bool Readkeyfile(string file, out string cpukey)
        {
            cpukey = "";
            using (var sr = new StreamReader(file))
            {
                var key = sr.ReadLine();
                if (key != null && ((key.Trim().IndexOf("cpukey", StringComparison.CurrentCultureIgnoreCase) >= 0) && (key.Trim().Length == 38)))
                    key = key.Trim().Substring(key.Trim().Length - 32, 32);
                if (string.IsNullOrEmpty(key) || !IsValidKey(key))
                    return false;
                cpukey = key.Trim().ToUpper();
                return true;
            }
        }

        internal static bool GetCPUKeyFromFile(string file, out string key)
        {
            key = "";
            if (IsNAND(file))
                return false;
            return Readkeyfile(file, out key) || Readfusefile(file, out key);
        }

        private static bool IsNAND(string file) {
            if (!File.Exists(file))
                return true;
            var br = new BinaryReader(File.OpenRead(file));
            if (br.BaseStream.Length < 2048 && br.BaseStream.Length > 2)
            {
                var tmp = br.ReadBytes(2);
                br.Close();
                return (CompareByteArrays(tmp,
                                          new byte[] {
                                                         0xFF, 0x4F
                                                     }));
            }
            br.Close();
            return true;
        }

    }
}
