
using Microsoft.Win32; 
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace virus1 
{
    // Определение класса Analiz, который представляет окно анализа файлов
    public partial class Analiz : Window
    {
        // Конструктор окна Analiz, вызывающий метод инициализации компонентов
        public Analiz()
        {
            InitializeComponent();
        }

        // Метод обработки события нажатия кнопки выбора файла
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание объекта диалога для выбора файлов
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Открытие диалога и проверка, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                // Отображение пути выбранного файла в текстовом поле
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        // Метод обработки события нажатия кнопки анализа файла
        private void AnalyzeFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение пути файла из текстового поля
            string filePath = FilePathTextBox.Text;

            // Проверка, выбран ли файл
            if (string.IsNullOrEmpty(filePath))
            {
                // Вывод сообщения об ошибке, если файл не выбран
                MessageBox.Show("Выберите файл для анализа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание объекта FileInfo для получения информации о файле
            FileInfo fileInfo = new FileInfo(filePath);

            // Формирование строки с основными характеристиками файла
            string result = $"Анализ файла: {fileInfo.Name}\nРазмер: {fileInfo.Length} байт\n";

            // Проверка расширения файла на потенциально опасные форматы (исполняемые файлы)
            if (fileInfo.Extension == ".exe" || fileInfo.Extension == ".bat")
            {
                result += "Предупреждение: файл исполняемый, возможен риск заражения!\n";
            }
            else
            {
                result += "Файл безопасен.";
            }

            // Отображение результата анализа в текстовом блоке
            ResultTextBlock.Text = result;
        }

        // Метод обработки события нажатия кнопки "Назад"
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового объекта главного окна и его отображение
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрытие текущего окна
            this.Close();
        }
    }
}
