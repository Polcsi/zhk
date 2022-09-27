using System;
using System.Collections.Generic;

namespace HospitalApp.Helper
{
    class RandomPerson
    {
        private string[] firstNamesMale = { "Jonathan", "Gordon", "David", "Peter" },
            firstNamesFemale = { "Sophie", "Alison", "Maria", "Alexandra" },
            lastNames = { "Ellison", "Campbell", "Johnston", "Abraham" },
            sickness = { "Flu", "Bronchitis", "Neuroblastoma", "Diabetes", "Headaches" },
            specialities = { "Child Neurology", "Pediatric Gastroenterology", "Psychiatry", "Infectious Disease" };
        private Random md = new Random();
        private DateTime generateBirthDate()
        {
            DateTime start = new DateTime(1922, 01, 01);
            int range = (DateTime.Today- start).Days;
            return start.AddDays(md.Next(range));
        }
        private string generateElementOf(string[] strArray)
        {
            return strArray[md.Next(0, strArray.Length)];
        }
        private Gender generateGender()
        {
            return md.Next(0, 2) == 1 ? Gender.FeMale : Gender.Male;
        }
        private PersonType generatePersonType()
        {
            return md.Next(0, 2) == 1 ? PersonType.Doctor : PersonType.Patient;
        }
        private string generatePhoneNumber(Phone phoneNumber)
        {
            return ConvertPhoneNumber.toHungarianFormat(phoneNumber);
        }
        private List<string> generateSpeciality()
        {
            List<string> specialitiesList = new List<string>();
            for (int i = 0; i < md.Next(1, 6); ++i)
            {
                specialitiesList.Add(generateElementOf(specialities));
            }

            return specialitiesList;
        }
        public Person generatePerson()
        {
            Person person;
            Gender gender = generateGender();
            PersonType personType = generatePersonType();
            Phone phone = new Phone()
            {
                CountryCode = md.Next(0, 100),
                ProviderCode = md.Next(0, 100),
                FirstPart = md.Next(100, 1000),
                SecondPart = md.Next(100, 1000),
            };
            string firstName = generateElementOf(gender == Gender.FeMale ? firstNamesFemale : firstNamesMale);
            string lastName = generateElementOf(lastNames);

            if(personType == PersonType.Doctor)
            {
                person = new Doctor(personType, gender, firstName, lastName, generateBirthDate(),generatePhoneNumber(phone), generateSpeciality());
            } else
            {
                person = new Patient(personType, gender, firstName, lastName, generateBirthDate(), generatePhoneNumber(phone), generateElementOf(sickness));
            }


            return person;
        }
    }
}
