using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PS.Auto.Repos;

namespace PS.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            RepositoryInitializer.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
