using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokemonClientTest
{
    internal class Cell
    {
        public static int CellLength = 45;
        private Coordinate coordinate;
        private Canvas canvas;
        private Image grassImage;
        private Image pokemonImage;
        private Rectangle rectangleStroke;
        string imageAbsolutePathOfGrass = "C:\\Users\\allan\\source\\repos\\PokemonClientTest\\PokemonClientTest\\grass.png";
        string imageAbsultePathOfTestPokemon = "C:\\Users\\allan\\source\\repos\\PokemonClientTest\\PokemonClientTest\\Charizard.png";
        string relativeTest = "PokemonClientTest/grass.png";
        public Cell(Canvas canvas, Coordinate coordinate)
        {
            this.canvas = canvas;
            this.coordinate = coordinate;

            grassImage = new Image()
            {
                Width = CellLength,
                Height = CellLength,
                //Name = "TestName",
                Source = new BitmapImage(new Uri(imageAbsolutePathOfGrass))
            };

            pokemonImage = new Image()
            {
                Width = CellLength,
                Height = CellLength,
                //Name = "TestName",
                //Source = new BitmapImage(new Uri(imageAbsultePathOfTestPokemon))
                Source = new BitmapImage(new Uri(imageAbsultePathOfTestPokemon))
            };

            rectangleStroke = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Height = CellLength,
                Width = CellLength
            };

        }

        public void drawCell()
        {
            canvas.Children.Remove(grassImage);
            canvas.Children.Remove(rectangleStroke);
            canvas.Children.Add(grassImage);
            Canvas.SetLeft(grassImage, coordinate.getXPixelPosition());
            Canvas.SetTop(grassImage, coordinate.getYPixelPosition());

            canvas.Children.Add(rectangleStroke);
            Canvas.SetLeft(rectangleStroke, coordinate.getXPixelPosition());
            Canvas.SetTop(rectangleStroke, coordinate.getYPixelPosition());

        }

        public void drawPokemon()
        {
            if (canvas.Children.Contains(pokemonImage))
            {
                canvas.Children.Remove(pokemonImage);
            }
            canvas.Children.Add(pokemonImage);
            Canvas.SetLeft(pokemonImage, coordinate.getXPixelPosition());
            Canvas.SetTop(pokemonImage, coordinate.getYPixelPosition());
        }
    }
}
