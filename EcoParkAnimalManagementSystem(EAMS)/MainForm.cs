using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Infrastructure;
using EcoParkAnimalManagementSystem_EAMS_.Mammals;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles;
using EcoParkAnimalManagementSystem_EAMS_.Utilities;

namespace EcoParkAnimalManagementSystem_EAMS_
{

    // Main form for the EcoPark Animal Management System.
    public partial class MainForm : Form
    {
        private AnimalManager animalManager;
        private Animal currentAnimal = null;
        private string selectedImagePath = string.Empty;


        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }


        // Initializes all GUI components.
        private void InitializeGUI()
        {
            animalManager = new AnimalManager();
            // Populate category list
            lstCategory.Items.Clear();
            foreach (CategoryType category in Enum.GetValues(typeof(CategoryType)))
            {
                lstCategory.Items.Add(category);
            }

            // Populate gender combobox 
            cmbGender.Items.Clear();
            foreach (GenderType gender in Enum.GetValues(typeof(GenderType)))
            {
                cmbGender.Items.Add(gender);
            }
            cmbGender.SelectedIndex = 0;

            // Clear inputs and output
            ClearInputFields();
            txtAnimalDetails.Text = string.Empty;
            picAnimal.Image = null;

            // Shows "add" on start up
            btnAdd.Text = "Add";
            btnAdd.Tag = null;

            UpdateAnimalListDisplay();
        }


        // Clears all input fields
        private void ClearInputFields()
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtWeight.Text = string.Empty;
            cmbGender.SelectedIndex = 0;
            selectedImagePath = string.Empty;
            currentAnimal = null;
        }


        // Category and Species Selection
        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Validate selection before use
            int index = lstCategory.SelectedIndex;
            if (index < 0)
                return;

            if (chkListAllSpecies.Checked)
                return;

            CategoryType selectedCategory = (CategoryType)lstCategory.SelectedItem;
            PopulateSpeciesList(selectedCategory);
        }


        // Populates species list based on selected category.
        private void PopulateSpeciesList(CategoryType category)
        {
            lstSpecies.Items.Clear();

            switch (category)
            {
                case CategoryType.Mammal:
                    foreach (MammalSpecies species in Enum.GetValues(typeof(MammalSpecies)))
                    {
                        lstSpecies.Items.Add(species);
                    }
                    break;

                case CategoryType.Reptile:
                    foreach (ReptileSpecies species in Enum.GetValues(typeof(ReptileSpecies)))
                    {
                        lstSpecies.Items.Add(species);
                    }
                    break;

                default:
                    lstSpecies.Items.Add("(Not implemented)");
                    break;
            }
        }

        private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {

            // highlights category when species selected
            if (chkListAllSpecies.Checked)
            {
                HighlightCategoryForSelectedSpecies();
            }
        }


        // Highlights category for selected species.
        private void HighlightCategoryForSelectedSpecies()
        {
            int index = lstSpecies.SelectedIndex;
            if (index < 0)
                return;

            object selectedItem = lstSpecies.SelectedItem;

            if (selectedItem is MammalSpecies)
            {
                lstCategory.SelectedItem = CategoryType.Mammal;
            }
            else if (selectedItem is ReptileSpecies)
            {
                lstCategory.SelectedItem = CategoryType.Reptile;
            }
        }

        private void chkListAllSpecies_CheckedChanged(object sender, EventArgs e)
        {
            if (chkListAllSpecies.Checked)
            {
                lstCategory.Enabled = false;
                PopulateAllSpecies();
            }
            else
            {
                lstCategory.Enabled = true;
                lstSpecies.Items.Clear();

                if (lstCategory.SelectedIndex >= 0)
                {
                    PopulateSpeciesList((CategoryType)lstCategory.SelectedItem);
                }
            }
        }


        // Populates all species from all categories.
        private void PopulateAllSpecies()
        {
            lstSpecies.Items.Clear();

            foreach (MammalSpecies species in Enum.GetValues(typeof(MammalSpecies)))
            {
                lstSpecies.Items.Add(species);
            }

            foreach (ReptileSpecies species in Enum.GetValues(typeof(ReptileSpecies)))
            {
                lstSpecies.Items.Add(species);
            }
        }

        // Create Animal Button

        private void btnCreateAnimal_Click(object sender, EventArgs e)
        {
            //  Validates selection
            if (lstSpecies.SelectedIndex < 0)
            {
                MessageBox.Show("Kindly select a species first.",
                    "Selection is Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object selectedSpecies = lstSpecies.SelectedItem;

            if (selectedSpecies is MammalSpecies)
            {
                OpenMammalView((MammalSpecies)selectedSpecies);
            }
            else if (selectedSpecies is ReptileSpecies)
            {
                OpenReptileView((ReptileSpecies)selectedSpecies);
            }
            else
            {
                MessageBox.Show("This category has not yet been implemented.",
                    "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenMammalView(MammalSpecies species)
        {
            MammalView mammalView = new MammalView((int)species);

            if (mammalView.ShowDialog() == DialogResult.OK)
            {
                //  receiving animal from form
                currentAnimal = mammalView.Animal;
            }
        }

        private void OpenReptileView(ReptileSpecies species)
        {
            ReptileView reptileView = new ReptileView((int)species);

            if (reptileView.ShowDialog() == DialogResult.OK)
            {
                //  Dynamic binding - receiving animal from form
                currentAnimal = reptileView.Animal;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            // Check if one is in EDIT mode
            if (btnAdd.Tag != null)
            {
                int editIndex = (int)btnAdd.Tag;
                Animal animalToEdit = animalManager.GetAt(editIndex);

                if (animalToEdit != null && ReadGeneralAnimalDataForEdit(animalToEdit))
                {
                    if (animalManager.ChangeAt(animalToEdit, editIndex))
                    {
                        UpdateAnimalListDisplay();
                        lstAnimals.SelectedIndex = editIndex;

                        MessageBox.Show("Animal updated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset to Add mode
                        btnAdd.Text = "Add";
                        btnAdd.Tag = null;
                        ClearInputFields();
                        txtAnimalDetails.Text = string.Empty;
                        picAnimal.Image = null;
                    }
                }
                return;
            }

            // Normal ADD mode
            if (currentAnimal == null)
            {
                MessageBox.Show("Please create an animal first by clicking the 'Create Animal' button.",
                    "No Animal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ReadGeneralAnimalData())
                return;

            animalManager.SetNewID(currentAnimal);

            if (animalManager.Add(currentAnimal))
            {
                UpdateAnimalListDisplay();
                ClearInputFields();
                txtAnimalDetails.Text = string.Empty;
                picAnimal.Image = null;

                MessageBox.Show("Animal added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add animal.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Reads general animal data from GUI.
        ///  Works with any animal type.
        /// </summary>
        private bool ReadGeneralAnimalData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.",
                    "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            (double age, bool okAge) = NumericUtility.GetDouble(txtAge.Text);
            if (!okAge || age < 0)
            {
                MessageBox.Show("Please enter a valid age.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }

            (double weight, bool okWeight) = NumericUtility.GetDouble(txtWeight.Text);
            if (!okWeight || weight < 0)
            {
                MessageBox.Show("Please enter a valid weight.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeight.Focus();
                return false;
            }

            // works for any species
            currentAnimal.Name = txtName.Text;
            currentAnimal.Age = (int)age;
            currentAnimal.Weight = weight;
            currentAnimal.Gender = (GenderType)cmbGender.SelectedItem;
            currentAnimal.ImagePath = selectedImagePath;

            return true;
        }


        //Updates the display

        private void UpdateAnimalListDisplay()
        {
            if (lstAnimals == null)
                return;

            lstAnimals.Items.Clear();

            string[] animalSummaries = animalManager.ToStringSummaryAllAnimals();

            foreach (string summary in animalSummaries)
            {
                lstAnimals.Items.Add(summary);
            }
        }


        private void lstAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = lstAnimals.SelectedIndex;
            if (index < 0)
            {
                txtAnimalDetails.Text = string.Empty;
                picAnimal.Image = null;
                return;
            }

            string detailedInfo = animalManager.GetDetailedAnimalInfo(index);
            txtAnimalDetails.Text = detailedInfo;

            Animal selectedAnimal = animalManager.GetAt(index);
            if (selectedAnimal != null && !string.IsNullOrEmpty(selectedAnimal.ImagePath))
            {
                try
                {
                    picAnimal.Image = Image.FromFile(selectedAnimal.ImagePath);
                }
                catch
                {
                    picAnimal.Image = null;
                }
            }
            else
            {
                picAnimal.Image = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int index = lstAnimals.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select an animal to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Animal animalToDelete = animalManager.GetAt(index);
            string animalName = animalToDelete != null ? animalToDelete.Name : "this animal";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {animalName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (animalManager.DeleteAt(index))
                {
                    UpdateAnimalListDisplay();
                    txtAnimalDetails.Text = string.Empty;
                    picAnimal.Image = null;

                    MessageBox.Show("Animal deleted successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            int index = lstAnimals.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select an animal to modify.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Animal animalToChange = animalManager.GetAt(index);
            if (animalToChange == null)
                return;

            txtName.Text = animalToChange.Name;
            txtAge.Text = animalToChange.Age.ToString();
            txtWeight.Text = animalToChange.Weight.ToString();
            cmbGender.SelectedItem = animalToChange.Gender;
            selectedImagePath = animalToChange.ImagePath;

            if (!string.IsNullOrEmpty(animalToChange.ImagePath))
            {
                try
                {
                    picAnimal.Image = Image.FromFile(animalToChange.ImagePath);
                }
                catch
                {
                    picAnimal.Image = null;
                }
            }

            btnAdd.Text = "Save Changes";
            btnAdd.Tag = index;

        }

        private bool ReadGeneralAnimalDataForEdit(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.",
                    "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            (double age, bool okAge) = NumericUtility.GetDouble(txtAge.Text);
            if (!okAge || age < 0)
            {
                MessageBox.Show("Please enter a valid age.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            (double weight, bool okWeight) = NumericUtility.GetDouble(txtWeight.Text);
            if (!okWeight || weight < 0)
            {
                MessageBox.Show("Please enter a valid weight.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            animal.Name = txtName.Text;
            animal.Age = (int)age;
            animal.Weight = weight;
            animal.Gender = (GenderType)cmbGender.SelectedItem;
            animal.ImagePath = selectedImagePath;

            return true;
        }


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Animal Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    try
                    {
                        picAnimal.Image = Image.FromFile(selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}",
                            "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedImagePath = string.Empty;
                    }
                }
            }

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EcoPark Animal Management System\nVersion 1.0\n\n By: Richmond Boakye",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtAnimalDetails_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
