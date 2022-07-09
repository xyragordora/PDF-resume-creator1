using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace resume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void read_Click(object sender, EventArgs e)
        {
            Information info = new Information()
            {
                Surname = " GORDORA",
                FirstName = "XYRA SHENNE",
                MiddleName = "A.",
                Address = "Brgy. Villa Nava Gumaca, Quezon",
                Email = "xyragordora@gmail.com",
                Phone = "097263394823",
                Elementary = "Gumaca West Central School",
                syELEM = "2009-2015",
                Highschool = "Gumaca National High School",
                syHS = "2015-2021",
                College = "Polytechnic University of the Philippines",
                syCOL = "2021-2025",
                Degree = "Bachelor of Science in Computer Engineering",
                GPA = "1.15",
                Experiences = "Provided support for project managers",
                Languages = "English, Filipino",
                Skills = "Communication skills, Creativity, Flexible, Leadership, Multitasking, Strategic Thinking, Time Management",
                Objectives = "To obtain a challenging career with a progressive organization" + " that will allow me to broaden my skills and knowledge." +
                "Grow professionally that will allow me to fully utilize my expertise and experience while also making a significant" +
                "contribution to the company's success. Eyeing an entry-level position in a high-level professional " +
                "environment to start up my career." + "\nTo pursue careers with a prestigious organisation where I can" +
                " effectively integrate my skills and computer engineering studies background."


            };
            string file_name = info.Surname + "_" + info.FirstName;
            string saveJSON = JsonConvert.SerializeObject(info, Formatting.None);
            File.WriteAllText(@"C:\Users\chris\OneDrive\Documents\Json File\" + file_name + ".json", saveJSON);
            MessageBox.Show("You created JSON file." + "\n" + "You can save it now as PDF.");
        }

        private void save_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Filter = "json file|*.json", };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string file = openFile.FileName;
                string json = File.ReadAllText(file);
                Information resultInformation = JsonConvert.DeserializeObject<Information>(json);
                richTextBox1.Text = resultInformation.ToString();
            }
            else
            {
                MessageBox.Show("There is no file.");
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            try
            {
                
                string rtbresult = richTextBox1.Text;
                string[] cutter = new string[] { " " };
                string[] name_cut = rtbresult.Split(cutter, StringSplitOptions.None);
                string file_name = name_cut[2] + "_" + name_cut[1] + " " + name_cut[3] + name_cut[4];
                using (SaveFileDialog save = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true, FileName = file_name })
                {
                    if (richTextBox1.Text == "")
                    {
                        MessageBox.Show("There is no file to save.");
                    }
                    else if (save.ShowDialog() == DialogResult.OK)
                    {
                        Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                            doc.Open();


                           

                            iTextSharp.text.Font pfont1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 20,
                                iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                            Paragraph pgraph1 = new Paragraph(name_cut[2] + ", " + name_cut[1] + " " + name_cut[3] + " " + name_cut[4], pfont1);
                            pgraph1.Alignment = Element.ALIGN_LEFT;
                            doc.Add(pgraph1);

                            pfont1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14,
                                iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                            Paragraph pgraph2 = new iTextSharp.text.Paragraph(richTextBox1.Text, pfont1);
                            pgraph2.Alignment = Element.ALIGN_JUSTIFIED;
                            doc.Add(pgraph2);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            doc.Close();
                            MessageBox.Show("File is successfully saved.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("There is no file to save.");

                {
                       
                    
                }
            }
        }
    }
}




