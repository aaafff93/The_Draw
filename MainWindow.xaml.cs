using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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

namespace TheDraw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ArrayList groups = new ArrayList();

        public static string[] RandomShuffle(string[] arr, Random rand)
        {
            //Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                string tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
            return arr;
        }

        public MainWindow()
        {
            InitializeComponent();

            Pot_1.ItemsSource = File.ReadAllLines(@"..\..\_Pots\Pot1.txt");
            Pot_2.ItemsSource = File.ReadAllLines(@"..\..\_Pots\Pot2.txt");
            Pot_3.ItemsSource = File.ReadAllLines(@"..\..\_Pots\Pot3.txt");
            Pot_4.ItemsSource = File.ReadAllLines(@"..\..\_Pots\Pot4.txt");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = "C:\\Users\\Александр\\Desktop\\inf\\Новая папка\\TheDraw\\SN.wav";
            //sp.Load();
            //sp.PlayLooping();

            Random rand = new Random();

            string[] pot_1 = RandomShuffle((from object item in Pot_1.Items select item.ToString()).ToArray<string>(), rand);
            string[] pot_2 = RandomShuffle((from object item in Pot_2.Items select item.ToString()).ToArray<string>(), rand);
            string[] pot_3 = RandomShuffle((from object item in Pot_3.Items select item.ToString()).ToArray<string>(), rand);
            string[] pot_4 = RandomShuffle((from object item in Pot_4.Items select item.ToString()).ToArray<string>(), rand);

            Group_A.Items.Clear();
            Group_B.Items.Clear();
            Group_C.Items.Clear();
            Group_D.Items.Clear();
            Group_E.Items.Clear();
            Group_F.Items.Clear();
            Group_G.Items.Clear();
            Group_H.Items.Clear();

            ArrayList groups = new ArrayList();
            groups.Add(pot_1);
            groups.Add(pot_2);
            groups.Add(pot_3);
            groups.Add(pot_4);

            foreach (string[] pot in groups)
            {
                await Task.Delay(1000);
                Group_A.Items.Add(pot[0]);
                await Task.Delay(1000);
                Group_B.Items.Add(pot[1]);
                await Task.Delay(1000);
                Group_C.Items.Add(pot[2]);
                await Task.Delay(1000);
                Group_D.Items.Add(pot[3]);
                await Task.Delay(1000);
                Group_E.Items.Add(pot[4]);
                await Task.Delay(1000);
                Group_F.Items.Add(pot[5]);
                await Task.Delay(1000);
                Group_G.Items.Add(pot[6]);
                await Task.Delay(1000);
                Group_H.Items.Add(pot[7]);
            }

        }
    }
}
