namespace ResxEditor
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
#if (WIN32)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
#elif (mono)
			MainMonoForm m = new MainMonoForm();
			m.Show();

#endif
        }
    }
}