using EcoParkAnimalManagementSystem_EAMS_.Mammals.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcoParkAnimalManagementSystem_EAMS_.Mammals
{
    /// <summary>
    /// The Factory class for creating mammal species objects.
    /// It uses dynamic binding to return Mammal type while creating specific species.
    /// </summary>

    public class MammalFactory
    {
        /// <summary>
        /// Creates a mammal object of the specified species.
        /// </summary>
        /// <param name="species">The species to create.</param>
        /// <param name="numOfTeeth">Number of teeth.</param>
        /// <param name="tailLength">Length of tail.</param>
        /// <returns>A Mammal object of the specified species.</returns>
        public static Mammal CreateMammal(MammalSpecies species, int numOfTeeth, double tailLength)
        {
        
            Mammal mammal = null;

            switch (species)
            {
                case MammalSpecies.Cat:
                    mammal = new Cat(numOfTeeth, tailLength);
                    break;

                case MammalSpecies.Dog:
                    mammal = new Dog(numOfTeeth, tailLength);
                    break;

                default:
                    throw new ArgumentException("Unknown mammal species");
                    
            }

            return mammal;
        }
    }
}
