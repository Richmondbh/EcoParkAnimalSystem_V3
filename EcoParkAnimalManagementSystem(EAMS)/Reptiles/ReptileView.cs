using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles.Species;
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

namespace EcoParkAnimalManagementSystem_EAMS_.Reptiles
{
    public partial class ReptileView : Form
    {
        // This is the Form for collecting reptile category and species-specific data.

        public ReptileView()
        {
            InitializeComponent();
        }

        private Animal animal = null;
        private ReptileSpecies species;


        // Initializes the ReptileView form for the specified species.
        public ReptileView(int speciesIndex)
        {
            InitializeComponent();
            this.species = (ReptileSpecies)speciesIndex;
            InitializeGUI();
        }


        // Gets the Animal object created by this form.

        public Animal Animal
        {
            get { return animal; }
        }


        // Initializes the GUI.

        private void InitializeGUI()
        {
            // Clear inputs
            txtBodyLength.Text = string.Empty;
            txtInput1.Text = string.Empty;
            txtInput2.Text = string.Empty;
            radNo.Checked = true;
            numAggression.Value = 0;

            // Configure species-specific controls
            ShowReptileSpecies();
        }


        // Adjusts the GUI based on the selected species.
     
        private void ShowReptileSpecies()
        {
            // Dynamic text - changes per species
            grpSpecies.Text = $"Specific Data for {species}";

            // Hide all species-specific controls first
            lblSpecies1.Visible = false;
            lblSpecies2.Visible = false;
            txtInput1.Visible = false;
            txtInput2.Visible = false;
            chkSpecies.Visible = false;

            switch (species)
            {
                case ReptileSpecies.Snake:
                    lblSpecies1.Text = "Speed";
                    lblSpecies1.Visible = true;
                    txtInput1.Visible = true;

                    chkSpecies.Text = "Is Venomous";
                    chkSpecies.Visible = true;
                    chkSpecies.Top = lblSpecies2.Top;
                    break;

                case ReptileSpecies.Turtle:
                    lblSpecies1.Text = "Shell toughness";
                    lblSpecies1.Visible = true;
                    txtInput1.Visible = true;

                    lblSpecies2.Text = "Shell Width";
                    lblSpecies2.Visible = true;
                    txtInput2.Visible = true;
                    break;

                default:
                    lblSpecies1.Text = "Species not implemented";
                    lblSpecies1.Visible = true;
                    break;
            }
        }


        /// Handles OK button click.
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CreateReptileSpecies())
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// Handles Cancel button click.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            animal = null;
            DialogResult = DialogResult.Cancel;
        }

    
        // Creates the reptile species object.
        private bool CreateReptileSpecies()
        {
            // Validate body length
            (double bodyLength, bool ok1) = NumericUtility.GetDouble(txtBodyLength.Text);

            if (!ok1)
            {
                MessageBox.Show("Please enter a valid body length.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool livesInWater = radYes.Checked;
            int aggressivenessLevel = (int)numAggression.Value;

            // Create specific species using factory
            animal = ReptileFactory.CreateReptile(species, bodyLength, livesInWater, aggressivenessLevel);

            // Set species-specific data using type casting
            switch (species)
            {
                case ReptileSpecies.Snake:
                    (double speed, bool okSpeed) = NumericUtility.GetDouble(txtInput1.Text);
                    if (okSpeed)
                    {
                        ((Snake)animal).Speed = speed;
                    }
                    ((Snake)animal).IsVenomous = chkSpecies.Checked;
                    break;

                case ReptileSpecies.Turtle:
                    ((Turtle)animal).ShellHardness = txtInput1.Text;
                    (double shellWidth, bool okWidth) = NumericUtility.GetDouble(txtInput2.Text);
                    if (okWidth)
                    {
                        ((Turtle)animal).ShellWidth = shellWidth;
                    }
                    break;
            }

            return true;
        }



    }
}

