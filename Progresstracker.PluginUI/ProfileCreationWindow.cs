using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Progresstracker.Adapter;
using System.Diagnostics;

namespace Progresstracker.PluginUI
{
    public partial class ProfileCreationWindow : Form
    {
        private readonly IProfileAdapter _profileAdapter;
        public ProfileCreationWindow(IProfileAdapter profileAdapter)
        {
            InitializeComponent();
            _profileAdapter = profileAdapter;
        }

        private async void button_create_Click(object sender, EventArgs e)
        {
            string profileName;
            string apiKey;
            string steamProfileId;

            string customApiKey = "123456789abcdefghijklmnopqrstuvw";          //CustomApiKey needed
            if(textBox_apiKey.Text == "") textBox_apiKey.Text = customApiKey;

            profileName = textBox_profileName.Text;
            apiKey = textBox_apiKey.Text;
            steamProfileId = textBox_steamProfileId.Text;

            //Profil erstellen
            var (success, errorMessage) = await _profileAdapter.CreateProfile(profileName, apiKey, steamProfileId);

            if (!success)
            {
                MessageBox.Show(errorMessage, "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Profil erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Fenster schließen, falls gewünscht

        }
    }
}
