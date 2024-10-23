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
    }
}
