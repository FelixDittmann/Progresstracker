using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progresstracker.UI
{
    public partial class ActivityCreationWindow : Form
    {
        public ActivityCreationWindow()
        {
            InitializeComponent();
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            var emptyTextBoxes = CheckForEmptyTextBoxes();

            if (emptyTextBoxes.Any())
            {
                List<string> emptyTextBoxesNames = [];
                foreach (TextBox textBox in emptyTextBoxes)
                {
                    emptyTextBoxesNames.Add(textBox.Name[(textBox.Name.IndexOf('_') + 1)..]);
                }
                string message = emptyTextBoxes.Count > 1 ?
                    $"Bitte füllen Sie folgende Felder aus: {string.Join(", ", emptyTextBoxesNames)}." :
                    $"Bitte füllen Sie das Feld {emptyTextBoxesNames.Single()} aus.";
                MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create new Activity. --> new ActivityHandler und Daten übergeben
            }
        }

        private List<TextBox> CheckForEmptyTextBoxes()
        {
            var emptyTextBoxes = Controls.OfType<TextBox>()
            .Where(textBox => string.IsNullOrEmpty(textBox.Text))
            .Select(textBox => textBox)
            .ToList();
            return emptyTextBoxes;
        }
    }
}
