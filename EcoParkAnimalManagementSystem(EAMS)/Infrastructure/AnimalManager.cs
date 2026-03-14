using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Mammals;
using EcoParkAnimalManagementSystem_EAMS_.Mammals.Species;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Infrastructure
{
    public class AnimalManager : ListManager<Animal>
    {
        private static int startID = 1;

        public AnimalManager() : base()
        {
        }

        public void SetNewID(Animal animal)
        {
            if (animal == null)
            {
                return;
            }

            string categoryPrefix = GetCategoryPrefix(animal.Category);
            animal.Id = $"{categoryPrefix}{startID}";
            startID++;
        }

        private string GetCategoryPrefix(CategoryType category)
        {
            switch (category)
            {
                case CategoryType.Mammal:
                    return "M";
                case CategoryType.Reptile:
                    return "R";
                case CategoryType.Bird:
                    return "B";
                case CategoryType.Insect:
                    return "I";
                default:
                    return "No";
            }
        }

        public string[] ToStringSummaryAllAnimals()
        {
            string[] summaryArray = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                Animal animal = GetAt(i);
                if (animal != null)
                {
                    summaryArray[i] = animal.ToStringSummary();
                }
            }

            return summaryArray;
        }


      
        public string GetDetailedAnimalInfo(int index)
        {
            if (!CheckIndex(index)) return string.Empty;

            Animal animal = GetAt(index);
            if (animal == null) return string.Empty;

            var sb = new StringBuilder();

            // General info
            AppendRow(sb, "Id", animal.Id.ToString());
            AppendRow(sb, "Name", animal.Name);
            AppendRow(sb, "Age", $"{animal.Age}");
            AppendRow(sb, "Weight", $"{animal.Weight}");
            AppendRow(sb, "Gender", animal.Gender.ToString());
            AppendRow(sb, "Category", animal.Category.ToString());

            sb.AppendLine();

            // Lifespan
            sb.AppendLine("LIFESPAN");
            sb.AppendLine(new string('-', 35));
            AppendRow(sb, "Average lifespan", $"{animal.GetAverageLifeSpan()} years");
            sb.AppendLine();

            //  Food requirements 
            sb.AppendLine("DAILY FOOD REQUIREMENTS");
            sb.AppendLine(new string('-', 35));

            var foodSchedule = animal.DailyFoodRequirement();
            foreach (var meal in foodSchedule)
            {
                AppendRow(sb, meal.Key, meal.Value);
            }
            sb.AppendLine();

            //Upcoming events
            sb.AppendLine("UPCOMING EVENTS");
            sb.AppendLine(new string('-', 35));

          
            var events = animal.GetUpcomingEvents();
            int n = 1;
            foreach (var ev in events)
            {
                sb.AppendLine($"{n,2}. {ev}");
                n++;
            }

            return sb.ToString();
        }

        private static void AppendRow(StringBuilder sb, string label, string value)
        {
           
            sb.AppendLine($"{label,-16} {value}");
        }

    }



}

