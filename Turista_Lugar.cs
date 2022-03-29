using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    public class Turista_Lugar
    {
        public int ci { get; }
        public string idLugar { get; }
        public Turista_Lugar(int ci, string idLugar)
        {
            this.ci = ci;
            this.idLugar = idLugar;
        }
    }
}
