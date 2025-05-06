using cat.itb.NF3EA4_ZaportaLaura.cruds.others;
using Newtonsoft.Json;

namespace cat.itb.NF3EA4_CognomNom.cruds
{
    public class GeneralCRUD : Database
    {
        public static void LoadObjectArrayCollection<T>(string collectionName, string collectionObject)
        {
            FileInfo file = new FileInfo($"../../../files/{collectionName}.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<T> objList = JsonConvert.DeserializeObject<List<T>>(fileString);

            _database.DropCollection(collectionName);

            var collection = _database.GetCollection<T>(collectionName);

            if (objList != null) {
                for (int i = 0; i < objList.Count; i++)
                {
                    Console.WriteLine($"\n {collectionObject}: {i}");
                    collection.InsertOne(objList[i]);
                }
            }
        }
        public static void LoadObjectCollection<T>(string collectionName, string collectionObject)
        {
            _database.DropCollection(collectionName);
            var collection = _database.GetCollection<T>(collectionName);

            FileInfo file = new FileInfo($"../../../files/{collectionName}.json");

            using (StreamReader sr = file.OpenText())
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    T obj = JsonConvert.DeserializeObject<T>(line);
                    Console.WriteLine($"\n {collectionObject}: {i}");
                    collection.InsertOne(obj);
                    i++;
                }
            }
        }
    }
}
