using Progresstracker.Adapter;
using Progresstracker.Application;
using Progresstracker.Domain.DataObjects;
using Progresstracker.PluginUI;
using Progresstracker.UI;
using Progresstracker.Application.DataObjectHandler;

namespace Progresstracker
{
    public partial class Mainwindow : Form
    {
        private readonly IProfileAdapter _profileAdapter;

        public Mainwindow(IProfileAdapter profileAdapter)
        {
            InitializeComponent();
            _profileAdapter = profileAdapter;

            ProfileService.ProfileCreated += OnProfileCreated;
            this.Load += MainWindow_Load; // Event für asynchrone Initialisierung
        }

        private async void MainWindow_Load(object? sender, EventArgs e)
        {
            await LoadProfilesAsync();
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

        private async Task LoadProfilesAsync()
        {
            var profiles = await _profileAdapter.GetAllProfiles();
            comboBoxProfiles.DataSource = profiles;
            comboBoxProfiles.DisplayMember = "Name";
            comboBoxProfiles.ValueMember = "Id";
        }

        private async void OnProfileCreated(object? sender, UserProfile profile)
        {
            await LoadProfilesAsync();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ProfileService.ProfileCreated -= OnProfileCreated;
        }
    }
}

