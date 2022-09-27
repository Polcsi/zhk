using System;

namespace House
{
    class Healthy : Residential
    {
        public DateTime? TestDate { get; set; }
        public Healthy(string name, Gender sex,  DateTime birthDate, string phone, DateTime? testDate)
            :base(name, sex, birthDate, phone)
        {
            TestDate = testDate;
        }
        public override bool isTested()
        {
            return TestDate != null;
        }
        public override string ToString()
        {
            return string.Format($"{Name};({Sex});{BirthDate};{Phone};{TestDate}");
        }
    }
}
