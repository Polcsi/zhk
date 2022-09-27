using System;
using System.Collections.Generic;
using House.Helper;
using System.IO;

namespace House
{
    internal class Program
    {
        public static void listToConsole<T>(List<T> residentals) where T : Residential
        {
            foreach (T residental in residentals)
            {
                Console.WriteLine(residental.ToString());
            }
        }
        public static void writeToFile<T>(List<T> residentals, StreamWriter fs) where T : Residential
        {
            foreach (T residental in residentals)
            {
                fs.WriteLine(residental.ToString());
            }
        }
        static void Main(string[] args)
        {
            List<Infected> infectedList = new List<Infected>();
            List<Healthy> healthyList = new List<Healthy>();
            RandomResidental randomResidental = new RandomResidental();

            for (int i = 0; i < 31; ++i)
            {
                Residential residental = randomResidental.generateResidental();
                if(residental is Infected infected)
                {
                    infectedList.Add(infected);
                }
                if(residental is Healthy healthy)
                {
                    healthyList.Add(healthy);
                }
            }
            Console.WriteLine("HEALTHY");
            listToConsole(healthyList);
            Console.WriteLine("INFECTED");
            listToConsole(infectedList);
            
            using(StreamWriter fs = new StreamWriter("healthy.txt", false))
            {
                writeToFile(healthyList, fs);
            }
            using (StreamWriter fs = new StreamWriter("infected.txt", false))
            {
                writeToFile(infectedList, fs);
            }
        }
    }
}
