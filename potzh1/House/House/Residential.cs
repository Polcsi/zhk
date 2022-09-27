using System;

namespace House
{
    public enum Gender { Female, Male };
    abstract class Residential : ICrown
    {
        protected DateTime BirthDate { get; set; }
        protected string Name { get; set; }
        protected string Phone { get; set; }
        protected Gender Sex { get; set; }
        protected Residential(string name, Gender sex, DateTime birthDate, string phone)
        {
            Name = name;
            BirthDate = birthDate;
            Phone = phone;
            Sex = sex;
        }
        public virtual bool isInQuarantine()
        {
            return false;
        }
        public abstract bool isTested();
        public virtual string ToString() => string.Format($"{Name};({Sex});{BirthDate};{Phone}");
    }
}
