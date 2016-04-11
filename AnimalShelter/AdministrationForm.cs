using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            AddTestAnimals();
            RedrawItemsInAnimalListBoxes();
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
                    try
                    {
                        administration.Add(animal);
                    }
                    catch (ArgumentException ae)
                    {
                        MessageBox.Show(ae.Message, "Exception");
                    }
                }
                else
                {
                    throw new ArgumentException("chipnumber not right or too big");
                }
            }
            catch (ArgumentException wie)
            {
                MessageBox.Show(wie.Message, "Error");
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
            administration.Animals.Sort();
            lbReserved.Items.Clear();
            lbNotReserved.Items.Clear();
            foreach (Animal animal in administration.Animals)
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
            Animal selectedAnimal = null;
            if (lbNotReserved.SelectedItem != null)
            {
                selectedAnimal = (Animal)lbNotReserved.SelectedItem;
            }
            else if (lbReserved.SelectedItem != null)
            {
                selectedAnimal = (Animal)lbReserved.SelectedItem;
            }

            if (!administration.Animals.Remove(selectedAnimal))
            {
                MessageBox.Show("No animal was selected.");
            }
            RedrawItemsInAnimalListBoxes();
        }

        private void AddTestAnimals()
        {
            administration.Add(new Cat(1, new SimpleDate(11, 3, 2010), "yaro", "everything"));
            administration.Add(new Dog(2, new SimpleDate(1, 11, 2014), "doggy", null));
            administration.Animals[1].IsReserved = true;
            administration.Add(new Cat(15, new SimpleDate(15, 3, 2015), "visstick", null));
            administration.Add(new Dog(50001, new SimpleDate(19, 7, 2015), "bark", new SimpleDate(16, 9, 2015)));
        }

        private void lbNotReserved_MouseClick(object sender, MouseEventArgs e)
        {
            lbReserved.SelectedItem = null;
        }

        private void lbReserved_MouseClick(object sender, MouseEventArgs e)
        {
            lbNotReserved.SelectedItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Database for animal shelter |*.thisisadatabaseforanimalshelter";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                administration.Save(sfd.FileName);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Database for animal shelter |*.thisisadatabaseforanimalshelter";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    administration.Load(ofd.FileName);
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    MessageBox.Show(fileNotFoundException.Message);
                }
                catch (FileLoadException flException)
                {
                    MessageBox.Show(flException.Message);
                }
                catch (IOException ioException)
                {
                    MessageBox.Show(ioException.Message);
                }
                RedrawItemsInAnimalListBoxes();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file|*.txt|All files|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                administration.Export(sfd.FileName);
            }
        }
    }
}
