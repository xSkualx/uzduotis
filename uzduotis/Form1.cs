using uzduotis.NewFolder;
using uzduotis.Services;

namespace uzduotis
{
    public partial class Form1 : Form
    {
        private VotesService votesService = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadOrUpdateInfo();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Vote vote = new Vote();

            vote.Score = int.Parse(voteField.Text);
            vote.Language = languageField.Text;

            votesService.AddVote(vote);
            loadOrUpdateInfo();
        }

        private void loadOrUpdateInfo()
        {
            
            listView1.Items.Clear();
            List<string> languages = new List<string>(new string[] { "C", "C#", "Java" });
            foreach (string language in languages)
            {
                ListViewItem item = new ListViewItem(language);
                item.SubItems.Add(votesService.CalcMinScore(language).ToString());
                item.SubItems.Add(votesService.CalcMaxScore(language).ToString());
                item.SubItems.Add(votesService.CalcAverageScore(language).ToString());
                item.SubItems.Add(votesService.CountVotes(language).ToString());
                listView1.Items.Add(item);
            }

            listView2.Items.Clear();
            foreach(var vote in votesService.FindAllVotes())
            {
                ListViewItem item = new ListViewItem(vote.Id.ToString());
                item.SubItems.Add(vote.Language);
                item.SubItems.Add(vote.Score.ToString());
                listView2.Items.Add(item);
            }
            
        }

        private void voteField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                errorProvider1.SetError(label3, "Allow only numeric values!");
                label3.Text = "Allow only numeric values!";
            }
            else
            {
                errorProvider1.SetError(label3, "");
                label3.Text = "";
            }
        }
    }
}