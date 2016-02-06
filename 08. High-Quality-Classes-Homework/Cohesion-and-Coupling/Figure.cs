using System;

namespace CohesionAndCoupling
{
    public class Figure
    {
        private double width;
        private double height;
        private double depth;

        public Figure(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
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
        public double Height
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
        public double Depth
        {
            get { return this.depth; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid depth. Depth must be a positive number", "depth");
                }

                this.depth = value;
            }
        }
    }
}