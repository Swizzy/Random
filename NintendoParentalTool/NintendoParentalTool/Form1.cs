namespace NintendoParentalTool {
    using System;
    using System.Windows.Forms;

    internal sealed partial class Form1 : Form {
        internal Form1() {
            InitializeComponent();
        }

        private void GetcodebtnClick(object sender, EventArgs e) {
            var month = datebox.Value.ToString("MM");
            var day = datebox.Value.ToString("dd");
            uint servicecode = 0;
            uint uday;
            uint umonth;
            uint.TryParse(day, out uday);
            uint.TryParse(month, out umonth);
            if((servicecodebox.Text.Length != 8) || !uint.TryParse(servicecodebox.Text, out servicecode))
                MessageBox.Show(@"ERROR: Please check your service code, it should be 8 numbers!", @"ERROR - Bad code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            servicecode %= 10000;
            uday %= 100;
            umonth %= 100;
            var str = string.Format("{0:D02}{1:D02}{2:D04} ", umonth, uday, servicecode);
            var masterkey = CalculateMasterKey(str);
            str = string.Format("{0:MMdd}{1}", datebox.Value, servicecodebox.Text.Substring(4));
            var wiikey = CalculateMasterKeyWii(str);
            var msg = string.Format("Your 3DS Masterkey is: {0:D05}\nYour Wii/DSi Masterkey is: {1:D05}\n\nOriginal 3DS Code by neimod\nOriginal Wii code by Hector Martin Cantero <hector@marcansoft.com>\nPorted to C# along with a GUI by Swizzy", masterkey, wiikey);
            MessageBox.Show(msg);
        }

        private static uint CalculateMasterKey(string generator) {
            var table = new uint[0x100];
            for(UInt32 i = 0; i < 0x100; i++) {
                var data = i;
                for(var j = 0; j < 4; j++) {
                    if((data & 1) != 0)
                        data = 0xEDBA6320 ^ (data >> 1);
                    else
                        data = data >> 1;
                    if((data & 1) != 0)
                        data = 0xEDBA6320 ^ (data >> 1);
                    else
                        data = data >> 1;
                }
                table[i] = data;
            }

            var y = 0xFFFFFFFF;
            var x = generator[0];
            for(var i = 0; i < 4; i++) {
                x = (char) (x ^ y);
                x = (char) (x & 0xFF);
                y = table[x] ^ (y >> 8);
                x = (char) (generator[1 + i * 2] ^ y);
                x = (char) (x & 0xFF);
                y = table[x] ^ (y >> 8);
                x = generator[2 + i * 2];
            }

            y ^= 0xAAAA;
            y += 0x1657;

            ulong yll = y;
            yll = (yll + 1) * 0xA7C5AC47;
            var yhi = (uint) (yll >> 48);
            yhi *= 0xFFFFF3CB;
            y += (yhi << 5);
            return y;
        }

        private static uint CalculateMasterKeyWii(string generator) {
            var table = new uint[0x100];
            uint i;
            for(i = 0; i < 0x100; i++) {
                var data = i;
                for(var j = 0; j < 4; j++) {
                    if((data & 1) != 0)
                        data = 0xEDB88320 ^ (data >> 1);
                    else
                        data = data >> 1;
                    if((data & 1) != 0)
                        data = 0xEDB88320 ^ (data >> 1);
                    else
                        data = data >> 1;
                }
                table[i] = data;
            }

            var count = generator.Length;
            var crc = 0xffffffff;
            var tmp = 0;
            while(count != 0) {
                count -= 1;
                var tmp1 = (crc >> 8) & 0xFFFFFF;
                var tmp2 = table[(crc ^ generator[tmp]) & 0xFF];
                crc = tmp1 ^ tmp2;
                tmp++;
            }
            crc = ((crc ^ 0xaaaa) + 0x14C1) % 100000;
            return crc;
        }

        private void ServicecodeboxKeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}