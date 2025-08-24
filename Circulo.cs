using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    class Circulo : Figura
    {
        public double Radio { get; set; }

        public Circulo(double x, double y, double r) : base(x, y)
        {
            Radio = r;
        }
        public override double CalcularArea()
        {
            try { 
                if (Radio < 0)
                {
                    throw new ArgumentException("El radio no puede ser negativo.");
                }
                else
                {
                    return Math.PI * Math.Pow(Radio, 2);
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
                return Math.PI * Math.Pow(Radio, 2); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
