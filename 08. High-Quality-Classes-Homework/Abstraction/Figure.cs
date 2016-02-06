using System;

namespace Abstraction
{
    abstract class Figure
    {
        private double width;
        private double height;
        private double radius;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public virtual double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid width. Width must be a positive number", "width");
                }

                this.width = value;
            }
        }
        public virtual double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid height. Height must be a positive number", "height");
                }

                this.height = value;
            }
        }
        public virtual double Radius
        {
            get { return this.radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid width. Radius must be a positive number", "radius");
                }

                this.radius = value;
            }
        }
    }
}
