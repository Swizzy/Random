using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace x360_Account_Editor
{
    public partial class Form1 : Form
    {
        private void hexinput(object sender, KeyPressEventArgs e) { if (e.KeyChar != '\b') e.Handled = !Uri.IsHexDigit(e.KeyChar); }
        private static byte[] data;
        private static Random random = new Random();
        public Form1() { InitializeComponent(); }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { Close(); }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                status.Text = "Loading account file into memory...";
                data = File.ReadAllBytes(openFileDialog1.FileName);
                getcurrent.Enabled = true;
                copycurrent.Enabled = false;
                if ((data[0] != 0x00) && (data[0] != 0x20)) { functions.Enabled = false; }
                else { functions.Enabled = true; }
                status.Text = "Account file loaded!";
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                status.Text = "Saving new account file...";
                File.WriteAllBytes(saveFileDialog1.FileName, data);
                status.Text = "Account file saved to: " + saveFileDialog1.FileName;
            } 
        }
        private void getcurrent_Click(object sender, EventArgs e)
        {
            status.Text = "Getting current account information...";
            currtype.Text = "";
            currname.Text = "";
            currxuid.Text = "";
            copycurrent.Enabled = false;
            if ((data[0] != 0x00) && (data[0] != 0x20)) 
            {
                functions.Enabled = false;
                MessageBox.Show("ERROR: Your account is etheir corrupt or not decrypted, decrypt it first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else
            {
                if (data[0] == 0x00) { currtype.Text = "Offline"; }
                else if (data[0] == 0x20) { currtype.Text = "Online"; }
                byte[] tmp = new byte[0x10];
                Array.Copy(data, 0x9, tmp, 0x0, 0x10);
                currname.Text = Encoding.Unicode.GetString(tmp);
                for (int i = 0x28; i < 0x30; i++) { currxuid.Text += data[i].ToString("X2"); }
                functions.Enabled = true;
                copycurrent.Enabled = true;
            }
            status.Text = "Getting current account information Done! Waiting for further instructions...";
        }
        private void newxuid_TextChanged(object sender, EventArgs e)
        {
            if (newxuid.Text.Length == 4) 
            {
                if (newxuid.Text.Substring(0, 4) != "0009") 
                {
                    modxuid.Enabled = false;
                    MessageBox.Show("ERROR: Your XUID must start with \"0009\" to be valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else if (newxuid.Text.Length == 16)
            {
                if (newxuid.Text.Substring(0, 4) != "0009") 
                {
                    MessageBox.Show("ERROR: Your XUID must start with \"0009\" to be valid!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modxuid.Enabled = false;
                }
                else { modxuid.Enabled = true; }
            }
            else { modxuid.Enabled = false; }
        }
        private void copycurrent_Click(object sender, EventArgs e)
        {
            newname.Text = currname.Text;
            newxuid.Text = currxuid.Text;
        }
        private void makeonline_Click(object sender, EventArgs e)
        {
            status.Text = "Patching account as online...";
            data[0] = 0x20;
            data[0x30] = 0x06;
            data[0x31] = 0x60;
            data[0x32] = 0x18;
            data[0x33] = 0x6C;
            data[0x34] = 0x50;
            data[0x35] = 0x52;
            data[0x36] = 0x4F;
            data[0x37] = 0x44;
            data[0x3C] = 0x78;
            data[0x3D] = 0x62;
            data[0x3E] = 0x6F;
            data[0x3F] = 0x78;
            data[0x40] = 0x2E;
            data[0x41] = 0x63;
            data[0x42] = 0x6F;
            data[0x43] = 0x6D;
            data[0x50] = 0x50;
            data[0x51] = 0x41;
            data[0x52] = 0x53;
            data[0x53] = 0x53;
            data[0x54] = 0x50;
            data[0x55] = 0x4F;
            data[0x56] = 0x52;
            data[0x57] = 0x54;
            data[0x58] = 0x2E;
            data[0x59] = 0x4E;
            data[0x5A] = 0x45;
            data[0x5B] = 0x54;
            for (int i = 0x68; i < 0x78; i++) { data[i] = 0xFF; }
            bool newidgood = false;
            if (!string.IsNullOrEmpty(newxuid.Text)) { if (newxuid.Text.Length == 16) { if (newxuid.Text.Substring(0, 4) == "0009") { newidgood = true; } } }
            if ((data[0x29] != 0x09) && (!newidgood))
            {
                data[0x28] = 0x00;
                data[0x29] = 0x09;
                byte[] tmp = new byte[0x6];
                random.NextBytes(tmp);
                data[0x2A] = tmp[0x00];
                data[0x2B] = tmp[0x01];
                data[0x2C] = tmp[0x02];
                data[0x2D] = tmp[0x03];
                data[0x2E] = tmp[0x04];
                data[0x2F] = tmp[0x05];
                string newid = "";
                for (int i = 0x28; i < 0x30; i++) { newid += data[i].ToString("X2"); }
                MessageBox.Show("Auto-Generated a new XUID for you, the new ID is: " + newid, "New ID Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((data[0x29] != 0x09)) { modxuid_Click(null, null); }
            saveToolStripMenuItem.Enabled = true;
            status.Text = "Done patching account as online!, waiting for further instructions...";
        }
        private void makeoffline_Click(object sender, EventArgs e)
        {
            status.Text = "Patching account as offline...";
            data[0] = 0x00;
            data[0x30] = 0x00;
            data[0x31] = 0x00;
            data[0x32] = 0x00;
            data[0x33] = 0x00;
            data[0x34] = 0x00;
            data[0x35] = 0x00;
            data[0x36] = 0x00;
            data[0x37] = 0x00;
            data[0x3C] = 0x00;
            data[0x3D] = 0x00;
            data[0x3E] = 0x00;
            data[0x3F] = 0x00;
            data[0x40] = 0x00;
            data[0x41] = 0x00;
            data[0x42] = 0x00;
            data[0x43] = 0x00;
            data[0x50] = 0x00;
            data[0x51] = 0x00;
            data[0x52] = 0x00;
            data[0x53] = 0x00;
            data[0x54] = 0x00;
            data[0x55] = 0x00;
            data[0x56] = 0x00;
            data[0x57] = 0x00;
            data[0x58] = 0x00;
            data[0x59] = 0x00;
            data[0x5A] = 0x00;
            data[0x5B] = 0x00;
            for (int i = 0x68; i < 0x78; i++) { data[i] = 0x00; }
            for (int i = 0x28; i < 0x30; i++) { data[i] = 0x00; }
            saveToolStripMenuItem.Enabled = true;
            status.Text = "Done patching account as offline!, waiting for further instructions...";
        }
        private void newname_TextChanged(object sender, EventArgs e) { modname.Enabled = (newname.Text.Length > 0); }
        private void modxuid_Click(object sender, EventArgs e)
        {
            bool newidgood = false;
            if (!string.IsNullOrEmpty(newxuid.Text)) { if (newxuid.Text.Length == 16) { if (newxuid.Text.Substring(0, 4) == "0009") { newidgood = true; } } }
            if (newidgood)
            {
                status.Text = "Patching XUID...";
                byte[] tmp = new byte[0x8];
                string tmps = "";
                int j = 0;
                foreach (char c in newxuid.Text)
                {
                    if (tmps.Length != 1) { tmps = c.ToString(); }
                    else
                    {
                        tmps += c;
                        tmp[j] = byte.Parse(tmps, NumberStyles.HexNumber);
                    }
                }
                j = 0;
                for (int i = 0x28; i < 0x30; i++)
                {
                    data[i] = tmp[j];
                    j++;
                }
                saveToolStripMenuItem.Enabled = true;
                status.Text = "Patching XUID Done!";
            }
        }
        private void genxuid_Click(object sender, EventArgs e)
        {
            status.Text = "Generating new XUID...";
            byte[] tmp = new byte[0x6];
            random.NextBytes(tmp);
            newxuid.Text = "0009";
            foreach (byte b in tmp) { newxuid.Text += b.ToString("X2"); }
            status.Text = "New XUID successfully generated!";
        }
        private void modname_Click(object sender, EventArgs e)
        {
            status.Text = "Pathching account name...";
            byte[] tmp = Encoding.Unicode.GetBytes(newname.Text);
            Array.Resize(ref tmp, 0x10);
            Array.Copy(tmp, 0x0, data, 0x9, 0x10);
            saveToolStripMenuItem.Enabled = true;
            status.Text = "Patching of account name done! Waiting for further instructions...";
        }
    }
}