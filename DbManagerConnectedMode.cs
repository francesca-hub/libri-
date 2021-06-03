using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplibri
{
    class DbManagerConnectMode : IDbManager
    {
        // creo collegamento al database
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;" +
            "Initial Catalog = Libri;" +
            "integrated Security=true;";

        // creo un metodo per la connessione
        public void Connessione(out SqlConnection connection, out SqlCommand cmd)
        { 
            connection = new SqlConnection(connectionString);
            //apro la connessione
            connection.Open();
            //creo il comando
            cmd = new SqlCommand();
            //gli associo la connesione 
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
        }


        public void UpdateAudio()
        {
            Connessione(out SqlConnection connection, out SqlCommand cmd);
           
            GetAllAudioLIbri();

            string isbn;
            do
            {
                Console.WriteLine("Inserisci codice ISBN dell' audiolibro da modificare");
                isbn = Console.ReadLine();
            } while (isbn.Length != 13);
            int nuovadurata;
            do
            {
                Console.WriteLine("Inserisci la nuova durata in minuti");
            } while (!int.TryParse(Console.ReadLine(), out nuovadurata));

            cmd.CommandText = "UPDATE dbo.AudioLibri set Durata= @Durata where Isbn = @Isbn ;";
            cmd.Parameters.AddWithValue("@Isbn", isbn);
            cmd.Parameters.AddWithValue("@Durata", nuovadurata);
            //eseguo la query che non mi deve tornare nulla
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCartaceo()
        {
            
            Connessione(out SqlConnection connection, out SqlCommand cmd);
            
            GetAllLIbriCartacei();

            
            string isbn;
            do
            {
                Console.WriteLine("Inserisci CODICE ISBN del libro da modificare");
                isbn = Console.ReadLine();
            } while (isbn.Length != 13);
            int nuovaqnt;
            do
            {
                Console.WriteLine("Inserisci nuova quantità");
            } while (!int.TryParse(Console.ReadLine(), out nuovaqnt));

            cmd.CommandText = "update dbo.LibriCartacei set Quantita = @Quantita where Isbn = @Isbn ;";
            cmd.Parameters.AddWithValue("@Isbn", isbn);
            cmd.Parameters.AddWithValue("@Quantita", nuovaqnt);
            
            cmd.ExecuteNonQuery();
            connection.Close();
        }

      public  void GetAllLibri()
        {
           
            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select * from dbo.AudioLibri;";
            //eseguo il comando
            SqlDataReader reader = cmd.ExecuteReader();
            //tramite il ciclo leggo le righe e creo Audio
            Console.WriteLine("Audiolibri:");
            while (reader.Read())
            {
                var id = reader[0];
                var titolo = reader[1];
                var autore = reader[2];
                var isbn = reader[3];
                ; var durata = reader[4];
                Console.WriteLine($"{id} - {titolo} - {autore} - ISBN: {isbn} - {durata} minuti \n");
            }
            
            connection.Close();

            //riapro la connessione 
            
            Connessione(out SqlConnection connessione, out SqlCommand command);
            command.CommandText = " select  * from dbo.LibriCartacei ;";
            SqlDataReader reader1 = command.ExecuteReader();
            Console.WriteLine("Libri cartacei:");
            while (reader1.Read())
            {
                var id = reader1[0];
                var titolo = reader1[1];
                var autore =reader1[2];
                var isbn = reader1[3];
                var pagine = reader1[4];
                var quanita = reader1[5];
                Console.WriteLine($"{id} - Titolo:{titolo} - Autore:{autore} - ISBN: {isbn} -Pag: {pagine}- Quantità: {quanita} \n");
            }
          
            connessione.Close();
        }

      public  void GetAllLIbriCartacei()
        {

            Connessione(out SqlConnection connessione, out SqlCommand command);
            command.CommandText = " SELECT  * from dbo.LibriCartacei ;";
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Libri cartacei:");
            while (reader.Read())
            {
                var id = reader[0];
                var titolo = reader[1];
                var autore =reader[2];
                var isbn = reader[3];
                var pagine = reader[4];
                var quanita = reader[5];
                Console.WriteLine($"{id} - {titolo} - {autore} - ISBN: {isbn} - PAG. {pagine}. Magazzino {quanita} \n");
            }
           
            connessione.Close();
        }

       public void GetAllAudioLIbri()
        {
           
            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "SELECT  * from dbo.AudioLibri;";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Audiolibri:");
            while (reader.Read())
            {
                var id = reader[0];
                var titolo = reader[1];
                var autore = reader[2];
                var isbn = reader[3];
                ; var durata = reader[4];
                Console.WriteLine($"{id} - {titolo} - {autore} - ISBN: {isbn} - {durata} minuti \n");
            }
          
            connection.Close();
        }

        public void CercaLibro()
        {
            Console.WriteLine("Inserire titolo cercato");
            string titolo = Console.ReadLine();

            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select * from dbo.AudioLibri where Titolo = @Titolo;";
            cmd.Parameters.AddWithValue("@Titolo", titolo);
           
            SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader[0];
                    var titolo1 = reader[1];
                    var autore = reader[2];
                    var isbn = reader[3];
                    ; var durata = reader[4];
                    Console.WriteLine($"{id} - {titolo1} - {autore} - ISBN: {isbn} - {durata} minuti \n");
                }
            
      
            connection.Close();

       
            // riapro la connessione 
            Connessione(out SqlConnection connessione, out SqlCommand command);
            command.CommandText = "SELECT * from dbo.LibriCartacei where Titolo = @Titolo;";
            command.Parameters.AddWithValue("@Titolo", titolo);

            SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    var id = reader1[0];
                    var titoloC = reader1[1];
                    var autore = reader1[2];
                    var isbn = reader1[3];
                    var pagine = reader1[4];
                    var quanita = reader1[5];
                    Console.WriteLine($"{id} -Titolo: {titoloC} - Autore:{autore} - ISBN: {isbn} - Pag: {pagine}- Quantità: {quanita} \n");
                }
          
            connessione.Close();
        }

       public void AddLibro()
        {
       
            Connessione(out SqlConnection connection, out SqlCommand cmd);

            Console.WriteLine("Inserisci Titolo nuovo libro ");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci Autore ");
            string autore = Console.ReadLine();
            string isbn;
            do
            {
                Console.WriteLine("Inserisci Codice ISBN ");
                isbn = Console.ReadLine();
            } while (isbn.Length != 13);

           //dovrei controllare che il libro non sia già inserito
                Console.WriteLine("Inserire un nuovo libro cartaceo? Inserire SI/NO");
                string scelta = Console.ReadLine();
                if (scelta.ToUpper() == "N0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Inserisci numero pagine del libro ");
                    int numeroPagine = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci numero disponibile in magazzino ");
                    int quantitaInMagazzino = int.Parse(Console.ReadLine());

                    
                    cmd.CommandText = "insert into dbo.LibriCartacei values (@Titolo,@Autore, @Isbn, @NumPag, @NQuantita)";
                    cmd.Parameters.AddWithValue("@Titolo", titolo);
                    cmd.Parameters.AddWithValue("@Autore", autore);
                    cmd.Parameters.AddWithValue("@Isbn", isbn);
                    cmd.Parameters.AddWithValue("@NunPag", numeroPagine);
                    cmd.Parameters.AddWithValue("@Quantita", quantitaInMagazzino);
                  
                    cmd.ExecuteNonQuery();
                 
                    connection.Close();
                }
            
           
                Console.WriteLine("Inserire un Audiolibro? Inserire SI/NO");
                string scelta2 = Console.ReadLine();
                if (scelta2.ToUpper() == "NO")
                {
                    return;
                }
                else
                {
                   
                    Console.WriteLine("Inserisci durata in minuti del libro ");
                    int durata = int.Parse(Console.ReadLine());
                  
                    cmd.CommandText = "insert into dbo.AudioLibri values (@Titolo,@Autore, @Isbn,@Durata)";
                    cmd.Parameters.AddWithValue("@Titolo", titolo);
                    cmd.Parameters.AddWithValue("@Autore", autore);
                    cmd.Parameters.AddWithValue("@Isbn", isbn);
                    cmd.Parameters.AddWithValue("@Durata", durata);
                 
                    cmd.ExecuteNonQuery();
                   
                    connection.Close();
                }
            }
           
    }
}