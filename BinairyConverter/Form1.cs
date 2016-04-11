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

namespace BinairyConverter
{
    public partial class AnimalInfoReader : Form
    {
        public AnimalInfoReader()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Stream mystream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "textfile(*.txt)|*.txt|All files(*.)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystream = ofd.OpenFile()) != null)
                    {
                        using (mystream)
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Could not read file" + ex.Message);
                }
            }
        }
    }
}
