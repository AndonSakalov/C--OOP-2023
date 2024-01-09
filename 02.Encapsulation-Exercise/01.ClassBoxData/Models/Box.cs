using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        private const string ExceptionMessage = "{0} cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage, nameof(Length)));
                }

                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage, nameof(Width)));
                }

                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage, nameof(Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();
        public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);

        public double Volume() => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {Volume():F2}");
            return sb.ToString();
        }
    }
}
