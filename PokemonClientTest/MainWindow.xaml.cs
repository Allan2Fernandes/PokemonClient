using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace PokemonClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Graph map;

        //TCP stuff
        static TcpClient tcpclnt;
        string ip = "82.102.27.171";
        int port = 24456;
        Stream stm;
        public MainWindow()
        {
            InitializeComponent();
            

            map = new Graph(canvas, new Coordinate(10, 15));
            map.drawGraph();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            //Sending the string:
            String sentString = e.Key.ToString();
            stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(sentString);

            stm.Write(ba, 0, ba.Length);
            Console.WriteLine("Sending " + sentString);
            stm.Flush();

            //Recieve the string
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);
            string receivedMessage = "";
            for (int i = 0; i < k; i++)
            {
                receivedMessage = receivedMessage + Convert.ToChar(bb[i]);
            }
            if (sentString.Equals(receivedMessage))
            {
                if (e.Key.ToString().Equals("Up"))
                {
                    map.moveCharacterUp();
                }
                else if (e.Key.ToString().Equals("Down"))
                {
                    map.moveCharacterDown();
                }
                else if (e.Key.ToString().Equals("Left"))
                {
                    map.moveCharacterLeft();
                }
                else if (e.Key.ToString().Equals("Right"))
                {
                    map.moveCharacterRight();
                }
            }
        }





        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                tcpclnt.Close();
                Debug.WriteLine("Disconnected");
            }
            catch (Exception exception)
            {
                exception.GetBaseException();
            }
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("Test");
                tcpclnt = new TcpClient();
                tcpclnt.Connect(ip, port);
                Debug.WriteLine("Connected");
            }
            catch (Exception exception)
            {
                exception.GetBaseException();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tcpclnt.Close();
                Debug.WriteLine("Disconnected");
            }
            catch (Exception exception)
            {
                exception.GetBaseException();
            }
        }
    }
}
