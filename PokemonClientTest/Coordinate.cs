using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClientTest
{
    internal class Coordinate
    {
        private int xCoord;
        private int yCoord;
        private int xPixelPosition;
        private int yPixelPosition;
        
        public Coordinate(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.xPixelPosition = this.xCoord * Cell.CellLength;
            this.yPixelPosition = this.yCoord * Cell.CellLength;    
        }

        public int getXCoord()
        {
            return xCoord;
        }

        public int getYCoord()
        {
            return yCoord;
        }

        public int getXPixelPosition()
        {
            return xPixelPosition;
        }

        public int getYPixelPosition()
        {
            return yPixelPosition;
        }

    }
}
