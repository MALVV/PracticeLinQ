using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    public class Turista
    {
        public int ci { get; }
        public string nombreTurista { get; }
        public string codigoTour { get; }
        public int codigoPaquete { get; }
        public Turista(int ci, string nombreTurista, string codigoTour, int codigoPaquete)
        {
            this.ci = ci;
            this.nombreTurista = nombreTurista;
            this.codigoTour = codigoTour;
            this.codigoPaquete = codigoPaquete;

        }
    }
}
