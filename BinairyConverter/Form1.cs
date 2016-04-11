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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "textfile(*.txt)|*.txt|All files(*.)|*.*";
            byte[] buffer = new byte[256];
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var mystream = File.Open(ofd.FileName, FileMode.Open))
                    {
                        for (int i = 0; i < mystream.Length + 1; i = i + 256)
                        {
                            mystream.Read(buffer, i, 256);
                            var sbuffer = System.Text.Encoding.Default.GetString(buffer);
                            Console.WriteLine(sbuffer.IndexOf("Cat: "));
                            if (sbuffer.IndexOf("Dog: ") > -1)
                            {
                                string chipNumber = sbuffer.Substring(sbuffer.IndexOf(":") + 1, sbuffer.IndexOf(":") - sbuffer.IndexOf(","));
                                Console.WriteLine(chipNumber);
                                //string dogInfo = sbuffer.Substring(sbuffer.IndexOf(":") + 1, sbuffer.IndexOf(":") - sbuffer.IndexOf(","));
                            }
                            else if (sbuffer.IndexOf("Cat: ") > -1)
                            {

                            }
                            else
                            {
                                //throw new InvalidDataException("File is invalid");
                            }
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
