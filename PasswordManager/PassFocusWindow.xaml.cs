using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for PassFocusWindow.xaml
    /// </summary>
    public partial class PassFocusWindow : Window
    {
        public PassFocusWindow(Site site)
        {
            InitializeComponent();
            textBox00.Text = site.Name;
            textBox01.Text = site.URL;
            textBox10.Text = site.Username;
            textBox11.Text = site.Password;
        }
    }
 
}
