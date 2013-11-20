namespace x360_Account_Editor {
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    internal sealed class Crypto {
        private static bool Memcmp(ref byte[] data1, ref byte[] data2, int length) {
            for(var i = 0; i < length; i++) {
                if(data1[i] != data2[i])
                    return false;
            }
            return true;
        }

        public static byte[] Decrypt(byte[] indata, byte[] inkey) {
            var data = new byte[indata.Length];
            Array.Copy(indata, data, indata.Length);
            var key = new byte[inkey.Length];
            Array.Copy(inkey, key, inkey.Length);
            var newkey = new HMACSHA1(key).ComputeHash(data, 0, 0x10);
            Array.Resize(ref newkey, 0x10);
            var session = RC4CreateSession(newkey);
            RC4DoCrypt(ref session, data, 0x10, 8);
            RC4DoCrypt(ref session, data, 0x18, data.Length - 0x18);
            var test = new HMACSHA1(key).ComputeHash(data, 0x10, data.Length - 0x10);
            if(Memcmp(ref data, ref test, 0x10)) {
                var ret = new byte[data.Length - 0x18];
                Array.Copy(data, 0x18, ret, 0, ret.Length);
                return ret;
            }
            return new byte[0];
        }

        public static byte[] Encrypt(byte[] indata, byte[] inkey) {
            var data = new byte[indata.Length + 0x18];
            Array.Copy(indata, 0, data, 0x18, indata.Length);
            var key = new byte[inkey.Length];
            Array.Copy(inkey, key, inkey.Length);
            for(var i = 0x10; i < 0x18; i++)
                data[i] = (byte) Main.Random.Next(0, 0x100);
            var srckey = new HMACSHA1(key).ComputeHash(data, 0x10, data.Length - 0x10);
            Array.Copy(srckey, data, 0x10);
            var newkey = new HMACSHA1(key).ComputeHash(srckey, 0, 0x10);
            Array.Resize(ref newkey, 0x10);
            var session = RC4CreateSession(newkey);
            RC4DoCrypt(ref session, data, 0x10, data.Length - 0x10);
            return data;
        }

        #region Keys

        public readonly byte[] Devkey = new byte[] { 0xda, 0xb6, 0x9a, 0xd9, 0x8e, 40, 0x76, 0x4f, 0x97, 0x7e, 0xe2, 0x48, 0x7e, 0x4f, 0x3f, 0x68 };
        public readonly byte[] Retailkey = new byte[] { 0xe1, 0xbc, 0x15, 0x9c, 0x73, 0xb1, 0xea, 0xe9, 0xab, 0x31, 0x70, 0xf3, 0xad, 0x47, 0xeb, 0xf3 };

        #endregion

        #region RC4

        private static RC4Session RC4CreateSession(byte[] key) {
            var session = new RC4Session { key = key, i = 0, j = 0, s_boxLen = 0x100 };
            session.s_box = new byte[session.s_boxLen];
            for(var i = 0; i < session.s_boxLen; i++)
                session.s_box[i] = (byte) i;
            var index = 0;
            for(var j = 0; j < session.s_boxLen; j++) {
                index = ((index + session.s_box[j]) + key[j % key.Length]) % session.s_boxLen;
                var num4 = session.s_box[index];
                session.s_box[index] = session.s_box[j];
                session.s_box[j] = num4;
            }
            return session;
        }

        private static void RC4DoCrypt(ref RC4Session session, IList<byte> data, int index, int count) {
            var internalIndex = index;
            do {
                session.i = (session.i + 1) % 0x100;
                session.j = (session.j + session.s_box[session.i]) % 0x100;
                var num2 = session.s_box[session.i];
                session.s_box[session.i] = session.s_box[session.j];
                session.s_box[session.j] = num2;
                var num3 = data[internalIndex];
                var num4 = session.s_box[(session.s_box[session.i] + session.s_box[session.j]) % 0x100];
                data[internalIndex] = (byte) (num3 ^ num4);
                internalIndex++;
            }
            while(internalIndex != (index + count));
        }

        [StructLayout(LayoutKind.Sequential)] private struct RC4Session {
            public byte[] key;
            public int s_boxLen;
            public byte[] s_box;
            public int i;
            public int j;
        }

        #endregion
    }
}