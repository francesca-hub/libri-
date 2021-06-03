using System;

namespace ConsoleApplibri
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbManager manager = new DbManagerConnectMode();

            Console.WriteLine("Gestione magazzino libreria!");

            Console.WriteLine("---------------Menù--------------");
            do
            {
                Console.WriteLine("Premi 1- Visualizzazione di tutti i libri");
                Console.WriteLine("Premi 2- Visualizzare tutti i libri cartacei");
                Console.WriteLine("Premi 3- Visualizzare tutti gli audiolibri");
                Console.WriteLine("Premi 4- Modificare quantità di libri cartacei in magazzino");
                Console.WriteLine("Premi 5- Modificare la durata in minuti di un audiolibro");
                Console.WriteLine("Premi 6- Inserire un nuovo libro (cartaceo/audiolibro)");
                Console.WriteLine("Premi 0- Exit");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        manager.GetAllLibri();
                        break;

                    case "2":
                        manager.GetAllLIbriCartacei();
                        break;

                    case "3":
                        manager.GetAllAudioLIbri();
                        break;

                    case "4":
                        manager.UpdateCartaceo();
                        break;

                    case "5":
                        manager.UpdateAudio();
                        break;

                    case "6":
                        manager.AddLibro();
                        break;

                    case "0":
                        return;
                }



            } while (true);
        }
    }
}
