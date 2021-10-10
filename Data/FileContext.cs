using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using Assignment1.Models;


namespace Assignment1.Data
{
    public class FileContext : IAdultData
    {
       
        public IList<Adult> Adults { get; private set; }
        
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public void AddAdults(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            WritePersonsToFile();
        }

        public IList<Adult> GetAdults()
        {
            IList<Adult> amp = new List<Adult>(Adults);
            return amp;
        }

        public void RemoveAdult(int AdultId)
        {
            Adult toRemove = Adults.First(t => t.Id == AdultId);
            Adults.Remove(toRemove);
            WritePersonsToFile();
        }

        private void WritePersonsToFile()
        {
            string PersonAsJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, PersonAsJson);
        }


    }
}