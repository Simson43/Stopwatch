using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (startStopButton.Content.ToString() == "Старт")
            {
                startStopButton.Content = "Стоп";
                circleResetButton.Content = "Круг";
                startStopButton.Background = Brushes.LightPink;
            }
            else if (startStopButton.Content.ToString() == "Стоп")
            {
                startStopButton.Content = "Старт";
                circleResetButton.Content = "Сброс";
                startStopButton.Background = Brushes.LightGreen;
            }
        }
    }
}
