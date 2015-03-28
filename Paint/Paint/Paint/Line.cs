using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class Line
    {
        public Pen p;
        public int x1, x2, y1, y2;
        public Line(Pen p, int x1, int y1, int x2, int y2)
        {
            this.p = p;
            this.x1 = x1;

            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }


    }
}
