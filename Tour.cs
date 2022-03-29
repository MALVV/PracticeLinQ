using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    public class Tour
    {
        public string codigoTour { get; }
        public string nombreTour { get; }
        public string responsable { get; }
        public Tour(string codigoTour, string nombreTour, string responsable)
        {
            this.codigoTour = codigoTour;
            this.nombreTour = nombreTour;
            this.responsable = responsable;

        }
    }
}
