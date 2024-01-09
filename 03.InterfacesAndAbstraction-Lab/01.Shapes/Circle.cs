using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        //public void Draw()
        //{
        //    DrawLine(this.width, '*', '*');
        //    for (int i = 1; i < this.height - 1; ++i)
        //        DrawLine(this.width, '*', ' ');
        //    DrawLine(this.width, '*', '*');

        //}

        //private void DrawLine(int width, char end, char mid)
        //{
        //    Console.Write(end);
        //    for (int i = 1; i < width - 1; ++i)
        //        Console.Write(mid);
        //    Console.WriteLine(end);
        //}
    }
}
