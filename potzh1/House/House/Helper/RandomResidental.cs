using System;

namespace House.Helper
{
    class RandomResidental
    {
        private string[] firstNamesFemale = { "Alexandra", "Alison", "Sophie", "Wanda" },
            firstNamesMale = { "Brandon", "Gordon", "Jonathan", "David" },
            lastNames = { "Campbell", "Johnston", "Henderson", "Abraham" };
        private Random md = new Random();
        private string generate(string[] strArray)
        {
            return strArray[md.Next(0, strArray.Length)];
        }
        private DateTime generateBirthDate()
        {
            DateTime start = new DateTime(1922, 01, 01);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(md.Next(range));
        }
        private Gender generateGender()
        {
            return md.Next(0, 2) == 1 ? Gender.Male : Gender.Female;
        }
        private string generatePhones()
        {
            Phone phone = new Phone()
            {
                CountryCode = md.Next(0, 100),
                ProviderCode = md.Next(0, 100),
                FirstPart = md.Next(0, 1000),
                SecondPart = md.Next(0, 1000),
            };

            return ConvertPhoneNumber.toHungarianFormat(phone);
        }
        private bool generateResidentalType()
        {
            return md.Next(0, 2) == 1;
        }
        private DateTime? generateTesthDate(DateTime birthDate)
        {
            if(md.Next(0, 2) == 1)
            {
                DateTime start = birthDate;
                int range = (DateTime.Today - start).Days;
                return start.AddDays(md.Next(range));
            } else
            {
                return null;
            }
        }
        public Residential generateResidental()
        {
            Residential residental;
            Gender gender = generateGender();
            string firstName = generate(gender == Gender.Male ? firstNamesMale : firstNamesFemale);
            string lastName = generate(lastNames);
            DateTime birth = generateBirthDate();

            if(generateResidentalType())
            {
                residental = new Healthy($"{firstName} {lastName}", gender, birth, generatePhones(), generateTesthDate(birth));
            } else
            {
                residental = new Infected($"{firstName} {lastName}", gender, birth, generatePhones(), md.Next(0, 2) == 1 ? true : false);
            }

            return residental;
        }
    }
}
