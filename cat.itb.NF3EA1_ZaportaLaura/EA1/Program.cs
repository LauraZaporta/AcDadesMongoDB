using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using EA1.connections;
using EA1.model.productsCollection;
using EA1.model.booksCollection;
using EA1.model.peopleCollection;
using EA1.model.countriesCollection;
using EA1.model.restaurantsCollection;
using EA1.model.studentsCollection;
using EA1.model.gradesBD;

namespace UF3_test
{
    internal class Program
    {
        public static void Main()
        {
            const string selectOption = "\n Opció seleccionada: ";
            const string menu = "\n MENÚ DE SELECCIÓ D'EXERCICIS" +
                "\n ---------------------------------" +
                "\n [1] - InsertThreeStudents() - Inserir tres estudiants" +
                "\n [2] - SelectAllStudents() - Mostrar tots els estudiants" +
                "\n [3] - SelectStudentsExam90() - Mostrar els estudiants amb nota 90 a un examen" +
                "\n [4] - SelectStudentExamAbove99() - Mostrar els estudiants amb més d'un 99 a un examen" +
                "\n [5] - SelectInterests() - Mostrar els interessos de l'estudiant 888666333" +
                "\n [6] - SelectNameAndSurname() - Mostra el nom i els cognoms de l'estudiant 444777888" +
                "\n [7] - ImportToITB() - Importa a la base de dades itb els fitxers de la carpeta files" +
                "\n [0] - Sortir del programa";

            bool exit = false;
            string menuOption = string.Empty;

            while (!exit)
            {
                Console.WriteLine(menu);
                Console.Write(selectOption);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        InsertThreeStudents();
                        break;
                    case "2":
                        SelectAllStudents();
                        break;
                    case "3":
                        SelectStudentsExam90();
                        break;
                    case "4":
                        SelectStudentExamAbove99();
                        break;
                    case "5":
                        SelectInterests(888666333);
                        break;
                    case "6":
                        SelectNameAndSurname(444777888);
                        break;
                    case "7":
                        ImportToITB(ref exit);
                        break;
                    default:
                        Console.WriteLine("\n Aquesta opció no és vàlida!");
                        break;
                }
            }
        }

        private static void GetAllDBs()
        {
            var dbClient = MongoLocalConnection.GetMongoClient();
            
            var dbList = dbClient.ListDatabases().ToList();
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

        }

        private static void GetCollections()
        {
            
            var database = MongoLocalConnection.GetDatabase("sample_training");

            var colList = database.ListCollections().ToList();
            Console.WriteLine("The list of collection on this database is: ");
            foreach (var col in colList)
            {
                Console.WriteLine(col);
            }
        }

        private static void SelectAllStudents()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var studentDocuments = collection.Find(new BsonDocument()).ToList();

            foreach (var student in studentDocuments)
            {
                Console.WriteLine($"\n{student.ToString()}");
            }
        }

        private static void InsertThreeStudents()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            List<BsonDocument> documents = new List<BsonDocument>();

            var documentOne = new BsonDocument
            {
                { "student_id", 222333999 },
                { "name", "Laura" },
                { "surname", "Zaporta Poblet" },
                { "class_id", "555" },
                { "group", "DAMv1" },
                { "scores", new BsonArray
                    {
                        new BsonDocument{ {"type", "exam"}, {"score", 100 } },
                        new BsonDocument{ {"type", "teamWork"}, {"score", 50 } }
                    }
                },
            };
            var documentTwo = new BsonDocument
            {
                { "student_id", 444777888 },
                { "name", "Álvaro" },
                { "surname", "Manzano" },
                { "class_id", "555" },
                { "group", "DAMv1" },
                { "interests", new BsonArray
                    {
                        {"music"},
                        {"gym"},
                        {"code"},
                        {"electronics"}
                    }
                }
            };
            var documentThree = new BsonDocument
            {
                { "student_id", 888666333 },
                { "name", "Eudald" },
                { "surname", "Castillo" },
                { "class_id", "555" },
                { "group", "DAMv1" },
                { "interests", new BsonArray
                    {
                        {"rap"},
                        {"runner"},
                        {"movies"},
                        {"comic"}
                    }
                },
                { "scores", new BsonArray
                    {
                        new BsonDocument{ {"type", "exam"}, {"score", 90 } },
                        new BsonDocument{ {"type", "teamWork"}, {"score", 60 } },
                        new BsonDocument{ {"type", "quiz"}, {"score", 96 } },
                        new BsonDocument{ {"type", "homework"}, {"score", 23 } }
                    }
                }
            };
            documents.Add(documentOne);
            documents.Add(documentTwo);
            documents.Add(documentThree);

            try
            {
                collection.InsertMany(documents);
                Console.WriteLine("\n Documents inserits correctament");
            }
            catch (MongoWriteException e)
            {
                Console.WriteLine($"Insert error: {e.Message}");
            }
        }

        private static void SelectStudentsExam90()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var filter = Builders<BsonDocument>.Filter.ElemMatch("scores",
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("type", "exam"),
                    Builders<BsonDocument>.Filter.Eq("score", 90)
                    )
                );
            var studentDocument = collection.Find(filter).ToList();
            foreach (var student in studentDocument)
            {
                Console.WriteLine($"\n{student.ToString()}");
            }
        }

        private static void SelectStudentExamAbove99()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var filter = Builders<BsonDocument>.Filter.ElemMatch("scores",
                Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("type", "exam"),
                    Builders<BsonDocument>.Filter.Gt("score", 99)
                    )
                );
            var studentDocument = collection.Find(filter).ToList();
            foreach (var student in studentDocument)
            {
                Console.WriteLine($"\n{student.ToString()}");
            }
        }


        private static void SelectInterests(int id)
        {
            
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var filter = Builders<BsonDocument>.Filter.Eq("student_id", id);
            var studentDocument = collection.Find(filter).FirstOrDefault();
            var interests = studentDocument.GetElement("interests");

            Console.WriteLine(interests.ToString());
        }

        private static void SelectNameAndSurname(int id)
        {

            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            var filter = Builders<BsonDocument>.Filter.Eq("student_id", id);
            var studentDocument = collection.Find(filter).FirstOrDefault();
            var name = studentDocument.GetElement("name");
            var surname = studentDocument.GetElement("surname");

            Console.WriteLine($"{name.ToString()} | {surname.ToString()}");
        }

        private static void ImportToITB(ref bool exit)
        {
            const string menuImports = "\n MENÚ DE SELECCIÓ D'IMPORTS" +
                "\n ---------------------------------" +
                "\n [1] - Books" +
                "\n [2] - Countries" +
                "\n [3] - Grades" +
                "\n [4] - People" +
                "\n [5] - Products" +
                "\n [6] - Restaurants" +
                "\n [7] - Students" +
                "\n [0] - Sortir del programa";
            const string selectOption = "\n Opció seleccionada: ";

            string menuOption = string.Empty;

            while (!exit)
            {
                Console.WriteLine(menuImports);
                Console.Write(selectOption);
                menuOption = Console.ReadLine();
                try
                {
                    switch (menuOption)
                    {
                        case "1":
                            LoadCollectionArray<Book>("books", "Book");
                            break;
                        case "2":
                            LoadCollectionArray<Country>("countries", "Country");
                            break;
                        case "3":
                            LoadCollection<EA1.model.gradesBD.Grade>("grades", "Grade");
                            break;
                        case "4":
                            LoadCollectionArray<Person>("people", "Person");
                            break;
                        case "5":
                            LoadCollection<Product>("products", "Product");
                            break;
                        case "6":
                            LoadCollection<Restaurant>("restaurants", "Restaurant");
                            break;
                        case "7":
                            LoadCollection<Student>("students", "student");
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n Aquesta opció no és vàlida!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n ERROR: {e.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        private static void LoadCollectionArray<T>(string collectionName, string typeOfObject)
        {
            FileInfo file = new FileInfo($"../../../files/{collectionName}.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(fileString);

            var database = MongoLocalConnection.GetDatabase("itb");
            database.DropCollection(collectionName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            if (objects != null)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    Console.WriteLine($"\n {typeOfObject}: {i+1}");
                    string json = JsonConvert.SerializeObject(objects[i]);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
            }
        }
        private static void LoadCollection<T>(string collectionName, string typeOfObject)
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

            var database = MongoLocalConnection.GetDatabase("itb");
            database.DropCollection(collectionName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            if (objects != null)
            {
                for (int i = 0; i < objects.Count(); i++)
                {
                    Console.WriteLine($"\n {typeOfObject}: {i + 1}");
                    string json = JsonConvert.SerializeObject(objects[i]);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
            }
        }
    }
}