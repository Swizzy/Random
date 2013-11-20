using System;
using System.Windows.Forms;

namespace CBExtractor
{
    static class MainClass
    {
        private static CBExtractor _form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form = new CBExtractor();
            Application.Run(_form);
        }

        internal static void SetStatus(string input) {
                _form.status.Text = input;
        }
    }
}
