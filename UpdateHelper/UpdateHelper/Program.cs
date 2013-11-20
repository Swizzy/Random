namespace UpdateHelper {
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    internal static class Program {
        private static void Main(string[] args) {
            try {
                Thread.Sleep(1000);
                if(args.Length != 3)
                    Usage();
                if(!IsNumeric(args[0]))
                    KillApp(args[0]);
                else
                    KillApp(int.Parse(args[0]));
                if(!File.Exists(args[1]))
                    Usage();
                else if(File.Exists(args[2]))
                    File.Delete(args[2]);
                File.Move(args[1], args[2]);
                Process.Start(args[2]);
                DieAndRemove();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void Usage() {
            MessageBox.Show(string.Format("Usage: {0} [ProcessName/PID] [New Executable Path] [Old Executable Path]", Path.GetFileName(Application.ExecutablePath)), "Bad arguments to Swizzy's Update helper!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DieAndRemove();
        }

        private static bool IsNumeric(string input) {
            int val;
            return int.TryParse(input, out val);
        }

        private static void KillApp(string appname) {
            try {
                var procs = Process.GetProcessesByName(appname);
                if(procs.Length <= 0)
                    return;
                foreach(var process in procs) {
                    if(process.HasExited)
                        continue;
                    process.Kill();
                    process.WaitForExit();
                }
                KillApp(appname);
            }
            catch(Exception) {
            }
        }

        private static void KillApp(int id) {
            try {
                var proc = Process.GetProcessById(id);
                if(proc.HasExited)
                    return;
                proc.Kill();
                proc.WaitForExit();
            }
            catch(Exception) {
            }
        }

        private static void DieAndRemove() {
            var proc = new ProcessStartInfo {
                                            FileName = "cmd.exe", Arguments = string.Format("/C ping localhost -n 1 -w 5000 > Nul & Del \"{0}\"", Application.ExecutablePath), CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden
                                            };
            Process.Start(proc);
            if(Application.MessageLoop)
                Application.Exit();
            Environment.Exit(0);
        }
    }
}