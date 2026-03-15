using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Exceptions;
using EcoParkAnimalManagementSystem_EAMS_.Interfaces;
using EcoParkAnimalManagementSystem_EAMS_.Mammals;
using EcoParkAnimalManagementSystem_EAMS_.Mammals.Species;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

       // Writes every animal to a plain text file — one animal per block, fields on separate lines.
         //try-finally ensures the writer closes.
        public override bool SaveToTextFile(string fileName)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                for (int i = 0; i < Count; i++)
                {
                    Animal animal = GetAt(i);
                    // Changed every Parse line in LoadFromTextFile to use InvariantCulture beacause of my keyboard setup 
                    // General fields 
                    writer.WriteLine(animal.Id);
                    writer.WriteLine(animal.Name);
                    writer.WriteLine(animal.Age);
                    writer.WriteLine(animal.Weight.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(animal.Gender);
                    writer.WriteLine(animal.Category);

                    // Category-specific fields 
                    if (animal is Mammal mammal)
                    {
                        writer.WriteLine(mammal.NumberOfTeeth);
                        writer.WriteLine(mammal.TailLength.ToString(CultureInfo.InvariantCulture));
                    }
                    else if (animal is Reptile reptile)
                    {
                        writer.WriteLine(reptile.BodyLength);
                        writer.WriteLine(reptile.LivesInWater);
                        writer.WriteLine(reptile.AggressivenessLevel);
                    }

                    // Species-specific fields 
                    if (animal is Dog dog)
                    {
                        writer.WriteLine(dog.Breed);
                        writer.WriteLine(dog.IsTrained);
                    }
                    else if (animal is Snake snake)
                    {
                        writer.WriteLine(snake.IsVenomous);
                        writer.WriteLine(snake.Speed.ToString(CultureInfo.InvariantCulture));
                    }

                    // Blank line separates each animal block.
                    writer.WriteLine();
                }
                return true;
            }
            finally
            {
                writer?.Close();
            }
        }

        // Reconstructs the animal list from a plain text file written by SaveToTextFile.
        public override bool LoadFromTextFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    DeleteAll();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip blank separator lines between animal blocks.
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        // Changed every Parse line in LoadFromTextFile to use InvariantCulture beacause of my keyboard setup
                        // Read general fields. same order as SaveToTextFile.
                        string id = line;
                        string name = reader.ReadLine();
                        int age = int.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
                        double weight = double.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
                        GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), reader.ReadLine());
                        CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), reader.ReadLine());

                        Animal animal = null;

                        // Reconstruct the correct concrete type from the saved category.
                        if (category == CategoryType.Mammal)
                        {
                            int numberOfTeeth = int.Parse(reader.ReadLine());
                            double tailLength = double.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);

                            // Default to Dog for mammals 
                            Dog dog = new Dog(numberOfTeeth, tailLength);
                            dog.Breed = reader.ReadLine();
                            dog.IsTrained = bool.Parse(reader.ReadLine());
                            animal = dog;
                        }
                        else if (category == CategoryType.Reptile)
                        {
                            double bodyLength = double.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
                            bool livesInWater = bool.Parse(reader.ReadLine());
                            int aggressivenessLevel = int.Parse(reader.ReadLine());

                            Snake snake = new Snake(bodyLength, livesInWater, aggressivenessLevel);
                            snake.IsVenomous = bool.Parse(reader.ReadLine());
                            snake.Speed = double.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
                            animal = snake;
                        }

                        if (animal != null)
                        {
                            animal.Id = id;
                            animal.Name = name;
                            animal.Age = age;
                            animal.Weight = weight;
                            animal.Gender = gender;
                            Add(animal);
                        }
                    }
                    return true;
                }
                catch (IOException)
                {
                    
                    throw;
                }
            }
        }



        // Returns all animals sorted alphabetically by name.
        public IEnumerable<Animal> GetSortedByName()
        {
            return from animal in GetAllAnimals()
                   orderby animal.Name
                   select animal;
        }

        // Returns all animals sorted by age, youngest first.
        public IEnumerable<Animal> GetSortedByAge()
        {
            return from animal in GetAllAnimals()
                   orderby animal.Age
                   select animal;
        }

        // Returns the total number of animals in the system.
        public int GetTotalCount()
        {
            return (from animal in GetAllAnimals()
                    select animal).Count();
        }

        // Returns the average age across all animals, or 0 if the list is empty.
        public double GetAverageAge()
        {
            if (Count == 0) return 0;

            return (from animal in GetAllAnimals()
                    select animal.Age).Average();
        }



        // Returns all animals belonging to the specified category.
        public IEnumerable<Animal> GetByCategory(CategoryType category)
        {
            return from animal in GetAllAnimals()
                   where animal.Category == category
                   orderby animal.Name
                   select animal;
        }

        // Returns all animals whose age falls within the given range (inclusive).
        public IEnumerable<Animal> GetByAgeRange(int minAge, int maxAge)
        {
            return from animal in GetAllAnimals()
                   where animal.Age >= minAge && animal.Age <= maxAge
                   orderby animal.Age
                   select animal;
        }

       

        // Finds the first animal matching the given name (case-insensitive), or null.
        public Animal SearchByName(string name)
        {
            return (from animal in GetAllAnimals()
                    where animal.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                    select animal).FirstOrDefault();
        }

        // Finds the first animal matching the given ID, or null.
        public Animal SearchById(string id)
        {
            return (from animal in GetAllAnimals()
                    where animal.Id.Equals(id, StringComparison.OrdinalIgnoreCase)
                    select animal).FirstOrDefault();
        }

      

        // Scans for duplicate animals (same name + same category) before serialization.
        public void ValidateNoDuplicates()
        {
            IEnumerable<Animal> duplicates =
                from animal in GetAllAnimals()
                group animal by new { animal.Name, animal.Category } into grp
                where grp.Count() > 1
                select grp.First();

            Animal first = duplicates.FirstOrDefault();
            if (first != null)
            {
                throw new AnimalValidationException(
                    "Duplicate animal detected — save aborted.",
                    first.Name,
                    first.Category.ToString()
                );
            }
        }


        // Returns all animals as an IEnumerable for LINQ queries.
        private IEnumerable<Animal> GetAllAnimals()
        {
            return from i in Enumerable.Range(0, Count)
                   select GetAt(i);
        }

        // Populates the manager with test animals for development and UI testing.
        // For testing only  and to be removed from InitializeGUI before final submission incase i forget @ Farid
        public void SeedTestData()
        {
            Dog simba = new Dog(30, 0.8);
            simba.Name = "Simba";
            simba.Age = 4;
            simba.Weight = 190.5;
            simba.Gender = GenderType.Male;
            simba.Breed = "Labrador";
            simba.IsTrained = true;
            SetNewID(simba);
            Add(simba);

            Dog bella = new Dog(28, 0.6);
            bella.Name = "Bella";
            bella.Age = 2;
            bella.Weight = 160.0;
            bella.Gender = GenderType.Female;
            bella.Breed = "Poodle";
            bella.IsTrained = false;
            SetNewID(bella);
            Add(bella);

            Snake rex = new Snake(1.8, false, 6);
            rex.Name = "Rex";
            rex.Age = 7;
            rex.Weight = 0.0;
            rex.Gender = GenderType.Male;
            rex.IsVenomous = false;
            rex.Speed = 12.5;
            SetNewID(rex);
            Add(rex);

            Snake naja = new Snake(1.2, true, 8);
            naja.Name = "Naja";
            naja.Age = 3;
            naja.Weight = 0.0;
            naja.Gender = GenderType.Female;
            naja.IsVenomous = true;
            naja.Speed = 9.0;
            SetNewID(naja);
            Add(naja);

            Dog bruno = new Dog(32, 0.9);
            bruno.Name = "Bruno";
            bruno.Age = 5;
            bruno.Weight = 200.0;
            bruno.Gender = GenderType.Male;
            bruno.Breed = "GermanShepherd";
            bruno.IsTrained = true;
            SetNewID(bruno);
            Add(bruno);
        }
    }
}





