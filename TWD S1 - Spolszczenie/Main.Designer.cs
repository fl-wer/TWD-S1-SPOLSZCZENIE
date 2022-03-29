namespace TWD_S1___Spolszczenie
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.patchGame = new System.Windows.Forms.Button();
            this.chooseDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patchGame
            // 
            this.patchGame.Enabled = false;
            this.patchGame.Location = new System.Drawing.Point(12, 54);
            this.patchGame.Name = "patchGame";
            this.patchGame.Size = new System.Drawing.Size(326, 36);
            this.patchGame.TabIndex = 2;
            this.patchGame.Text = "instaluj";
            this.patchGame.UseVisualStyleBackColor = true;
            this.patchGame.Click += new System.EventHandler(this.patchGame_Click);
            // 
            // chooseDirectory
            // 
            this.chooseDirectory.Location = new System.Drawing.Point(12, 12);
            this.chooseDirectory.Name = "chooseDirectory";
            this.chooseDirectory.Size = new System.Drawing.Size(326, 36);
            this.chooseDirectory.TabIndex = 4;
            this.chooseDirectory.Text = "wybierz folder z grą";
            this.chooseDirectory.UseVisualStyleBackColor = true;
            this.chooseDirectory.Click += new System.EventHandler(this.chooseDirectory_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 99);
            this.Controls.Add(this.chooseDirectory);
            this.Controls.Add(this.patchGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TWD S1 - Spolszczenie";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button patchGame;
        private System.Windows.Forms.Button chooseDirectory;
    }
}

