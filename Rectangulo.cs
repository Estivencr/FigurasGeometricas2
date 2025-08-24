using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    class Rectangulo : Figura
    {

        public double Ancho;
        public double Alto;

        public Rectangulo(double x, double y, double ancho, double alto) : base(x, y)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public override double CalcularArea()
        {
            try
            {
                if (Ancho < 0 || Alto < 0)
                {
                    throw new ArgumentException("El ancho y el alto no pueden ser negativos.");
                }
                else
                {
                    return Ancho * Alto;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public override double CalcularPerimetro()
        {
            try
            {
                if (Ancho < 0 || Alto < 0)
                {
                    throw new ArgumentException("El ancho y el alto no pueden ser negativos.");
                }
                else
                {
                    return 2 * (Ancho + Alto);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
