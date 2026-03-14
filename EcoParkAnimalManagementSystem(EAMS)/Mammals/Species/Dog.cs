using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Mammals.Species
{

    /// This represents a dog with characteristics.

    public class Dog : Mammal
    {

        public string Breed { get; set; } = "Unknown";

        public bool IsTrained { get; set; } = false;

        public Dog() : base()
        {
        }


        //for Mammalfactory
        public Dog(int numOfTeeth, double tailLength) : base(numOfTeeth, tailLength)
        {
        }


        public override void SetSleepTime()
        {
            SleepTimeHours = 11;
        }

        public override int GetAverageLifeSpan()
        {
            return 11;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodSchedule = new Dictionary<string, string>();

            foodSchedule.Add("Morning", "400g proplan dog food + fresh water or water ");
            foodSchedule.Add("Afternoon", "200g light food or treats");
            foodSchedule.Add("Evening", "300g heavy food + fresh milk or fresh water");

            return foodSchedule;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();

            events.Enqueue("Morning walk at 6:00 AM");

            if (IsTrained)
            {
                events.Enqueue("Training session at 9:30 AM");
            }
            else
            {
                events.Enqueue("Basic obedience training at 10:30 AM");
            }

            events.Enqueue("Afternoon walk at 3:30 PM");
            events.Enqueue("Evening walk at 8:00 PM");
            events.Enqueue("Vet checkup scheduled for next month");

            return events;
        }

        public override string ToStringSummary()
        {
            return $"{base.ToStringSummary()} | Breed: {Breed}";
        }



    }
}
