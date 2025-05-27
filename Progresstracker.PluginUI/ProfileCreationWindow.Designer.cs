namespace Progresstracker.PluginUI
{
    partial class ProfileCreationWindow
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
            button_create = new Button();
            textBox_profileName = new TextBox();
            textBox_apiKey = new TextBox();
            textBox_steamProfileId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button_create
            // 
            button_create.Location = new Point(211, 191);
            button_create.Name = "button_create";
            button_create.Size = new Size(75, 23);
            button_create.TabIndex = 0;
            button_create.Text = "Erstellen";
            button_create.UseVisualStyleBackColor = true;
            button_create.Click += button_create_Click;
            // 
            // textBox_profileName
            // 
            textBox_profileName.Location = new Point(186, 70);
            textBox_profileName.Name = "textBox_profileName";
            textBox_profileName.Size = new Size(100, 23);
            textBox_profileName.TabIndex = 1;
            // 
            // textBox_apiKey
            // 
            textBox_apiKey.Location = new Point(186, 102);
            textBox_apiKey.Name = "textBox_apiKey";
            textBox_apiKey.Size = new Size(100, 23);
            textBox_apiKey.TabIndex = 2;
            // 
            // textBox_steamProfileId
            // 
            textBox_steamProfileId.Location = new Point(186, 131);
            textBox_steamProfileId.Name = "textBox_steamProfileId";
            textBox_steamProfileId.Size = new Size(100, 23);
            textBox_steamProfileId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 78);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 110);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "APIKey:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 139);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 6;
            label3.Text = "SteamProfileID:";
            // 
            // ProfileCreationWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_steamProfileId);
            Controls.Add(textBox_apiKey);
            Controls.Add(textBox_profileName);
            Controls.Add(button_create);
            Name = "ProfileCreationWindow";
            Text = "ProfileCreationWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_create;
        private TextBox textBox_profileName;
        private TextBox textBox_apiKey;
        private TextBox textBox_steamProfileId;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}