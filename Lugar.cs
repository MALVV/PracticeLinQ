using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    public class Lugar
    {
        public string codigoLugar { get; }
        public string nombreLugar { get; }
        public int codigoPaquete { get; }
        public Lugar(string codigoLugar, string nombreLugar, int codigoPaquete)
        {
            this.codigoLugar = codigoLugar;
            this.nombreLugar = nombreLugar;
            this.codigoPaquete = codigoPaquete;

        }
    }
}
