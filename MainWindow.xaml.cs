using System;
using System.Collections.Generic;
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




namespace virus1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Obych_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            this.Close();
          
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestWindow testWindow = new TestWindow();
            testWindow.Show();
            this.Close();
        }

        private void Sovet_Click(object sender, RoutedEventArgs e)
        {
            SovetWindow sovetWindow = new SovetWindow();
            sovetWindow.Show();
            this.Close();

        }

        private void Analiz_Click(object sender, RoutedEventArgs e)
        {
            Analiz analizWindow = new Analiz();
            analizWindow.Show();
            this.Close();

        }

        private void Simul_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();

        }

        private void Vexod_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрытие текущего окна
        }
    }
}

