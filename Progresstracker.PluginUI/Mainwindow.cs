using Progresstracker.Adapter;
using Progresstracker.PluginUI;
using Progresstracker.UI;

namespace Progresstracker
{
    public partial class Mainwindow : Form
    {
        private readonly IProfileAdapter _profileAdapter;

        public Mainwindow(IProfileAdapter profileAdapter)
        {
            InitializeComponent();
            _profileAdapter = profileAdapter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivityCreationWindow activityCreationWindow = new();
            activityCreationWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var profileCreationWindow = new ProfileCreationWindow(_profileAdapter);
            profileCreationWindow.Show();
        }
    }
}

