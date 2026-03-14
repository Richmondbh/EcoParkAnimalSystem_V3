using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species
{
   
    // This represents a turtle with turtle-specific characteristics.
    public class Turtle : Reptile
    {
        private double shellWidth;

        public string ShellHardness { get; set; } = "Unknown";

        
      
        public double ShellWidth
        {
            get { return shellWidth; }
            set
            {
                if (value >= 0)
                {
                    shellWidth = value;
                }
            }
        }

        public Turtle() : base()
        {
        }

        public Turtle(double bodyLength, bool livesInWater, int aggressivenessLevel): base(bodyLength, livesInWater, aggressivenessLevel)
        {
            BodyLength = bodyLength;
            LivesInWater = livesInWater;
            AggressivenessLevel = aggressivenessLevel;
        }

        public override void SetSleepTime()
        {
            SleepTimeHours = 7;
        }

        public override int GetAverageLifeSpan()
        {
            return 60;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodSchedule = new Dictionary<string, string>();

            foodSchedule.Add("Morning", "Commercial reptile pellets – 45g");
            foodSchedule.Add("Afternoon", "Fresh vegetables (spinach, water plants) – 35g");
            foodSchedule.Add("Evening", "Small fish or shrimp – 20g");
            foodSchedule.Add("Supplements", "Mineral supplement once per week");

            return foodSchedule;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();

            events.Enqueue("Enclosure humidity adjustment in the morning");
            events.Enqueue("Midday feeding and behavior monitoring");
            events.Enqueue("Water change and tank sanitation");
            events.Enqueue("UV lighting cycle review");
            events.Enqueue("Quarterly physical condition check");

            return events;
        }

        public override string ToStringSummary()
        {
            return $"{base.ToStringSummary()} | Shell: {ShellWidth}cm";
        }
    }
}
