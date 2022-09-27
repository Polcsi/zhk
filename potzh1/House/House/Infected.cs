using System;

namespace House
{
    class Infected : Residential
    {
        public bool Symptom { get; set; }
        public Infected(string name, Gender sex, DateTime birthDate, string phone, bool symptom)
            :base(name, sex, birthDate, phone)
        {
            Symptom = symptom;
        }
        public override bool isInQuarantine()
        {
            return true;
        }
        public override bool isTested()
        {
            return true;
        }
        public override string ToString()
        {
            return string.Format($"{Name};({Sex});{BirthDate};{Phone};{Symptom}");
        }
    }
}
