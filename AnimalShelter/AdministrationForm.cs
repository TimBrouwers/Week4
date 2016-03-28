using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalShelter
{
    public partial class AdministrationForm : Form
    {
        private readonly Administration administration = new Administration();

        /// <summary>
        /// Creates the form for doing adminstrative tasks
        /// </summary>
        public AdministrationForm()
        {
            InitializeComponent();
            animalTypeComboBox.SelectedIndex = 0;
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
            try
            {
                int chipregistationnr;
                if (Int32.TryParse(tbChipregistrationNr.Text, out chipregistationnr))
                {
                    DateTime Birthdate = dtpBirthdate.Value;
                    Animal animal = null;
                    switch (animalTypeComboBox.SelectedItem.ToString())
                    {
                        case "Dog":
                            {
                                
                                DateTime LastWalk = dtpLastwalk.Value;
                                animal = new Dog(Convert.ToInt32(tbChipregistrationNr.Text),
                                    new SimpleDate(Birthdate.Day, Birthdate.Month, Birthdate.Year),
                                    tbName.Text,
                                    new SimpleDate(LastWalk.Day, LastWalk.Month, LastWalk.Year));
                            }
                            break;
                        case "Cat":
                            {
                                animal = new Cat(Convert.ToInt32(tbChipregistrationNr.Text),
                                    new SimpleDate(Birthdate.Day, Birthdate.Month, Birthdate.Year),
                                    tbName.Text,
                                    tbBadhabits.Text);
                            }
                            break;
                        default:
                            throw new NotImplementedException("animal is not known");
                    }
                    animal.IsReserved = rbIsReservedYes.Checked;
                    administration.Add(animal);
                }
                else
                {
                    throw new WrongInputException("chipnumber not right");
                }
            }
            catch (WrongInputException wie)
            {
                MessageBox.Show(wie.Message, "Error");
            }
            catch (ExistingChipNumberException ecne)
            {
                MessageBox.Show(ecne.Message, "Error");
            }



            RedrawItemsInAnimalListBoxes();
        }

        private void animalTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (animalTypeComboBox.SelectedItem.ToString())
            {
                case "Dog":
                    TXTLastWalk.Visible = true;
                    dtpLastwalk.Visible = true;
                    TXTBadhabits.Visible = false;
                    tbBadhabits.Visible = false;
                    break;
                case "Cat":
                    TXTBadhabits.Visible = true;
                    tbBadhabits.Visible = true;
                    TXTLastWalk.Visible = false;
                    dtpLastwalk.Visible = false;
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }

        private void tbSearchWithChipnumber_TextChanged(object sender, EventArgs e)
        {
            int chipnummer;
            Animal foundAnimal = null;
            string chipNumberText = tbSearchWithChipnumber.Text;
            if (int.TryParse(chipNumberText, out chipnummer))
            {
                foundAnimal = administration.FindAnimal(chipnummer);
            }
            lbFound.Items.Clear();
            if (foundAnimal != null)
            {
                lbFound.Items.Add(foundAnimal);
            }
        }

        private void ChangeReservationFromListbox(ListBox listbox)
        {
            if (listbox.SelectedItem != null)
            {
                Animal selectedAnimal = (Animal)listbox.SelectedItem;
                selectedAnimal.IsReserved = !selectedAnimal.IsReserved;
            }
            RedrawItemsInAnimalListBoxes();
        }
        private void btnChangeToReserved_Click(object sender, EventArgs e)
        {
            ChangeReservationFromListbox(lbNotReserved);
        }

        private void btnChangeToNotReserved_Click(object sender, EventArgs e)
        {
            ChangeReservationFromListbox(lbReserved);
        }

        private void RedrawItemsInAnimalListBoxes()
        {
            //new
            lbReserved.Items.Clear();
            lbNotReserved.Items.Clear();
            foreach (Animal animal in administration.animals)
            {
                if (animal.IsReserved)
                {
                    lbReserved.Items.Add(animal);
                }
                else
                {
                    lbNotReserved.Items.Add(animal);
                }
            }
        }

        private void btnRemovefromList_Click(object sender, EventArgs e)
        {
            int counter = 0;
            Animal selectedAnimal = (Animal) lbAnimals.SelectedItem;
            if (selectedAnimal != null)
            {
                foreach (var an in administration.animals)
                {
                    if (an == selectedAnimal)
                    {
                        break;
                    }
                    counter++;
                }

                if (administration.animals.Count > 0)
                {
                    Animal.ChipNumbers.Remove(selectedAnimal.ChipRegistrationNumber);
                    administration.animals.RemoveAt(counter);
                }
            }
            
            RedrawItemsInAnimalListBoxes();
        }

        private void lbReserved_SelectedIndexChanged(object sender, EventArgs e)
        {
                lbNotReserved.SelectedItem = null;
        }
    }
}
