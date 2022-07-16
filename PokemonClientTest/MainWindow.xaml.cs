using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PokemonClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Graph map;
        public MainWindow()
        {
            InitializeComponent();
            

            map = new Graph(canvas, new Coordinate(10, 15));
            map.drawGraph();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Equals("Up"))
            {
                map.moveCharacterUp();
            } else if (e.Key.ToString().Equals("Down"))
            {
                map.moveCharacterDown();
            }else if (e.Key.ToString().Equals("Left")) 
            {
                map.moveCharacterLeft();
            }else if (e.Key.ToString().Equals("Right"))
            {
                map.moveCharacterRight();
            }
        }
    }
}
