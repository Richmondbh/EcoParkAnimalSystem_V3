using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species
{
   
    // Represents a snake with specific characteristics.

    public class Snake : Reptile
    {
        private double speed;

        public bool IsVenomous { get; set; } = false;

        public double Speed
        {
            get { return speed; }
            set
            {
                if (value >= 0)
                {
                    speed = value;
                }
            }
        }
        public Snake() : base()
        {
        }


        public Snake(double bodyLength, bool livesInWater, int aggressivenessLevel): base(bodyLength, livesInWater, aggressivenessLevel)
        {
            BodyLength = bodyLength;
            LivesInWater = livesInWater;
            AggressivenessLevel = aggressivenessLevel;
        }

        public override void SetSleepTime()
        {
            SleepTimeHours = 17;
        }

        public override int GetAverageLifeSpan()
        {
            return 20;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodSchedule = new Dictionary<string, string>();

            foodSchedule.Add("Feeding Schedule", "One appropriately sized prey every 7–10 days");
            foodSchedule.Add("Hydration", "Clean drinking water replaced daily");
            foodSchedule.Add("Observation", "Do not feed during shedding period");


            return foodSchedule;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();

            events.Enqueue("Morning enclosure inspection at 07:30");
            events.Enqueue("UVB lighting check and replacement if needed");

            if (IsVenomous)
            {
                events.Enqueue("Secure enclosure audit – restricted access required");
            }

            events.Enqueue("Weekly enclosure cleaning scheduled");
            events.Enqueue("Routine veterinary check-up at the end of month");

            return events;
        }

        public override string ToStringSummary()
        {
            string venomStatus = IsVenomous ? "Venomous" : "Non-venomous";
            return $"{base.ToStringSummary()} | {venomStatus}";
        }

    }
}
