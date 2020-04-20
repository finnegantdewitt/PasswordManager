using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Create the Startup Window
            MainWindow wnd = new MainWindow();
            wnd.Title = "Password Manager";
            if (e.Args.Length == 1)
                MessageBox.Show("Now Opening file: \n\n" + e.Args[0]);
            wnd.Show();
        }
    }
}
