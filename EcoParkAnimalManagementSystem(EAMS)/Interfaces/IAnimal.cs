using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Interfaces
{
    /// <summary>
    /// Interface defining the contract for all animal types in the EcoPark system.
    /// Provides properties and methods that all concrete animal classes must implement.
    /// </summary>
    public interface IAnimal
    {
        // Gets or sets the name of the animal.
        string Name { get; set; }

        // Gets or sets the age of the animal in years.
        int Age { get; set; }

        // Gets or sets the gender of the animal.
        GenderType Gender { get; set; }

        // Returns a summary string containing selected key information about the animal.
        // Used for displaying concise information in list controls.
        string ToStringSummary();

        // Sets the typical sleep time for this animal.
        void SetSleepTime();

        // Gets the average lifespan for this type of animal in years.
        int GetAverageLifeSpan();

   
        // Gets the daily food requirements for this animal as a dictionary.
        Dictionary<string, string> DailyFoodRequirement();

        /// Gets a queue of upcoming events for this animal.
        Queue<string> GetUpcomingEvents();
    }
}
