using Microsoft.VisualBasic.FileIO;
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

namespace WPF_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Data> dataList;

        internal List<Data> DataList { get => dataList; set => dataList = value; }

        public int currPos;
        public int[] choosenAnsw;
        public int time = 10;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            List<Data> list = new List<Data>();
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Даниль\source\repos\WPF_2\WPF_2\WPF_2_Test.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] rows = parser.ReadFields();
                    list.Add(new Data(rows[0], rows[1], rows[2], rows[3], int.Parse(rows[4])));
                }
            }
            DataList = list;
            currPos = 0;
            choosenAnsw = new int[list.Count];

            setQuestion(0);

            timer.Start();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);

        }

        private void timer_tick(object sender, EventArgs e)
        {
            time--;
            lab1.Content = (time/60).ToString();
            lab2.Content = (time - time/60*60).ToString();
            if (time == 0)
            {
                getCounter();
            }
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            choosenAnsw[currPos] = radioChecker();

            if (currPos != 0)
            {
                currPos--;
                setQuestion(currPos);
            }
        }

        private void buttonNext_click(object sender, RoutedEventArgs e)
        {
            choosenAnsw[currPos] = radioChecker();

            if (currPos != DataList.Count -1)
            {
                currPos++;
                setQuestion(currPos);
            }
        }

        private void button_end_click(object sender, RoutedEventArgs e)
        {
            getCounter();
        }

        private void getCounter()
        {
            choosenAnsw[currPos] = radioChecker();
            int count = 0;
            for (int i = 0; i < DataList.Count; i++)
            {
                if (DataList[i].RightAnsw == choosenAnsw[i])
                {
                    count++;
                }
            }
            MessageBox.Show("Правильных ответов: " + count + " из " + DataList.Count);
        }

        private int radioChecker()
        {
            int numb = 0;
            if (radio1.IsChecked == true)
            {
                numb = 1;
            }

            if (radio2.IsChecked == true)
            {
                numb = 2;
            }

            if (radio3.IsChecked == true)
            {
                numb = 3;
            }
            return numb;
        }

        private void setQuestion(int pos)
        {
            text1.Text = DataList[pos].Question;
            radio1.Content = DataList[pos].Answ1;
            radio2.Content = DataList[pos].Answ2;
            radio3.Content = DataList[pos].Answ3;
            if (choosenAnsw[pos] != 0)
            {
                switch(choosenAnsw[pos])
                {
                    case 1:
                        radio1.IsChecked = true;
                        radio2.IsChecked = false;
                        radio3.IsChecked = false;
                        break;
                    case 2:
                        radio2.IsChecked = true;
                        radio1.IsChecked= false;
                        radio3.IsChecked= false;
                        break;
                    case 3:
                        radio3.IsChecked = true;
                        radio1.IsChecked = false;
                        radio2.IsChecked= false;
                        break;
                }
            }
            else
            {
                radio1.IsChecked = false;
                radio2.IsChecked = false;
                radio3.IsChecked = false;
            }

        }


    }
}
