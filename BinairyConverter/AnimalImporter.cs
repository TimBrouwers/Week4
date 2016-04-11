using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalShelterImporter
{
    public partial class AnimalInfoReader : Form
    {
        public AnimalInfoReader()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Importer importer = new Importer();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "textfile(*.txt)|*.txt|All files(*.)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    importer.Import(ofd.FileName);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Could not read file. \n" + ex.Message);
                }
            }
            lbDogs.Items.Clear();
            lbCats.Items.Clear();
            lbCats.Items.AddRange(importer.CatList.ToArray());
            lbDogs.Items.AddRange(importer.DogList.ToArray());
        }
    }
}
