namespace PS3Patcher {
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    internal static class Program {
        private const int NANDLength = 0x10000000;
        private const int NANDPatchOffset1 = 0x91800;
        private const int NANDPatchOffset2 = 0xc0030;
        private const int NANDPatchOffset3 = 0x7c0020;
        private const int NORLength = 0x1000000;
        private const int NORPatchOffset1 = 0x40000;
        private const int NORPatchOffset2 = 0xc0010;
        private const int NORPatchOffset3 = 0x7c0010;

        private static void ApplyPatch(int patchnum, int totalpatch, int offset, byte[] patchdata, ref BinaryWriter target) {
            Console.WriteLine("Applying patch {0} of {1}", patchnum, totalpatch);
            target.Seek(offset, SeekOrigin.Begin);
            target.Write(patchdata);
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)] private static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] FileAttributes flags, IntPtr template);

        private static void DisplayUsage() {
            var fileName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("Usage:");
            Console.WriteLine("{0} <source>", fileName);
            Console.WriteLine();
            Console.WriteLine("  source       Specifies the NOR/NAND dump to be patched");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(@" {0} d:\myflash.bin", fileName);
        }

        private static byte[] GetPatchData(string name, [Optional] [DefaultParameterValue(false)] bool swap) {
            BinaryReader reader = null;
            Stream input = null;
            byte[] buffer2;
            try {
                input = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("{0}.{1}", typeof(Program).Namespace, name));
                if(input == null)
                    throw new InvalidOperationException(string.Format("No internal {0} found!", name));
                reader = new BinaryReader(input);
                var data = reader.ReadBytes((int) input.Length);
                if(swap)
                    SwapBytes(ref data);
                buffer2 = data;
            }
            finally {
                if(reader != null)
                    reader.Close();
                if(input != null)
                    input.Close();
            }
            return buffer2;
        }

        private static bool IsFileInUse(string file) {
            SafeFileHandle handle = null;
            try {
                handle = CreateFile(file, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
                if(handle.IsInvalid && (Marshal.GetLastWin32Error() == 0x20))
                    return true;
            }
            finally {
                if(handle != null)
                    handle.Close();
            }
            return false;
        }

        private static void Main(string[] args) {
            BinaryReader src = null;
            BinaryWriter target = null;
            try {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                Console.WriteLine("PS3 Patcher v{0}.{1} By Swizzy [swizzy@xeupd.com] Based on norpatch by Judges [judges@eEcho.com]", version.Major, version.Minor);
                Console.WriteLine();
                if((args.Length == 0) || (args.Length > 1))
                    DisplayUsage();
                else if(!File.Exists(args[0]))
                    Console.WriteLine("Flash dump file \"{0}\" not found!", args[0]);
                else {
                    src = OpenReader(args[0]);
                    if((src == null) || ((src.BaseStream.Length != 0x1000000L) && (src.BaseStream.Length != 0x10000000L))) {
                        if(src == null)
                            throw new NullReferenceException("srcStream is null!");
                        Console.WriteLine("File \"{0}\" has an incorrect size!", args[0]);
                        Console.WriteLine("Expected: {0:d} bytes (NOR) or {1:d} bytes (NAND)", 0x1000000, 0x10000000);
                        Console.WriteLine("Got:      {0:d} bytes", src.BaseStream.Length);
                    }
                    else {
                        byte[] patchData;
                        var destFileName = string.Format(@"{0}\{1}_patched{2}", Path.GetDirectoryName(args[0]), Path.GetFileNameWithoutExtension(args[0]), Path.GetExtension(args[0]));
                        File.Copy(args[0], destFileName, true);
                        target = OpenWriter(destFileName);
                        switch(src.BaseStream.Length) {
                            case 0x1000000L: {
                                var swap = NeedsByteSwapping(ref src);
                                patchData = GetPatchData("patch1_nor.bin", swap);
                                ApplyPatch(1, 3, 0x40000, patchData, ref target);
                                patchData = GetPatchData("patch2.bin", swap);
                                ApplyPatch(2, 3, 0xc0010, patchData, ref target);
                                ApplyPatch(3, 3, 0x7c0010, patchData, ref target);
                                Console.WriteLine("All patches have been applied to {0}", destFileName);
                                return;
                            }
                            case 0x10000000L:
                                patchData = GetPatchData("patch1_nand.bin");
                                ApplyPatch(1, 3, 0x91800, patchData, ref target);
                                patchData = GetPatchData("patch2.bin");
                                ApplyPatch(2, 3, 0xc0030, patchData, ref target);
                                ApplyPatch(3, 3, 0x7c0020, patchData, ref target);
                                Console.WriteLine("All patches have been applied to {0}", destFileName);
                                return;
                        }
                        Console.WriteLine("Patch failed!");
                    }
                }
            }
            catch(Exception exception) {
                Console.Write(exception.Message);
            }
            finally {
                if(src != null)
                    src.Close();
                if(target != null)
                    target.Close();
                Console.WriteLine();
                Console.Write("Press any key to exit...");
                Console.ReadKey(true);
            }
        }

        private static bool NeedsByteSwapping(ref BinaryReader src) {
            src.BaseStream.Seek(0x200L, SeekOrigin.Begin);
            var buffer = src.ReadBytes(4);
            if(((buffer[0] == 0x49) && (buffer[1] == 70)) && ((buffer[2] == 0x49) && (buffer[3] == 0)))
                return false;
            if(((buffer[0] != 70) || (buffer[1] != 0x49)) || ((buffer[2] != 0) || (buffer[3] != 0x49)))
                throw new InvalidDataException();
            return true;
        }

        private static bool OpenError(string msg) {
            Console.WriteLine(msg);
            return (Console.Read() == 0x79);
        }

        private static BinaryReader OpenReader(string filename) {
            try {
                return new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            catch(IOException) {
                if(IsFileInUse(filename) && OpenError(string.Format("Can't Open\r\n{0}\r\nFor reading, this often means that it's open in another program...\r\nDo you want to try again?", filename)))
                    return OpenReader(filename);
                return null;
            }
        }

        private static BinaryWriter OpenWriter(string filename) {
            try {
                return new BinaryWriter(new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
            }
            catch(IOException) {
                if(IsFileInUse(filename) && OpenError(string.Format("Can't Open\r\n{0}\r\nFor writing, this often means that it's open in another program...\r\nDo you want to try again?", filename)))
                    return OpenWriter(filename);
                return null;
            }
        }

        private static void SwapBytes(ref byte[] data) {
            if((data.Length % 2) != 0)
                throw new InvalidOperationException("Data must be dividable by 2!");
            for(var i = 0; i < data.Length; i += 2) {
                var num2 = data[i];
                data[i] = data[i + 1];
                data[i + 1] = num2;
            }
            GC.Collect();
        }
    }
}