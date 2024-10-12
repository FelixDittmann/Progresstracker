namespace Progresstracker.UI
{
    partial class ActivityCreationWindow
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
            label_Name = new Label();
            label_category = new Label();
            label_goal = new Label();
            textBox_Name = new TextBox();
            textBox_Category = new TextBox();
            textBox_goal = new TextBox();
            label_currentProgress = new Label();
            textBox_currentProgress = new TextBox();
            button_create = new Button();
            SuspendLayout();
            // 
            // label_Name
            // 
            label_Name.AutoSize = true;
            label_Name.Location = new Point(108, 112);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(83, 32);
            label_Name.TabIndex = 0;
            label_Name.Text = "Name:";
            label_Name.Click += label1_Click;
            // 
            // label_category
            // 
            label_category.AutoSize = true;
            label_category.Location = new Point(108, 163);
            label_category.Name = "label_category";
            label_category.Size = new Size(121, 32);
            label_category.TabIndex = 1;
            label_category.Text = "Kategorie:";
            // 
            // label_goal
            // 
            label_goal.AutoSize = true;
            label_goal.Location = new Point(108, 222);
            label_goal.Name = "label_goal";
            label_goal.Size = new Size(58, 32);
            label_goal.TabIndex = 2;
            label_goal.Text = "Ziel:";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(261, 119);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(200, 39);
            textBox_Name.TabIndex = 3;
            // 
            // textBox_Category
            // 
            textBox_Category.Location = new Point(261, 164);
            textBox_Category.Name = "textBox_Category";
            textBox_Category.Size = new Size(200, 39);
            textBox_Category.TabIndex = 4;
            // 
            // textBox_goal
            // 
            textBox_goal.Location = new Point(261, 215);
            textBox_goal.Name = "textBox_goal";
            textBox_goal.Size = new Size(200, 39);
            textBox_goal.TabIndex = 5;
            // 
            // label_currentProgress
            // 
            label_currentProgress.AutoSize = true;
            label_currentProgress.Location = new Point(108, 273);
            label_currentProgress.Name = "label_currentProgress";
            label_currentProgress.Size = new Size(239, 32);
            label_currentProgress.TabIndex = 6;
            label_currentProgress.Text = "Bisheriger Fortschritt:";
            // 
            // textBox_currentProgress
            // 
            textBox_currentProgress.Location = new Point(354, 273);
            textBox_currentProgress.Name = "textBox_currentProgress";
            textBox_currentProgress.Size = new Size(200, 39);
            textBox_currentProgress.TabIndex = 7;
            // 
            // button_create
            // 
            button_create.Location = new Point(381, 398);
            button_create.Name = "button_create";
            button_create.Size = new Size(150, 46);
            button_create.TabIndex = 8;
            button_create.Text = "Erstellen";
            button_create.UseVisualStyleBackColor = true;
            // 
            // ActivityCreationWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 872);
            Controls.Add(button_create);
            Controls.Add(textBox_currentProgress);
            Controls.Add(label_currentProgress);
            Controls.Add(textBox_goal);
            Controls.Add(textBox_Category);
            Controls.Add(textBox_Name);
            Controls.Add(label_goal);
            Controls.Add(label_category);
            Controls.Add(label_Name);
            Name = "ActivityCreationWindow";
            Text = "ActivityCreationWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Name;
        private Label label_category;
        private Label label_goal;
        private TextBox textBox_Name;
        private TextBox textBox_Category;
        private TextBox textBox_goal;
        private Label label_currentProgress;
        private TextBox textBox_currentProgress;
        private Button button_create;
    }
}