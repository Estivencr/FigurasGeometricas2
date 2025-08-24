using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public abstract class Figura
    {
        public double posicionX;
        public double posicionY;

        public Figura(double x, double y)
        {
            posicionX = x;
            posicionY = y;
        }

        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }
}
