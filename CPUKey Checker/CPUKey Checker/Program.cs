using System;
using System.Windows.Forms;

namespace CPUKey_Checker
{
    static class Program
    {
        static bool _doResize = true;
        internal static Form1 Form;
        private delegate void SetText(string text);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            _doResize = args.Length != 0;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form = new Form1();
            Application.Run(Form);
        }

        internal static void SetStatus(string input)
        {
            if (Form.InvokeRequired)
            {
                SetText setTextDel = SetStatus;
                Form.Invoke(setTextDel, new object[] { input });
                return;
            }
            if (_doResize)
                Form.SetStatus(input);
            else
                Form.status.Text = input;
        }

        internal static void SetKey(string key) {
            if (Form.InvokeRequired) {
                SetText setTextDel = SetKey;
                Form.Invoke(setTextDel, new object[] { key });
                return;
            }
            Form.keybox.Text = key;
        }
    }
}
