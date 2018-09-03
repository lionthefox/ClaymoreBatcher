using System;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var selectFolder = new SelectFolder();
            Application.Run(selectFolder);
        }
    }
}
