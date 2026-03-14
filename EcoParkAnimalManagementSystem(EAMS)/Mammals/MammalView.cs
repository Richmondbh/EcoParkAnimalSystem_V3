using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Mammals.Species;
using EcoParkAnimalManagementSystem_EAMS_.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoParkAnimalManagementSystem_EAMS_.Mammals
{
    
    // Form for collecting mammal category and species-specific data.
    public partial class MammalView : Form
    {
        private Animal animal = null;
        private MammalSpecies species;

        /// <summary>
        /// Initializes the MammalView form for the specified species.
        /// </summary>
        /// <param name="speciesIndex">Index of the selected species.</param>
        public MammalView(int speciesIndex)
        {
            InitializeComponent();
            this.species = (MammalSpecies)speciesIndex;
            InitializeGUI();
        }

        public Animal Animal
        {
            get { return animal; }
        }

 
        // This initializes the GUI with appropriate labels.
        private void InitializeGUI()
        {


            // Clear inputs
            txtInput1.Text = string.Empty;
            txtInput2.Text = string.Empty;
            txtInput3.Text = string.Empty;
            txtInput4.Text = string.Empty;

            // Configure species-specific controls
            ShowMammalSpecies();
        }

      
        // Adjusts the GUI based on the selected species.
    
        private void ShowMammalSpecies()
        {
            grpSpecies.Text = $"Specific Data for {species}";

            // Hide all species-specific controls first
            lblSpecies1.Visible = false;
            lblSpecies2.Visible = false;
            txtInput3.Visible = false;
            txtInput4.Visible = false;
            chkSpecies.Visible = false;

            switch (species)
            {
                case MammalSpecies.Cat:
                    lblSpecies1.Text = "Fur Color";
                    lblSpecies1.Visible = true;
                    txtInput3.Visible = true;

                    chkSpecies.Text = "Is Blooded";
                    chkSpecies.Visible = true;
                    chkSpecies.Top = lblSpecies2.Top;
                    break;

                case MammalSpecies.Dog:
                    lblSpecies1.Text = "Breed";
                    lblSpecies1.Visible = true;
                    txtInput3.Visible = true;

                    chkSpecies.Text = "Is Tamed";
                    chkSpecies.Visible = true;
                    chkSpecies.Top = lblSpecies2.Top;
                    break;

                default:
                    lblSpecies1.Text = "Species not implemented";
                    lblSpecies1.Visible = true;
                    break;
            }
        }

  
        // Handles the OK button click.
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CreateMammalSpecies())
            {
                DialogResult = DialogResult.OK;
            }
        }

       
        // Handles the Cancel button click.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            animal = null;
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Creates the mammal species object.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        private bool CreateMammalSpecies()
        {
            // Validate inputs
            (int numOfTeeth, bool ok1) = NumericUtility.GetInteger(txtInput1.Text);
            (double tailLength, bool ok2) = NumericUtility.GetDouble(txtInput2.Text);

            if (!ok1 || !ok2)
            {
                MessageBox.Show("Please enter valid numeric values.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Create specific species using factory
            animal = MammalFactory.CreateMammal(species, numOfTeeth, tailLength);

            // Setting species-specific data using type casting
            switch (species)
            {
                case MammalSpecies.Cat:
                    ((Cat)animal).FurColor = txtInput3.Text;
                    ((Cat)animal).IsPurebred = chkSpecies.Checked;
                    break;

                case MammalSpecies.Dog:
                    ((Dog)animal).Breed = txtInput3.Text;
                    ((Dog)animal).IsTrained = chkSpecies.Checked;
                    break;
            }

            return true;
        }

      
    }
}

