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

namespace EasyLuckyNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<int> data = new List<int>();
        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();

            Instance = this;

            KeyDown += (s, e) =>
            {
                if(e.Key == Key.Escape)
                {
                    Settings settingWindow = new Settings();
                    settingWindow.Show();
                }else if(e.Key == Key.Space)
                {
                    if(data.Count == 0)
                    {
                        MessageBox.Show("Vui lòng thiết lập tệp dữ liệu trước khi bắt đầu quay bằng cách nhấn nút ESC.");
                        return;
                    }

                    spinning();
                }else if(e.Key == Key.R)
                {
                    displayNumber.Text = "000";
                }
            };
        }

        private void spinning()
        {
            Random rand = new Random();
            int index = rand.Next(data.Count);
            int luckyNumber = data[index];

            int t = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval += TimeSpan.FromMilliseconds(100);
            timer.Tick += (s, e) =>
            {
                if(t >= 3*1000)
                {
                    displayNumber.Text = luckyNumber.ToString("D3");
                    data.Remove(luckyNumber);

                    timer.Stop();
                }else
                {
                    displayNumber.Text = rand.Next(999).ToString("D3");
                    t+=100;
                }
            };
            timer.Start();
        }

    }
}
