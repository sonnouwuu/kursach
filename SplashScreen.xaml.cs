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
using System.Windows.Shapes;

namespace virus1
{
    
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            StartLoading();
        }

        private async void StartLoading()
        {
            for (int i = 0; i <= 100; i += 5)
            {
                LoadingBar.Value = i;
                await Task.Delay(100); // Задержка для эффекта загрузки
            }

            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Закрываем заставку
        }
    }
}

