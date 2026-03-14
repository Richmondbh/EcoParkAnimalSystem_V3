using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Mammals.Species
{

    // This represents a cat with characteristics.
  
    public class Cat: Mammal
    {

        public string FurColor { get; set; } = "Unknown";

        public bool IsPurebred { get; set; } = false;

        public Cat() : base()
        {
        }


        //For mammal factory
        public Cat(int numOfTeeth, double tailLength) : base(numOfTeeth, tailLength)
        {
        }


        public override void SetSleepTime()
        {
            SleepTimeHours = 14;
        }
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodSchedule = new Dictionary<string, string>();

            foodSchedule.Add("Morning", "40g proplan cat food + fresh water or water ");
            foodSchedule.Add("Afternoon", "20g light food or treats");
            foodSchedule.Add("Evening", "30g heavy food + fresh milk or fresh water");

            return foodSchedule;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();

            events.Enqueue("Morning cleaning session at 7:00 AM");
            events.Enqueue("Play time at 10:00 AM");
            events.Enqueue("Afternoon nap time at 13:00 PM");

            if (IsPurebred)
            {
                events.Enqueue("Breed-specific health check scheduled");
            }

            events.Enqueue("Evening play session at 6:30 PM");
            events.Enqueue("Annual vaccination due next year");

            return events;
        }

        public override string ToStringSummary()
        {
            return $"{base.ToStringSummary()} | Color: {FurColor}";
        }

    }

}
