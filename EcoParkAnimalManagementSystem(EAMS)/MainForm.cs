using EcoParkAnimalManagementSystem_EAMS_.AnimalGen;
using EcoParkAnimalManagementSystem_EAMS_.Exceptions;
using EcoParkAnimalManagementSystem_EAMS_.Infrastructure;
using EcoParkAnimalManagementSystem_EAMS_.Mammals;
using EcoParkAnimalManagementSystem_EAMS_.Reptiles;
using EcoParkAnimalManagementSystem_EAMS_.Utilities;
using System.IO;
using static System.Windows.Forms.DataFormats;

namespace EcoParkAnimalManagementSystem_EAMS_
{

    // Main form for the EcoPark Animal Management System.
    public partial class MainForm : Form
    {
        private AnimalManager animalManager;
        private Animal currentAnimal = null;
        private string selectedImagePath = string.Empty;

        // Tracks the current file path and format across save/load operations.
        private string currentFilePath = string.Empty;
        private string currentFileFormat = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }


        // Initializes all GUI components.
        private void InitializeGUI()
        {
            animalManager = new AnimalManager();

            animalManager.SeedTestData(); // To be removed before submission @Farid
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

            // Populate category filter combobox for LINQ queries.
            cmbCategory.Items.Clear();
            foreach (CategoryType category in Enum.GetValues(typeof(CategoryType)))
                cmbCategory.Items.Add(category);
            cmbCategory.SelectedIndex = 0;

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

            UpdateStats();
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

        // Help method for reading Animal data for edit
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

        /// <summary>
        ///  File menu handlers 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EcoPark Animal Management System\nVersion 1.0\n\n By: Richmond Boakye",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Resets the application with prompts if data exists.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if (animalManager.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Unsaved animals will be lost. Continue?",
                    "New — EcoPark", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }

            animalManager.DeleteAll();
            currentFilePath = string.Empty;
            currentFileFormat = string.Empty;
            UpdateAnimalListDisplay();
            txtAnimalDetails.Text = string.Empty;
            picAnimal.Image = null;

        }
        // Saves using the remembered path and format  falls back to Save As if none set
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                mnuFileSaveAs_Click(sender, e);
                return;
            }

            SaveToCurrentFile();
        }


        // Lets the user choose a path and format, then saves.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Animal File";
                dialog.InitialDirectory = Application.StartupPath;
                dialog.Filter = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json|XML files (*.xml)|*.xml";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                currentFilePath = dialog.FileName;
                currentFileFormat = Path.GetExtension(dialog.FileName).TrimStart('.').ToLower();
                SaveToCurrentFile();
            }
        }

        // Opens a txt or json file and loads animals into the manager.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Animal File";
                dialog.InitialDirectory = Application.StartupPath;
                dialog.Filter = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string path = dialog.FileName;
                string format = Path.GetExtension(path).TrimStart('.').ToLower();

                try
                {
                    if (format == "txt")
                        animalManager.LoadFromTextFile(path);
                    else if (format == "json")
                        animalManager.JsonDeserialize(path);

                    currentFilePath = path;
                    currentFileFormat = format;
                    UpdateAnimalListDisplay();
                }
                catch (FileNotFoundException ex)
                {
                    //   all exceptions caught and displayed only in the GUI layer.
                    MessageBox.Show(ex.ToString(), "File not found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.ToString(), "Invalid file format",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error opening file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // Runs duplicate validation then writes in the current format.
        private void SaveToCurrentFile()
        {
            try
            {
                // validate before every save.
                animalManager.ValidateNoDuplicates();

                if (currentFileFormat == "txt")
                    animalManager.SaveToTextFile(currentFilePath);
                else if (currentFileFormat == "json")
                    animalManager.JsonSerialize(currentFilePath);
                else if (currentFileFormat == "xml")
                    animalManager.XmlSerialize(currentFilePath);

                MessageBox.Show("File saved successfully.", "Save — EcoPark",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AnimalValidationException ex)
            {
                // Custom exception carries animal name and species.
                MessageBox.Show(ex.ToString(), "Duplicate detected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString(), "Error saving file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unexpected error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Populates lstQueryResults with animals sorted by age, youngest first.
        private void btnSortByAge_Clicked(object sender, EventArgs e)
        {
            lstQueryResults.Items.Clear();
            foreach (Animal animal in animalManager.GetSortedByAge())
                lstQueryResults.Items.Add(animal.ToStringSummary());
        }

        // Populates lstQueryResults with animals sorted alphabetically by name.
        private void btnSortByName_Click(object sender, EventArgs e)
        {
            lstQueryResults.Items.Clear();
            foreach (Animal animal in animalManager.GetSortedByName())
                lstQueryResults.Items.Add(animal.ToStringSummary());
        }

        // Filters lstQueryResults by the category selected in cmbCategory.
        private void btnFilterCategory_Click(object sender, EventArgs e)
        {
            int index = cmbCategory.SelectedIndex;
            if (index < 0) return;

            CategoryType selected = (CategoryType)cmbCategory.SelectedItem;
            lstQueryResults.Items.Clear();

            foreach (Animal animal in animalManager.GetByCategory(selected))
                lstQueryResults.Items.Add(animal.ToStringSummary());

            if (lstQueryResults.Items.Count == 0)
                lstQueryResults.Items.Add("No animals found in this category.");

        }

        // Filters lstQueryResults by the age range set in nudMinAge and nudMaxAge.
        private void btnFilterAge_Click(object sender, EventArgs e)
        {
            int minAge = (int)nudMinAge.Value;
            int maxAge = (int)nudMaxAge.Value;

            lstQueryResults.Items.Clear();
            foreach (Animal animal in animalManager.GetByAgeRange(minAge, maxAge))
                lstQueryResults.Items.Add(animal.ToStringSummary());

            if (lstQueryResults.Items.Count == 0)
                lstQueryResults.Items.Add($"No animals found between age {minAge} and {maxAge}.");

        }

        // Searches by name or ID and shows the first match, or a notfound message.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(query)) return;

            lstQueryResults.Items.Clear();

            // Try name first, fall back to ID.
            Animal result = animalManager.SearchByName(query)
                         ?? animalManager.SearchById(query);

            if (result != null)
                lstQueryResults.Items.Add(result.ToStringSummary());
            else
                lstQueryResults.Items.Add($"No animal found matching '{query}'.");

        }

        // Updates the stats labels with current total count and average age.
        private void UpdateStats()
        {
            lblTotalCount.Text = $"Total: {animalManager.GetTotalCount()}";
            lblAverageAge.Text = $"Avg age: {animalManager.GetAverageAge():F1} yrs";
        }

        // Populates lstQueryResults with animals sorted by age, youngest first.
        private void btnSortByAge_Click(object sender, EventArgs e)
        {
            lstQueryResults.Items.Clear();
            foreach (Animal animal in animalManager.GetSortedByAge())
                lstQueryResults.Items.Add(animal.ToStringSummary());

        }
    }
}
