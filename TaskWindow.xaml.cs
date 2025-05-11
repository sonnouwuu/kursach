using System;

using System.Text;
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Media; 
using System.Windows.Shapes; 
using System.Windows.Threading; 

namespace virus1 
{
   
    public partial class TaskWindow : Window
    {
        private DispatcherTimer timer; // Таймер для симуляции распространения инфекции
        private Random rand = new Random(); // Генератор случайных значений
        private int infectedCount = 0; // Количество зараженных узлов
        private const int TotalNodes = 10; // Общее количество узлов в сети

        // Конструктор TaskWindow, инициализирует UI и запускает симуляцию
        public TaskWindow()
        {
            InitializeComponent();
            StartSimulation(); // Запуск симуляции при создании окна
        }

        /// Метод StartSimulation очищает канвас и создает новые узлы.
      
        private void StartSimulation()
        {
            NetworkCanvas.Children.Clear(); // Очищаем канвас перед новой симуляцией
            infectedCount = 0; // Сбрасываем количество зараженных узлов

            // Создаем узлы на канвасе
            for (int i = 0; i < TotalNodes; i++)
            {
                Ellipse node = new Ellipse
                {
                    Width = 30,
                    Height = 30,
                    Fill = Brushes.White, // Узел по умолчанию белый
                    Stroke = Brushes.Gray, // Серый контур
                    StrokeThickness = 2
                };

                // Случайное размещение узла на канвасе
                double x = rand.Next(50, 700);
                double y = rand.Next(50, 500);
                Canvas.SetLeft(node, x);
                Canvas.SetTop(node, y);
                NetworkCanvas.Children.Add(node); // Добавляем узел на канвас
            }

            // Настраиваем таймер, который будет распространять вирус
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += SpreadInfection; // Привязываем обработчик события
            timer.Start(); // Запускаем таймер
        }

        /// <summary>
        /// Метод SpreadInfection заражает узлы по очереди, создавая соединения между ними.
        /// </summary>
        private void SpreadInfection(object sender, EventArgs e)
        {
            // Если все узлы уже заражены, перезапускаем симуляцию
            if (infectedCount >= TotalNodes)
            {
                timer.Stop(); // Останавливаем таймер
                StartSimulation(); // Запускаем новую симуляцию
                return;
            }

            // Получаем текущий узел для заражения
            Ellipse node = NetworkCanvas.Children[infectedCount] as Ellipse;
            if (node != null)
            {
                node.Fill = Brushes.Red; // Меняем цвет узла на красный, показывая заражение

                // Создаем соединение с предыдущим узлом, если это не первый узел
                if (infectedCount > 0)
                {
                    Ellipse previousNode = NetworkCanvas.Children[infectedCount - 1] as Ellipse;
                    if (previousNode != null)
                    {
                        Line connection = new Line
                        {
                            Stroke = Brushes.Red, // Красная линия для зараженного соединения
                            StrokeThickness = 2,
                            X1 = Canvas.GetLeft(node) + 15,
                            Y1 = Canvas.GetTop(node) + 15,
                            X2 = Canvas.GetLeft(previousNode) + 15,
                            Y2 = Canvas.GetTop(previousNode) + 15
                        };
                        NetworkCanvas.Children.Add(connection); // Добавляем соединение на канвас
                    }
                }
            }
            infectedCount++; // Увеличиваем счетчик зараженных узлов
        }

        /// <summary>
        /// Метод Button_Click возвращает пользователя в главное окно.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Метод OpenPage открывает страницу с информацией о вирусе ILOVEYOU.
        /// </summary>
        private void OpenPage(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/ILOVEYOU");
        }

        /// <summary>
        /// Метод OpenForm2 создает новое окно PageWindow для отображения веб-страницы.
        /// </summary>
        private void OpenForm2(string url)
        {
            PageWindow form2 = new PageWindow(url);
            form2.Show();
        }

        // Методы открытия страниц с описаниями известных вирусов
        private void WannaCry(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/WannaCry");
        }
        private void MyDoom(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/Mydoom");
        }
        private void Stuxnet(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/Stuxnet");
        }
        private void NotPetya(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/Petya_ransomware");
        }
        private void SQL(object sender, RoutedEventArgs e)
        {
            OpenForm2("https://ru.wikipedia.org/wiki/SQL_Slammer");
        }

        /// <summary>
        /// Метод Nazad_Click возвращает пользователя в главное окно.
        /// </summary>
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
