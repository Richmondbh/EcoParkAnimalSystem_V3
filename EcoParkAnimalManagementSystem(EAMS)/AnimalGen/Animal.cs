using EcoParkAnimalManagementSystem_EAMS_.Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace EcoParkAnimalManagementSystem_EAMS_.AnimalGen
{
    // Abstract base class for all animals in the EcoPark system.


    public abstract class Animal: IAnimal
    {

        // Backing fields  for only properties that needs validation
        private int age;
        private double weight;
        private int sleepTimeHours;
        // Auto-properties for those with no validation needed
        public string Id { get;  set; }
        public string Name { get; set; } = "Unknown";
        public GenderType Gender { get; set; } = GenderType.Unknown;
        public string ImagePath { get; set; } = string.Empty;
        public CategoryType Category { get; protected set; }


        public int Age
        {
            get { return age; }
            set
            {
                //Program must not crash
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                // Program must not crash
                if (value >= 0)
                {
                    weight = value;
                }
            }
        }
        public int SleepTimeHours
        {
            get { return sleepTimeHours; }
            protected set
            {
                if (value >= 0 && value <= 24)
                {
                    sleepTimeHours = value;
                }
            }
        }

        // Initializes a new instance of the Animal class with default values.
        protected Animal()
        {
         
            Name = "Unknown";
            Age = 0;
            Gender = GenderType.Unknown;
            sleepTimeHours = 0;
        }

        // Initializes a new instance of the Animal class with specified values.
        protected Animal(string name, int age, GenderType gender) : this()
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual void SetSleepTime()
        {
            sleepTimeHours = 0;
        }

        public abstract int GetAverageLifeSpan();

        public abstract Dictionary<string, string> DailyFoodRequirement();

        public abstract Queue<string> GetUpcomingEvents();

        public virtual string ToStringSummary()
        {
            return $"{Id,-8} {Name,-15} {Age,3} yrs  {Gender,-8}";
        }

        // I created a stanadard method to update the UI, directly accesing the values
        // so I removed all the Tostring() methods from the sub classes.
        public override string ToString()
        {
            return $"{Name} ({Category})";
        }

    }
}
