using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoParkAnimalManagementSystem_EAMS_.Mammals
{
    public abstract class Mammal : Animal
    {
        /// <summary>
        /// Abstract class representing mammals in the EcoPark system.
        /// Inherits from Animal and adds mammal-specific characteristics.
        /// </summary>
        private int numberOfTeeth;
        private double tailLength;
        

        public int NumberOfTeeth
        {
            get { return numberOfTeeth; }
            set
            {
                if (value >= 0)
                {
                    numberOfTeeth = value;
                }
            }
        }

        public double TailLength
        {
            get { return tailLength; }
            set
            {
                if (value >= 0)
                {
                    tailLength = value;
                }
            }
        }

        // Initializes a new instance of the Mammal class.
        protected Mammal() : base()
        {
            Category = CategoryType.Mammal;
            NumberOfTeeth = 0;
        }

        // For mammalfactory
        protected Mammal(int numberOfTeeth, double tailLength) : base()
        {
            Category = CategoryType.Mammal;
            NumberOfTeeth = numberOfTeeth;
            TailLength = tailLength;
        }
    }
}
