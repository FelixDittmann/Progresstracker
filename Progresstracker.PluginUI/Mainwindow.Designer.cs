﻿namespace Progresstracker
{
    partial class Mainwindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            comboBoxProfiles = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(51, 28);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 0;
            button1.Text = "Aktivität anlegen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(51, 55);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 1;
            button2.Text = "Profil anlegen";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBoxProfiles
            // 
            comboBoxProfiles.FormattingEnabled = true;
            comboBoxProfiles.Location = new Point(500, 28);
            comboBoxProfiles.Name = "comboBoxProfiles";
            comboBoxProfiles.Size = new Size(121, 23);
            comboBoxProfiles.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(436, 36);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 3;
            label1.Text = "Profiles:";
            // 
            // Mainwindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 394);
            Controls.Add(label1);
            Controls.Add(comboBoxProfiles);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Mainwindow";
            Text = "ProgressTracker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox comboBoxProfiles;
        private Label label1;
    }
}
