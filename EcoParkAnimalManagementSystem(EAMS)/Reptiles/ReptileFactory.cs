using EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles
{
    /// <summary>
    /// The factory class for creating reptile species objects.
    /// It uses dynamic binding to return Reptile type while creating specific species.
    /// </summary>
    public class ReptileFactory
    {
        /// <summary>
        /// Creates a reptile object of the specified species.
        /// </summary>
        /// <param name="species">The species to create.</param>
        /// <param name="bodyLength">Body length.</param>
        /// <param name="livesInWater">Whether it lives in water.</param>
        /// <param name="aggressivenessLevel">Aggressiveness level (0-10).</param>
        /// <returns>A Reptile object of the specified species.</returns>
        public static Reptile CreateReptile(ReptileSpecies species, double bodyLength,
            bool livesInWater, int aggressivenessLevel)
        {

            Reptile reptile = null;

            switch (species)
            {
                case ReptileSpecies.Snake:
                    reptile = new Snake(bodyLength, livesInWater, aggressivenessLevel);
                    break;

                case ReptileSpecies.Turtle:
                    reptile = new Turtle(bodyLength, livesInWater, aggressivenessLevel);
                    break;

                default:
                    throw new ArgumentException("Unknown reptile species");


                    
            }
            return reptile;
        }
    }

}

