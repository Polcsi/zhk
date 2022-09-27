using System;
using System.Collections.Generic;
using System.IO;
using Hospital.Helper;

namespace Hospital
{
    class Program
    {
        static public void listToConsole<T>(List<T> people) where T : Person
        {
            foreach (T person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        static public void writeToFile<T>(List<T> people, StreamWriter file) where T : Person
        {
            foreach (T person in people)
            {
                file.WriteLine(person.ToString());
            }
        }
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            List<Doctor> doctors = new List<Doctor>();
            RandomPerson randomPerson = new RandomPerson();

            for (int i = 0; i < 101; ++i)
            {
                Person person = randomPerson.generatePerson();
                if(person is Patient patient)
                {
                    patients.Add(patient);
                }
                if(person is Doctor doctor)
                {
                    doctors.Add(doctor);   
                }
            }
            Console.WriteLine("PATIENTS");
            listToConsole(patients);
            Console.WriteLine("DOCTORS");
            listToConsole(doctors);
            using(StreamWriter fs = new StreamWriter("patients.txt", true))
            {
                writeToFile(patients, fs);
            }
            using(StreamWriter fs = new StreamWriter("doctors.txt", true))
            {
                writeToFile(doctors, fs);
            }
        }
    }
}
