using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace McLarenWheelSprite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string folderLocation = @"";
        List<FileInfo> files = new List<FileInfo>();
        List<FileInfo> filesRemove = new List<FileInfo>();

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldDlg = new FolderBrowserDialog();
            fldDlg.ShowNewFolderButton = false;
            DialogResult result = fldDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolder.Text = fldDlg.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Part1();
        }
        public void renewList()
        {
            DirectoryInfo dir = new DirectoryInfo(folderLocation);

            files = dir.GetFiles().ToList();

            
        }

        public void Part1()
        {

            try {

                

                folderLocation = txtFolder.Text;

                renewList();

                if (files.Count == 0)
            {
                MessageBox.Show("No files in folder", "", MessageBoxButtons.OK);
                return;
            }

            

            int i = 0;

            foreach (FileInfo f in files)
            {
                if (i > 1)
                {
                    i = 0;
                }
                if (i == 1)
                {
                    filesRemove.Add(f);
                }
                i++;
                
            }
            foreach (FileInfo fr in filesRemove)
            {
                File.Delete(fr.FullName);
            }
            filesRemove.Clear();

            Part2();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK);
            }

        }

        public void Part2()
        {
            try
            {

            
            renewList();

            string pname1 = "02";
            string pname2 = "06";
            string pname3 = "010";

            FileInfo p1 = files.FirstOrDefault(s => s.FullName.Contains(pname1));
            FileInfo p2 = files.FirstOrDefault(s => s.FullName.Contains(pname2));
            FileInfo p3 = files.FirstOrDefault(s => s.FullName.Contains(pname3));

            File.Delete(p1.FullName);
            File.Delete(p2.FullName);
            File.Delete(p3.FullName);
            filesRemove.Clear();

            Part3();

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK);
            }
        }

        public void Part3()
        {

            try
            {

            
            renewList();

            int n = 26;

            foreach (FileInfo fr2 in files)
            {
                
                string nr = n.ToString();

                if (fr2.FullName.Contains(nr))
                {
                    filesRemove.Add(fr2);

                    n++;
                    n++;
                    n++;
                    n++;
                }
                
            }

            foreach (FileInfo flr in filesRemove)
            {
                File.Delete(flr.FullName);

            }

            MessageBox.Show("All Done", "All Done", MessageBoxButtons.OK);

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message, "", MessageBoxButtons.OK);
            }
        }

        public void DoNothing()
        {

        }

        
    }
}
