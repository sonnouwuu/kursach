using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace virus1
{
    /// <summary>
    /// Логика взаимодействия для PageWindow.xaml
    /// </summary>
    public partial class PageWindow : Window
    {
        public PageWindow(string url)
        {
            InitializeComponent();
            webView.Source = new Uri(url);
        }

          private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
