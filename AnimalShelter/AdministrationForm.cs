using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalShelter
{
    public partial class AdministrationForm : Form
    {
        /// <summary>
        /// The (only) animal in this administration (for now....)
        /// </summary>
        private Animal animal;

        /// <summary>
        /// Creates the form for doing adminstrative tasks
        /// </summary>
        public AdministrationForm()
        {
            InitializeComponent();
            animalTypeComboBox.SelectedIndex = 0;
            animal = null;
        }

        /// <summary>
        /// Create an Animal object and store it in the administration.
        /// If "Dog" is selected in the animalTypeCombobox then a Dog object should be created.
        /// If "Cat" is selected in the animalTypeCombobox then a Cat object should be created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createAnimalButton_Click(object sender, EventArgs e)
        {
            // TODO: See method description
            int chipregistationnr;
            try
            {
                if (Int32.TryParse(tbChipregistrationNr.Text, out chipregistationnr))
                {
                    if (animalTypeComboBox.SelectedItem.ToString() == "Dog")
                    {
                        DateTime Birthdate = dtpBirthdate.Value;
                        DateTime LastWalk = dtpLastwalk.Value;
                        animal = new Dog(Convert.ToInt32(tbChipregistrationNr.Text),
                            new SimpleDate(Birthdate.Day, Birthdate.Month, Birthdate.Year),
                            tbName.Text,
                            new SimpleDate(LastWalk.Day, LastWalk.Month, LastWalk.Year));
                        if (rbIsReservedYes.Checked)
                        {
                            animal.IsReserved = true;
                        }
                        else
                        {
                            animal.IsReserved = false;
                        }
                    }
                    else if (animalTypeComboBox.SelectedItem.ToString() == "Cat")
                    {
                        DateTime Birthdate = dtpBirthdate.Value;
                        DateTime LastWalk = dtpLastwalk.Value;
                        animal = new Cat(Convert.ToInt32(tbChipregistrationNr.Text),
                            new SimpleDate(Birthdate.Day, Birthdate.Month, Birthdate.Year),
                            tbName.Text,
                            tbBadhabits.Text);
                        if (rbIsReservedYes.Checked)
                        {
                            animal.IsReserved = true;
                        }
                        else
                        {
                            animal.IsReserved = false;
                        }
                    }
                    else
                    {
                        throw new FormatException("fa;lfaslfas");
                    }
                }
                else
                {
                    throw new FormatException("input wrong");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Show the info of the animal referenced by the 'animal' field. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showInfoButton_Click(object sender, EventArgs e)
        {
            // TODO: See method description
            if (animal != null)
            {
                MessageBox.Show(animal.ToString());
            }
        }

        private void animalTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animalTypeComboBox.SelectedItem.ToString() == "Dog")
            {
                TXTLastWalk.Visible = true;
                dtpLastwalk.Visible = true;
                TXTBadhabits.Visible = false;
                tbBadhabits.Visible = false;
            }
            else if (animalTypeComboBox.SelectedItem.ToString() == "Cat")
            {
                TXTBadhabits.Visible = true;
                tbBadhabits.Visible = true;
                TXTLastWalk.Visible = false;
                dtpLastwalk.Visible = false;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            Administration.Add(animal);
        }

        private void tbSearchWithChipnumber_TextChanged(object sender, EventArgs e)
        {
            Administration.FindAnimal(Int32.Parse(tbSearchWithChipnumber.Text));
        }
    }
}
