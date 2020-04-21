using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.Json;

namespace PasswordManager
{
    public class PassStore
    {
        private List<Site> store = new List<Site>();
        
        public PassStore()
        { }
        public List<Site> GetSites()
        {
            return store;
        }
        public void LoadCSV()
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(@"C:\Users\finne\source\repos\SamplePasses.csv")), true))
            {
                csvTable.Load(csvReader);
            }
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                store.Add(new Site
                {
                    URL = csvTable.Rows[i][0].ToString(),
                    Username = csvTable.Rows[i][1].ToString(),
                    Password = csvTable.Rows[i][2].ToString(),
                    Extra = csvTable.Rows[i][3].ToString(),
                    Name = csvTable.Rows[i][4].ToString(),
                    Grouping = csvTable.Rows[i][5].ToString(),
                    Fav = csvTable.Rows[i][6].ToString(),
                });
            }
        }
        public void LoadSites()
        {
            string serialized = File.ReadAllText(@"C:\Users\finne\source\repos\data.txt");
            string decrypted = AesOp.DecryptString(serialized, "thisisthepassword");
            store = JsonSerializer.Deserialize<List<Site>>(decrypted);
        }
        public void Save()
        {
            string serialized = JsonSerializer.Serialize(store);
            string encrypted = AesOp.EncryptString(serialized, "thisisthepassword");
            File.WriteAllText(@"C:\Users\finne\source\repos\data.txt", encrypted);
        }
    }
}
