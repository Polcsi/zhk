using System;
using System.Collections.Generic;
using HospitalApp.Helper;
using System.IO;

namespace HospitalApp
{
    class Program
    {
        static void listToConsole<T>(List<T> persons) where T : Person
        {
            foreach (T person in persons)
            {
                Console.WriteLine(person);
            }
        }
        static void writeToFile<T>(List<T> persons, string filename) where T : Person
        {
            using(StreamWriter fs = new StreamWriter($"{filename}.txt", false))
            {
                foreach (T person in persons)
                {
                    fs.WriteLine(person.ToString());
                }
            }
        }
        static void Main(string[] args)
        {
            List<Patient> patientsList = new List<Patient>();
            List<Doctor> doctorsList = new List<Doctor>();

            Random rnd = new Random();
            RandomPerson randomPerson = new RandomPerson();
            for (int i = 0; i < rnd.Next(100, 200); ++i)
            {
                
                Person person = randomPerson.generatePerson();
                if(person is Doctor doctor)
                {
                    doctorsList.Add(doctor);
                }
                if(person is Patient patient)
                {
                    patientsList.Add(patient);
                }
            }
            Console.WriteLine("DOCTORS");
            listToConsole(doctorsList);
            Console.WriteLine("PATIENTS");
            listToConsole(patientsList);

            writeToFile(doctorsList, "doctors");
            writeToFile(patientsList, "patients");

            Console.ReadKey();
        }
    }
}
