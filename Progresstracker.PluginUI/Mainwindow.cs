using Progresstracker.Adapter;
using Progresstracker.Application;
using Progresstracker.Application.DataObjectHandler;
using Progresstracker.PluginUI;
using Progresstracker.UI;

namespace Progresstracker
{
    public partial class Mainwindow : Form
    {
        public Mainwindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivityCreationWindow activityCreationWindow = new();
            activityCreationWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var profileService = new ProfileService(profileRepository); //TODO
            var profileAdapter = new ProfileAdapter(profileService);
            ProfileCreationWindow profileCreationWindow = new(profileAdapter);
            profileCreationWindow.Show();
        }
    }
}
