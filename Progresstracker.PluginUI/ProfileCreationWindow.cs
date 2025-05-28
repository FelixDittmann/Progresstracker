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
            Debug.WriteLine("Adapter ist null? " + (_profileAdapter == null));
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("UI: Button-Click erfolgreich");

            string profileName;
            string apiKey;
            string steamProfileId;

            string customApiKey = "123456789";          //CustomApiKey needed
            //if(textBox_steamProfileId.Text == "")     no SteamProfileID needed

            if (textBox_profileName.Text == "")
            {
                string message = "Bitte Profilname eingeben!";
                MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(textBox_apiKey.Text == "") textBox_apiKey.Text = customApiKey;
                profileName = textBox_profileName.Text;
                apiKey = textBox_apiKey.Text;
                steamProfileId = textBox_steamProfileId.Text;
                //Profil erstellen
                try
                {
                    _profileAdapter.CreateProfile(profileName, apiKey, steamProfileId);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Fehler am Anfang");

                }
            }
        }
    }
}
