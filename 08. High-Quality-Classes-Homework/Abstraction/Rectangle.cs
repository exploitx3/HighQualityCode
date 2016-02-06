using System;

namespace Abstraction
{
    class Rectangle : Figure
    {

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double Radius
        {
            get
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
            set
            {
                throw new NotImplementedException("Rectangle does not have Radius");
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (base.Width + base.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = base.Width * base.Height;
            return surface;
        }
    }
}
