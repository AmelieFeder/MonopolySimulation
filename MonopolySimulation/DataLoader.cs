using System;
using System.Collections.Generic;
using System.IO;
using Monopoly_Simulation.Model;
using Newtonsoft.Json;

namespace Monopoly_Simulation
{
    public static class DataLoader
    {
        public static IEnumerable<Space> LoadSpaces()
        {
            return LoadSpaces(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "Spaces.json"));
        }

        public static IEnumerable<Card> LoadRedCards()
        {
            return LoadCards(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "redCards.json"));
        }
        
        public static IEnumerable<Card> LoadGreenCards()
        {
            return LoadCards(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "greenCards.json"));
        }
        
        private static IEnumerable<Space> LoadSpaces(string filePath)
        {
            return Load<Space>(filePath);
        }

        private static IEnumerable<Card> LoadCards(string filePath)
        {
            return Load<Card>(filePath);
        }

        private static IEnumerable<T> Load<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            IEnumerable<T> tEnumerable = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return tEnumerable;
        }
    }
}