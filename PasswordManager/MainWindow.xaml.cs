using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LumenWorks.Framework.IO.Csv;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PassStore passes = new PassStore();
        public MainWindow()
        {
            InitializeComponent();
            passes.LoadSites();
            lbPassList.ItemsSource = passes.GetSites();
        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            AesTest aesTest = new AesTest();
            aesTest.Show();
        }
        private void lbPassList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PassFocusWindow pfwin = new PassFocusWindow((lbPassList.SelectedItem as Site));
            pfwin.Show();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            passes.Save();
        }
    }
}
