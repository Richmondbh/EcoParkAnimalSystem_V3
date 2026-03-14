using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Exceptions
{
    public class AnimalValidationException : Exception
    {
        //  private backing fields, encapsulated via properties
        private readonly string animalName;
        private readonly string species;

        public string AnimalName => animalName;
        public string Species => species;

        
        // Initializes the exception with a message plus the
        // name and species of the problematic animal.
        public AnimalValidationException(string message, string animalName, string species)
            : base(message)
        {
            this.animalName = animalName;
            this.species = species;
        }

       
        // Returns a full description including the contextual animal data.
       
        public override string ToString()
        {
            return $"{base.Message} | Animal: '{animalName}', Species: '{species}'";
        }
    }
}
