using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    class Triangulo : Figura
    {
        public double BaseT;
        public double Altura;

        public Triangulo(double x, double y, double baseT, double altura) : base(x, y)
        {
            BaseT = baseT;
            Altura = altura;
        }

        public override double CalcularArea() => (BaseT * Altura) / 2;

        public override double CalcularPerimetro()
        {
            double lado = Math.Sqrt(Math.Pow(BaseT / 2, 2) + Math.Pow(Altura, 2));
            return BaseT + 2 * lado;
        }
    }
}
