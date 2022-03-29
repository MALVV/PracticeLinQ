using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQPractice
{
    internal class Program
    {
        static Turista[] turistas = {
        new Turista(123,"Elias Andrade","TA",4),
        new Turista(234,"Moira Alen","TA",2),
        new Turista(345,"Lony Labbe","TG",8),
        new Turista(456,"Sidney Sommer","TA",3),
        new Turista(567,"Ari Hass","TG",8),
        new Turista(678,"Rita Asis","TC",5),
        new Turista(789,"Marco Esteves","TA",3),
        new Turista(890,"Julia Lang","TG",6),
        new Turista(901,"Ingrid RamosAsis","TC",5),
        new Turista(012,"Erick Kolbe","TP",1)};

        static Tour[] tours = {
        new Tour("TA","Turismo Aventura","Magic Tours"),
        new Tour("TG","Turismo Gastronómico","Turismo Kronos"),
        new Tour("TC","Turismo Compras","Eva's Tours Co."),
        new Tour("TP","Turismo Paseos","Alex Tours")};

        static Lugar[] lugares = {
        new Lugar("PV","Puerto Varas",4),
        new Lugar("BRLCH","Bariloche",3),
        new Lugar("BRA","Rio de Janeiro",3),
        new Lugar("CHLT","Chalten",1),
        new Lugar("PA","Punta Arenas",5),
        new Lugar("PN","Puerto Natales",8),
        new Lugar("VAL","Valdivia",6),
        new Lugar("BA","Buenos Aires",2),
        new Lugar("SP","San Pablo",1),
        new Lugar("FLO","Florianópolis",2)};

        static Turista_Lugar[] turista_visita = {
        new Turista_Lugar(123,"BRLCH"),
        new Turista_Lugar(123,"PV"),
        new Turista_Lugar(123,"BRA"),
        new Turista_Lugar(123,"FLO"),
        new Turista_Lugar(234,"SP"),
        new Turista_Lugar(234,"BA"),
        new Turista_Lugar(345,"PN"),
        new Turista_Lugar(345,"VAL"),
        new Turista_Lugar(456,"BRA"),
        new Turista_Lugar(456,"BA"),
        new Turista_Lugar(567,"PN"),
        new Turista_Lugar(678,"PA"),
        new Turista_Lugar(678,"PV"),
        new Turista_Lugar(789,"BRA"),
        new Turista_Lugar(789,"SP"),
        new Turista_Lugar(789,"FLO"),
        new Turista_Lugar(890,"VAL"),
        new Turista_Lugar(890,"BRLCH"),
        new Turista_Lugar(901,"PA"),
        new Turista_Lugar(012,"CHLT")};

        static Paquete[] paquetes = {
        new Paquete(1,"Básico"),
        new Paquete(2,"Económico"),
        new Paquete(3,"Estandar"),
        new Paquete(4,"Jubilados"),
        new Paquete(5,"Familiar"),
        new Paquete(6,"Todo incluido"),
        new Paquete(7,"Extra"),
        new Paquete(8,"Vip")};
        static void Main(string[] args)
        {
            //ejr1();
            //ejr2("Puerto Varas");
            //ejr3("Básico");
            //ejr4("Elias Andrade");
            //ejr5();
            //ejr6();
            //ejr7();
            //ejr8();
            //ejr9();
            //ejr10();
            Console.ReadKey();

        }
        //1.-Listar todos los turistas agrupados por tour
        static void ejr1()
        {
            var listaTuristasTour = from turistas in turistas
                                    join tour in tours
                                    on turistas.codigoTour equals tour.codigoTour
                                    group turistas by tour.nombreTour;
            foreach (var tour in listaTuristasTour)
            {
                Console.WriteLine("Tour:" + tour.Key);
                foreach (var turista in turistas)
                {
                    Console.WriteLine("  " + turista.nombreTurista);
                }
            }
        }
        //2.-Dado el nombre de un lugar, listar los nombres de los turistas que visitaran ese lugar
        static void ejr2(string nombreLugar)
        {
            var listaTuristasLugar = from lugar in lugares
                                     join turistaslugares in turista_visita
                                     on lugar.codigoLugar equals turistaslugares.idLugar
                                     join turista in turistas
                                     on turistaslugares.ci equals turista.ci
                                     where lugar.nombreLugar == nombreLugar
                                     select new { TuristaNom = turista.nombreTurista };
            Console.WriteLine("Lugar:" + nombreLugar);
            foreach (var temp in listaTuristasLugar)
                Console.WriteLine(temp.TuristaNom);
        }
        //3.-Dado el nombre de un paquete, indicar que lugares son visitados en ese paquete
        static void ejr3(string nombrePaquete)
        {
            var listaLugaresPaquete = from paquete in paquetes
                                      join lugar in lugares
                                      on paquete.codigoPaquete equals lugar.codigoPaquete
                                      where paquete.nombrePaquete == nombrePaquete
                                      select new { LugarNom = lugar.nombreLugar };
            Console.WriteLine("Paquete:" + nombrePaquete);
            foreach (var temp in listaLugaresPaquete)
                Console.WriteLine(temp.LugarNom);
        }
        //4.-Dado el nombre de un turista mostrar el nombre del responsable de su tour 
        static void ejr4(string nombreTurista)
        {
            var responsableTour = from tour in tours
                                  join turista in turistas
                                  on tour.codigoTour equals turista.codigoTour
                                  where turista.nombreTurista == nombreTurista
                                  select tour.responsable;
            Console.WriteLine("Turista:" + nombreTurista + "->Responsable:" + responsableTour.First());
        }
        //5.-Mostrar los nombres de turistas junto a su responsable de tour
        static void ejr5()
        {
            var responsablesTours = from turista in turistas
                                    join tour in tours
                                    on turista.codigoTour equals tour.codigoTour
                                    orderby tour.codigoTour descending
                                    select new { TuristaNom = turista.nombreTurista, ResponsableNom = tour.responsable };
            Console.WriteLine("Turistas|Responsable");
            foreach (var temp in responsablesTours)
                Console.WriteLine("{0}\t{1}", temp.TuristaNom, temp.ResponsableNom);

        }
        //6.-Mostrar nombres de los turistas por cada lugar a visitar(arreglar)
        static void ejr6()
        {
            var lugaresTuristas = from turista in turistas
                                  join turistalugar in turista_visita on turista.ci equals turistalugar.ci
                                  join lugar in lugares on turistalugar.idLugar equals lugar.codigoLugar
                                  group turista by turistalugar.idLugar;
            foreach (var lugares in lugaresTuristas)
            {
                Console.WriteLine("Lugar:" + lugares.Key);
                foreach (var turista in lugares)
                {
                    Console.WriteLine("  " + turista.nombreTurista);
                }
            }
        }
        //7.-Cantidad de turistas que habra en cada lugar a visitar 
        static void ejr7()
        {
            var lugaresTuristas = from turista in turistas
                                  join turistalugar in turista_visita on turista.ci equals turistalugar.ci
                                  join lugar in lugares on turistalugar.idLugar equals lugar.codigoLugar
                                  group turista by lugar.nombreLugar;
            foreach (var turista in lugaresTuristas)
            {
                Console.WriteLine("Cantidad de Turistas:" + turista.Key);
                Console.WriteLine(turista.Count());
            }
        }
        //8.-Nombre de turistas agrupados por nombre de paquete
        static void ejr8()
        {
            var paqueteTuristas = from paquete in paquetes
                                  join turista in turistas
                                  on paquete.codigoPaquete equals turista.codigoPaquete
                                  group turista by paquete.nombrePaquete;
            foreach (var paquete in paqueteTuristas)
            {
                Console.WriteLine("Paquete:" + paquete.Key);
                foreach (var turista in paquete)
                {
                    Console.WriteLine("  " + turista.nombreTurista);
                }
            }
        }
        //9.-Turistas registrados en mas de un paquete
        static void ejr9()
        {
            var turistaPaquete = from turista in turistas
                                 join paquete in paquetes on turista.codigoPaquete equals paquete.codigoPaquete
                                 group turista by paquete.nombrePaquete
                                 into temp
                                 where temp.Count() > 1
                                 select temp;
                                  
                                  
            foreach (var paquete in turistaPaquete)
            {
                Console.WriteLine("Paquete:" + paquete.Key);
                foreach (var turista in paquete)
                {
                    Console.WriteLine(" " + turista.nombreTurista);
                }
            }
        }
        //10.-Mostrar la cantidad de turistas por cada tour en forma decendente
        static void ejr10()
        {
            var turistaTour = from turista in turistas
                              join tour in tours on turista.codigoTour equals tour.codigoTour
                              group turista by tour.nombreTour;
            foreach (var tour in turistaTour)
            {
                Console.WriteLine("Tour:" + tour.Key+",Cantidad de Turistas:"+tour.Count());
            }
        }
    }
}
