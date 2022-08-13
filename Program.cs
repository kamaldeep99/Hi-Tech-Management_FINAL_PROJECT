﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hi_Tech_Management_FINAL_PROJECT.GUI;

namespace Hi_Tech_Management_FINAL_PROJECT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUserManagement());
           // Application.Run(new FormEmployeeManagement());
        }
    }
}
