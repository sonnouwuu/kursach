using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static virus1.TestWindow;

namespace virus1
{
   
   
    public partial class TestWindow : Window
    {
        // Список номеров вопросов
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int qNum = 0; // Номер текущего вопроса
        int i; // Хранит номер вопроса после его извлечения
        int score; // Количество правильных ответов

        // Конструктор окна тестирования
        public TestWindow()
        {
            InitializeComponent();
            StartGame(); // Инициализация игры
            NextQuestion(); // Загрузка первого вопроса
        }

      
        //Проверяет правильность ответа, обновляет счет и загружает следующий вопрос.
   
        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            // Если тег кнопки равен "1", значит, это правильный ответ
            if (senderButton.Tag.ToString() == "1")
            {
                score++; // Увеличиваем количество правильных ответов
            }

            // Предотвращаем отрицательный номер вопроса
            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                qNum++; // Переход к следующему вопросу
            }

            // Обновляем счетчик правильных ответов
            ScoreText.Content = " Правильный ответ " + score + "/" + questionNumbers.Count;

            NextQuestion(); // Загружаем новый вопрос
        }

        // Сбрасывает прогресс игры и начинает тест заново.
        
        private void RestartGame()
        {
            score = 0;
            qNum = -1;
            i = 0;
            StartGame();
        }

        
        // Загружает следующий вопрос и обновляет UI.
       
        private void NextQuestion()
        {
            // Если еще есть вопросы, загружаем следующий
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {
                RestartGame(); // Если вопросов больше нет, перезапускаем тест
            }

            // Сбрасываем цвет кнопок и теги ответов
            foreach (var x in MyCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.Maroon;
            }

            // Выбираем вопрос в зависимости от номера
            switch (i)
            {
                case 1:
                    txtQuestions.Text = "Что делает компьютерный вирус?";
                    ans1.Content = "Защищает компьютер";
                    ans2.Content = "Повышает скорость работы";
                    ans3.Content = "Нарушает работу системы";
                    ans3.Tag = "1"; // Правильный ответ
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/image1/1.jpg"));
                    break;

                case 2:
                    txtQuestions.Text = "Как называется вирус, который требует выкуп?";
                    ans1.Content = "Руткит";
                    ans2.Content = "Вымогатель";
                    ans3.Content = "Троян";
                    ans2.Tag = "1"; // Правильный ответ
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/image1/2.jpg"));
                    break;

                case 3:
                    txtQuestions.Text = "Что такое ILOVEYOU?";
                    ans1.Content = "Компьютерный вирус, который шифрует файлы и требует выкуп";
                    ans2.Content = "Вредоносный скрипт, распространяющийся через электронную почту";
                    ans3.Content = "Программа для защиты компьютера от угроз";
                    ans2.Tag = "1"; // Правильный ответ
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/image1/3.jpg"));
                    break;

                case 4:
                    txtQuestions.Text = "Какую цель преследовал вирус MyDoom?";
                    ans1.Content = "Создание ботнета для проведения DDoS-атак";
                    ans2.Content = "Шифрование данных и требование выкупа";
                    ans3.Content = "Автоматическое обновление операционных систем";
                    ans1.Tag = "1"; // Правильный ответ
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/image1/4.jpg"));
                    break;

                // (Добавлены аналогичные блоки для оставшихся вопросов)

                case 10:
                    txtQuestions.Text = "Какой вирус использовал уязвимость EternalBlue?";
                    ans1.Content = "ILOVEYOU";
                    ans2.Content = "Melissa";
                    ans3.Content = "WannaCry";
                    ans3.Tag = "1"; // Правильный ответ
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/image1/9.jpg"));
                    break;
            }
        }

       
        // Перемешивает список вопросов для случайного порядка.
       
        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
            questionNumbers = randomList;
            questionsOrder.Content = null;

            // Выводим порядок вопросов для отладки
            for (int i = 0; i < questionNumbers.Count; i++)
            {
                questionsOrder.Content += " " + questionNumbers[i].ToString();
            }
        }

       
        // Метод Button_Click возвращает пользователя в главное окно.
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
