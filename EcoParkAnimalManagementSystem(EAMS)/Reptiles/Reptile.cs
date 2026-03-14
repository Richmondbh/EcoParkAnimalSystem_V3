using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles
{
    /// <summary>
    /// Represents a reptile animal with specific characteristics.
    /// This nherits from Animal base class.
    /// </summary>
    public abstract class Reptile : Animal
    {
        private double bodyLength;
        private int aggressivenessLevel;


        public bool LivesInWater { get; set; } = false;

        public double BodyLength
        {
            get { return bodyLength; }
            set
            {
                if (value >= 0)
                {
                    bodyLength = value;
                }
            }
        }

        public int AggressivenessLevel
        {
            get { return aggressivenessLevel; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    aggressivenessLevel = value;
                }
            }
        }

        protected Reptile() : base()
        {
            Category = CategoryType.Reptile;
        }

        protected Reptile(double bodyLength, bool livesInWater, int aggressivenessLevel) : base()
        {
            BodyLength = bodyLength;
            LivesInWater = livesInWater;
            AggressivenessLevel = aggressivenessLevel;
            Category = CategoryType.Reptile;

        }

    }
}
