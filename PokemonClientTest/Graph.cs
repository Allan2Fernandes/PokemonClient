using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PokemonClientTest
{
    internal class Graph
    {
        private Cell[,] mapArray;
        private int xNumOfCells;
        private int yNumOfCells;
        private Canvas canvas;
        private Coordinate currentCharacterPosition;
        public Graph(Canvas canvas, Coordinate currentCharacterPosition)
        {
            this.canvas = canvas;
            this.xNumOfCells = (int)canvas.Width / Cell.CellLength;
            this.yNumOfCells = (int)canvas.Height / Cell.CellLength;
            this.currentCharacterPosition = currentCharacterPosition;
            mapArray = new Cell[xNumOfCells, yNumOfCells];
            for (int i = 0; i < xNumOfCells; i++)
            {
                for (int j = 0; j < yNumOfCells; j++)
                {
                    mapArray[i, j] = new Cell(this.canvas, new Coordinate(i, j));
                }
            }
        }

        public void drawGraph()
        {
            for (int i = 0; i < xNumOfCells; i++)
            {
                for (int j = 0; j < yNumOfCells; j++)
                {
                    mapArray[i, j].drawCell();
                }
            }

        }

        public void drawCharacterAt(Coordinate characterPosition)
        {
            mapArray[characterPosition.getXCoord(), characterPosition.getYCoord()].drawPokemon();
        }

        public void moveCharacterUp()
        {
            if(currentCharacterPosition.getYCoord() == 0)
            {
                return;
            }
            mapArray[currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord()].drawCell();
            currentCharacterPosition = new Coordinate(currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord() - 1);
            drawCharacterAt(currentCharacterPosition);
        }

        public void moveCharacterDown()
        {
            if (currentCharacterPosition.getYCoord() == yNumOfCells-1)
            {
                return;
            }
            mapArray[currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord()].drawCell();
            currentCharacterPosition = new Coordinate(currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord() + 1);
            drawCharacterAt(currentCharacterPosition);
        }

        public void moveCharacterLeft()
        {
            if (currentCharacterPosition.getXCoord() == 0)
            {
                return;
            }
            mapArray[currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord()].drawCell();
            currentCharacterPosition = new Coordinate(currentCharacterPosition.getXCoord()-1, currentCharacterPosition.getYCoord());
            drawCharacterAt(currentCharacterPosition);
        }

        public void moveCharacterRight()
        {
            if (currentCharacterPosition.getXCoord() == xNumOfCells-1)
            {
                return;
            }
            mapArray[currentCharacterPosition.getXCoord(), currentCharacterPosition.getYCoord()].drawCell();    
            currentCharacterPosition = new Coordinate(currentCharacterPosition.getXCoord() + 1, currentCharacterPosition.getYCoord());
            drawCharacterAt(currentCharacterPosition);
        }
    }
}
