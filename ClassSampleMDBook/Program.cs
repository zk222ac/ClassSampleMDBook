using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClassSampleMDBook
{
    class Program
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "DbBook";
        public static IMongoCollection<BsonDocument> Collections { get; set; }

        static void Main(string[] args)
        {
            Collections = MongoDbCollection();

            // Task no 1 : Inserting new document 
            // InsertNewDocumentInBook(); //--> Enable or Disable 

            // Task no 2 : Inserting multiple document 
             //InsertMultipleDocumentInBook(); //--> Enable or Disable 

            // Task no 3 : count documents
             //var count = Collections.Count(new BsonDocument());
             //Console.WriteLine($"Total Documents is :" + count);

            // Task no 4 : Return only first Document
            //ReturnFirstDocumentOnly();

            // Task no 5 : Return only first Document
            IterativelyProcessDocument();

            Console.ReadKey();
        }
      


        private static IMongoCollection<BsonDocument> MongoDbCollection()
        {
            // client establish a  connection with server via connection string
            var client = new MongoClient(ConnectionString);

            // Define a server database 
            var database = client.GetDatabase(DatabaseName);

            // Get collection --> Get data collection Book from Mongo db
            var collection = database.GetCollection<BsonDocument>("Book");

            return collection;
        }

        public static async void InsertNewDocumentInBook()
        {
            var doc = new BsonDocument()
           {
               { "name", "MongoDB"},
               { "type", "Database"},
               {"count" , 1 },
               {"info", new BsonDocument{{"x",203}, { "y",102}}},
               { "Task" , "Mandatory Assignment"}
           };

            await Collections.InsertOneAsync(doc);
        }

        public static async void InsertMultipleDocumentInBook()
        {
            // generate 100 documents with a counter ranging from 0 - 99
            var doc = Enumerable.Range(0, 5).Select(i => new BsonDocument
            {
                { "name1", "name1"},
                { "type", "type"},
                {"counter" , 1 },
                {"info", new BsonDocument{{"x",203}, { "y",102}}}
            });

            await Collections.InsertManyAsync(doc);
        }


        public static async void ReturnFirstDocumentOnly()
        {
            var doc = await Collections.Find(new BsonDocument()).FirstOrDefaultAsync();
            Console.WriteLine(doc);
        }
        public static async void IterativelyProcessDocument()
        {
           await Collections.Find(new BsonDocument()).ForEachAsync(d => Console.WriteLine(d));
        }


    }
}
