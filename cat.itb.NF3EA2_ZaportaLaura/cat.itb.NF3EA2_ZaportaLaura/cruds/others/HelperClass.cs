using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using EA1.connections;
using System.Text;


namespace cat.itb.NF3EA2_ZaportaLaura.cruds.others
{
    public class HelperClass : Database
    {
        public static void LoadCollectionArray<T>(string collectionName, string typeOfObject)
        {
            FileInfo file = new FileInfo($"../../../files/{collectionName}.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(fileString);

            _database.DropCollection(collectionName);
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            if (objects != null)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    Console.WriteLine($"\n {typeOfObject}: {i + 1}");
                    string json = JsonConvert.SerializeObject(objects[i]);
                    var document = new BsonDocument();
                    document.AddRange(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
            }
        }
        public static void LoadCollection<T>(string collectionName, string typeOfObject)
        {
            FileInfo file = new FileInfo($"../../../files/{collectionName}.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();

            List<T> objects = new List<T>();
            foreach (var line in File.ReadLines(file.FullName))
            {
                var obj = JsonConvert.DeserializeObject<T>(line);
                if (obj != null)
                {
                    objects.Add(obj);
                }
            }

            _database.DropCollection(collectionName);
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            if (objects != null)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    Console.WriteLine($"\n {typeOfObject}: {i + 1}");
                    string json = JsonConvert.SerializeObject(objects[i]);
                    var document = new BsonDocument();
                    document.AddRange(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
            }
        }
    }
}