using System;
using System.Collections.Generic;

namespace Hospital.Helper
{
    class RandomPerson
    {
        private string[] firstNamesFemale = { "Alison", "Maria", "Sophie", "Alexandra" },
            firstNamesMale = { "Jonathan ", "Gordon", "Brandon", "Peter" },
            lastNames = { "Ellison", "Campbell", "Johnston", "Abraham" },
            sickness = { "Flu", "Bronchitis", "Neuroblastoma", "Headaches", "Diabetes", "Cough" },
            specialities = { "Pediatric Gastroenterology", "Psychiatry", "Infectious Disease", "Child Neurology", "Neuropathology" };
        private Random md = new Random();
        private DateTime generateBirthDate()
        {
            DateTime start = new DateTime(1900, 01, 01);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(md.Next(range));
        }
        private string generateElementOf(string[] strArray)
        {
            return strArray[md.Next(0, strArray.Length)];
        }
        private Gender generateGender()
        {
            return md.Next(0, 2) == 1 ? Gender.Male : Gender.Female;
        }
        private PersonType generatePersonType()
        {
            return md.Next(0, 2) == 1 ? PersonType.Patient : PersonType.Doctor;
        }
        private string generatePhoneNumber()
        {
            Phone randomPhoneNumber = new Phone()
            {
                CountryCode = md.Next(0, 100),
                ProviderCode = md.Next(0, 100),
                FirstPart = md.Next(100, 1000),
                SecondPart = md.Next(100, 1000),
            };

            return ConvertPhoneNumber.toHungarianFormat(randomPhoneNumber);
        }
        private List<string> generateSpeciality()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < md.Next(1, 6); i++)
            {
                list.Add(generateElementOf(specialities));
            }

            return list;
        }
        public Person generatePerson()
        {
            Person person;
            Gender gender = generateGender();
            PersonType personType = generatePersonType();
            string firstName = generateElementOf(gender == Gender.Male ? firstNamesMale : firstNamesFemale);
            string lastName = generateElementOf(lastNames);

            if(personType == PersonType.Patient)
            {
                person = new Patient(personType, gender, firstName, lastName, generateBirthDate(), generatePhoneNumber(), generateElementOf(sickness));
            } else
            {
                person = new Doctor(personType, gender, firstName, lastName, generateBirthDate(), generatePhoneNumber(), generateSpeciality());
            }

            return person;
        }
    }
}
