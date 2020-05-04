using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var settings = new MongoClientSettings
                {
                    ServerSelectionTimeout = new TimeSpan(0, 0, 5),
                    Server = new MongoServerAddress("localhost", 27017),
                    Credentials = new[]{
                        MongoCredential.CreateCredential("loja", "joel", "xyz123")
                    }
                };

                var client = new MongoClient(settings);

                var database = client.GetDatabase("loja");

                var colecao = database.GetCollection<Cliente>("clientes");

                var cliente = new Cliente
                {
                    Nome = "Antonio Pereira",
                    Email = "antonio@email.com",
                    Telefone = "99999-8888"
                };

                colecao.InsertOne(cliente);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}