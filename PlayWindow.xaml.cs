using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; // Основное пространство имен WPF
using System.Windows.Controls; 
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media; // Работа с графическим интерфейсом
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading; // Позволяет использовать таймеры внутри WPF

namespace virus1 
{
   
    public partial class PlayWindow : Window
    {
        // Таймеры для различных эффектов атаки
        private DispatcherTimer attackTimer; // Управляет прогрессией вирусной атаки
        private DispatcherTimer dangerTimer; // Отсчет времени до критической стадии заражения
        private DispatcherTimer defeatTimer; // Таймер до полного заражения системы
        private DispatcherTimer glitchTimer; // Таймер, вызывающий визуальные "глитчи"

        // Переменные состояния атаки
        private int attackStage; // Этап атаки
        private int defeatCounter; // Количество секунд до поражения системы
        private string activeAttackType; // Текущий тип вирусной атаки
        private bool defenseApplied = false; // Флаг, указывающий, была ли применена защита
        private Random random = new Random(); // Генератор случайных значений

        // Конструктор окна PlayWindow, инициализирует таймеры и логику атаки
        public PlayWindow()
        {
            InitializeComponent();

            // Настройка таймеров
            attackTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            attackTimer.Tick += AttackEffect; // Обновляет эффект атаки

            dangerTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
            dangerTimer.Tick += DefeatCountdown; // Обновляет отсчет до критического момента

            defeatTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            defeatTimer.Tick += DefeatCountdown; // Обновляет таймер до полного заражения

            glitchTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(300) };
            glitchTimer.Tick += GlitchEffect; // Вызывает визуальные глитчи
        }

        // Метод запуска вирусной атаки
        private void StartAttack_Click(object sender, RoutedEventArgs e)
        {
            attackStage = 0;
            defeatCounter = 20; // Устанавливаем время до поражения
            defenseApplied = false; // Сбрасываем защиту
            activeAttackType = SelectRandomAttack(); // Выбираем случайный тип вируса

            // Запускаем таймеры атаки
            attackTimer.Start();
            dangerTimer.Start();
            defeatTimer.Start();

            // Выводим предупреждение в логах и меняем фон
            AttackLog.Text = $"⚠ Вирус запущен! Тип атаки: {activeAttackType}\n";
            Background = Brushes.DarkRed;

            // Обновляем UI таймера
            UpdateTimerUI();
        }

        // Метод случайного выбора типа атаки
        private string SelectRandomAttack()
        {
            string[] attacks = { "DDoS-атака", "Шифратор", "Кейлоггер", "Троян", "Руткит", "Червь", "Эксплойт", "Фишинг", "Рекламный вирус", "Ботнет" };
            return attacks[random.Next(attacks.Length)]; // Выбираем случайную атаку
        }

        // Эффект усиления вирусной атаки
        private void AttackEffect(object sender, EventArgs e)
        {
            attackStage++; // Увеличиваем уровень атаки
            AttackLog.Text += $"⚠ Этап {attackStage}: {activeAttackType} усиливается...\n";

            // Если атака достигла 5-го этапа, вирус мутирует
            if (attackStage >= 5)
            {
                AttackLog.Text += "🔥 Вирус мутировал, заражение усиливается!\n";
            }
        }

        // Метод обработки поражения системы
        private void DefeatCountdown(object sender, EventArgs e)
        {
            if (!defenseApplied)
            {
                defeatCounter--;
                UpdateTimerUI();

                // Если осталось 5 секунд — включаем визуальные глитчи
                if (defeatCounter <= 5) glitchTimer.Start();
                if (defeatCounter <= 0)
                {
                    defeatTimer.Stop();
                    attackTimer.Stop();
                    dangerTimer.Stop();
                    glitchTimer.Stop();

                    AttackLog.Text += "💀 Система полностью заражена! Требуется перезагрузка...\n";
                    Background = Brushes.Black;
                }
            }
        }

        // Обновление UI таймера
        private void UpdateTimerUI()
        {
            TimerText.Text = $"⏳ Осталось: {defeatCounter} сек";
            AttackProgressBar.Value = defeatCounter;

            // Меняем цвет текста в зависимости от оставшегося времени
            if (defeatCounter <= 10)
                TimerText.Foreground = Brushes.Orange;
            if (defeatCounter <= 5)
                TimerText.Foreground = Brushes.Red;
        }

        // Визуальные глитчи при критическом уровне заражения
        private void GlitchEffect(object sender, EventArgs e)
        {
            Color[] glitchColors = { Colors.Red, Colors.Magenta, Colors.DarkBlue, Colors.Black };
            Background = new SolidColorBrush(glitchColors[random.Next(glitchColors.Length)]);

            string[] glitchText = { "###", "!!!", "&&&", "@@@" };
            AttackLog.Text += glitchText[random.Next(glitchText.Length)] + " Глитч в системе! " + glitchText[random.Next(glitchText.Length)] + "\n";
        }

        // Применение защиты против атаки
        private void ApplyDefense_Click(object sender, RoutedEventArgs e)
        {
            if (DefenseOptions.SelectedItem is ComboBoxItem selectedDefense)
            {
                AttackLog.Text += $"🛡 Выбрана защита: {selectedDefense.Content}\n";

                if (IsDefenseCorrect(selectedDefense.Content.ToString()))
                {
                    // Если защита правильная — атака останавливается
                    defenseApplied = true;
                    defeatTimer.Stop();
                    dangerTimer.Stop();
                    glitchTimer.Stop();
                    AttackLog.Text += "✅ Атака успешно нейтрализована!\n";
                    Background = Brushes.Green;
                    attackTimer.Stop();
                }
                else
                {
                    // Если защита неверная — атака мутирует
                    AttackLog.Text += "⚠ Выбранная защита неэффективна! Вирус продолжает атаку...\n";
                    Background = Brushes.DarkOrange;
                    attackStage++;
                    AttackLog.Text += "🔥 Вирус мутировал! Защита теперь сложнее!\n";

                    if (defeatCounter <= 5) glitchTimer.Start();
                }
            }
            else
            {
                AttackLog.Text += "⚠ Выберите метод защиты!\n";
            }
        }

        // Проверка корректности выбранной защиты
        private bool IsDefenseCorrect(string defenseType)
        {
            return activeAttackType.Equals(defenseType.Trim(), StringComparison.OrdinalIgnoreCase);
        }// Простая проверка соответствия
        

        // Метод возврата к главному окну
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
