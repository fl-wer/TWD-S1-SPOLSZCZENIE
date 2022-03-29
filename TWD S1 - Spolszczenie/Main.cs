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

namespace TWD_S1___Spolszczenie
{
    public partial class Main : Form
    {
        // initializing things, ignore this
        public Main() { InitializeComponent(); }

        // this runs when you start program, nothing here so ignore
        private void Main_Load(object sender, EventArgs e) { }

        // choosing game directory, has to be exact game path, not folder inside
        private void chooseDirectory_Click(object sender, EventArgs e)
        {
            // clearing selected path before selection happens
            // this is for the check below to see if it's blank
            folderBrowser.SelectedPath = "";

            // show dialogue with folder selection
            folderBrowser.ShowDialog();

            // if user cancelled selecting path it will be blank
            if (folderBrowser.SelectedPath != "")
            {
                // making sure all folders exist so writing files won't fail
                if (Directory.Exists(folderBrowser.SelectedPath + "\\" + "Pack\\default") &&
                Directory.Exists(folderBrowser.SelectedPath + "\\" + "Pack\\WalkingDead102") &&
                Directory.Exists(folderBrowser.SelectedPath + "\\" + "Pack\\WalkingDead103") &&
                Directory.Exists(folderBrowser.SelectedPath + "\\" + "Pack\\WalkingDead104") &&
                Directory.Exists(folderBrowser.SelectedPath + "\\" + "Pack\\WalkingDead105"))
                {
                    // all folders found
                    patchGame.Enabled = true;
                    showInfo("lokalizacja poprawna.");
                }
                else
                {
                    // some folders were not found
                    patchGame.Enabled = false;
                    showError("lokalizacja niepoprawna.");
                }
            }
            // disabling button, in some cases it might be enabled at this point
            else patchGame.Enabled = false;
        }

        // writes language patching files into game folder
        private void patchGame_Click(object sender, EventArgs e)
        {
            // putting game + pack path to 1 variable for readability
            string epPath = folderBrowser.SelectedPath + "\\Pack\\";

            // putting in try as this can throw exception in some cases
            try 
            {
                File.WriteAllBytes(epPath + "\\default\\0.ttarch", Properties.Resources.ep1);
                File.WriteAllBytes(epPath + "\\WalkingDead102\\0.ttarch", Properties.Resources.ep2);
                File.WriteAllBytes(epPath + "\\WalkingDead103\\0.ttarch", Properties.Resources.ep3);
                File.WriteAllBytes(epPath + "\\WalkingDead104\\0.ttarch", Properties.Resources.ep4);
                File.WriteAllBytes(epPath + "\\WalkingDead105\\0.ttarch", Properties.Resources.ep5);

                // success
                showInfo("patchowanie zakończone sukcesem, miłej gry");
            }
            // something failed, maybe file already there and in use
            catch { showError("błąd podczas patchowania"); }
        }

        // show custom message box with warning or error icon
        public static void showError(string message) { MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public static void showInfo(string message) { MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }
    }
}
