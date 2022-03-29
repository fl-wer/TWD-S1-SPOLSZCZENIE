using Microsoft.WindowsAPICodePack.Dialogs;
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

        // created for readability and cross function reference
        string selectedDirectory = "";

        // choosing game directory, has to be exact game path, not folder inside
        private void chooseDirectory_Click(object sender, EventArgs e)
        {
            // creating new dialog object, we're using this
            // because it has better gui and it's easier to select folders
            var folderBrowser = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "wybierz folder"
            };

            // if user cancelled selecting path it will be blank
            if (folderBrowser.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // making sure all folders exist so writing files won't fail
                if (Directory.Exists(folderBrowser.FileName + "\\" + "Pack\\default") &&
                Directory.Exists(folderBrowser.FileName + "\\" + "Pack\\WalkingDead102") &&
                Directory.Exists(folderBrowser.FileName + "\\" + "Pack\\WalkingDead103") &&
                Directory.Exists(folderBrowser.FileName + "\\" + "Pack\\WalkingDead104") &&
                Directory.Exists(folderBrowser.FileName + "\\" + "Pack\\WalkingDead105"))
                {
                    // all folders found
                    selectedDirectory = folderBrowser.FileName;
                    showInfo("lokalizacja poprawna.");
                    patchGame.Enabled = true;
                }
                else
                {
                    // some folders were not found
                    showError("lokalizacja niepoprawna.");
                    patchGame.Enabled = false;
                }
            }
            // disabling button, in some cases it might be enabled at this point
            else patchGame.Enabled = false;
        }

        // writes language patching files into game folder
        private void patchGame_Click(object sender, EventArgs e)
        {
            // putting game + pack path to 1 variable for readability
            string epPath = selectedDirectory + "\\Pack\\";

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
