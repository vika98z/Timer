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
using System.Windows.Threading;

namespace TIMER
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer();
        DateTime startTime, pauseTime;
        TimeSpan pauseSpan;
        bool flag = false;

        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
            
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            pauseTime = startTime;
            pauseSpan = TimeSpan.Zero;
            TimeSpan s = DateTime.Now - startTime - pauseSpan;
            label1.Content = string.Format("{0}:{1}",
            s.Minutes * 60 + s.Seconds, s.Milliseconds / 100);
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                comboBox.Items.Add((sender as ComboBox).Text);
            }
        }

        private void clear1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void exit1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!flag)
            {
                startTime = DateTime.Now;
                pauseTime = startTime;
                pauseSpan = TimeSpan.Zero;
                timer1.Start();
                button.Content = "Стоп";
                flag = true;
            }
            else
            {
                listBox.Items.Add(comboBox.Text + " " + label1.Content);
                label1.Content = "0:0";
                timer1.Stop();
                button.Content = "Старт";
                startTime = DateTime.Now;
                pauseTime = startTime;
                pauseSpan = TimeSpan.Zero;
                flag = false;
            }
        }
    }
}
