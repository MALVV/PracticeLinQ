using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    public class Paquete
    {
        public int codigoPaquete { get; }
        public string nombrePaquete { get; }

        public Paquete(int codigoPaquete, string nombrePaquete)
        {
            this.codigoPaquete = codigoPaquete;
            this.nombrePaquete = nombrePaquete;
        }
    }
}
