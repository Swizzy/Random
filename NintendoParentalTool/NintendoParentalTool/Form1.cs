namespace NintendoParentalTool {
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    internal sealed partial class Form1 : Form {
        internal Form1() {
            InitializeComponent();
            var ver = Assembly.GetAssembly(typeof(Form1)).GetName().Version;
            var name = Assembly.GetAssembly(typeof(Form1)).GetName().Name + string.Format(" v{0}.{1}", ver.Major, ver.Minor);
            Text = name;
            outputbox.Text = string.Format("{1} Started!{0}The important data is:{0}- Servicecode (Inquiry Number){0}- Date (Day and Month) on the console{0}Set the date, type in your code and press the button...", Environment.NewLine, name);
        }

        private void GetcodebtnClick(object sender, EventArgs e) {
            var month = datebox.Value.ToString("MM");
            var day = datebox.Value.ToString("dd");
            uint servicecode;
            uint uday;
            uint umonth;
            uint.TryParse(day, out uday);
            uint.TryParse(month, out umonth);
            if (servicecodebox.Text.Length != 8 || !uint.TryParse(servicecodebox.Text, out servicecode)) {
                MessageBox.Show(@"ERROR: Please check your service code, it should be 8 numbers!", @"ERROR - Bad code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var str = string.Format("{0:D02}{1:D02}{2:D04} ", umonth % 100, uday % 100, servicecode % 10000);
            var masterkey = CalculateMasterKey(str);
            str = string.Format("{0:MMdd}{1}", datebox.Value, servicecodebox.Text.Substring(4));
            var wiikey = CalculateMasterKeyWii(str);
            outputbox.Text = string.Format("Your 3DS Masterkey is: {0:D05}\nYour Wii/DSi Masterkey is: {1:D05}\n\nOriginal 3DS Code by neimod\nOriginal Wii/DSi code by Hector Martin Cantero <hector@marcansoft.com>\nPorted to C# along with a GUI by Swizzy", masterkey, wiikey);
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

        private void ServicecodeboxTextChanged(object sender, EventArgs e) {
            if(servicecodebox.Text.Contains(" ")) {
                servicecodebox.Text = servicecodebox.Text.Replace(" ", "").Trim();
                if(servicecodebox.TextLength > 8)
                    servicecodebox.Text = servicecodebox.Text.Substring(0, 8);
                servicecodebox.Select(servicecodebox.TextLength, 0);
            }
            else if(servicecodebox.TextLength > 8) {
                servicecodebox.Text = servicecodebox.Text.Substring(0, 8);
                servicecodebox.Select(servicecodebox.TextLength, 0);
            }
        }
    }
}