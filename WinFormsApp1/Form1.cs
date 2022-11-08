using System.ComponentModel;

namespace WinFormsApp1
{

    public interface IMessageService
    {
        DialogResult Show(string message);
    }

    public class Message : IMessageService
    {
        public DialogResult Show(string message) => MessageBox.Show(message);

    }
    public partial class Form1 : Form
    {
        private readonly IMessageService message;
        public Form1()
        {
            InitializeComponent();

            message = DependencyInjector.Retrieve<IMessageService>();
        }

        public Form1(IMessageService messageService)
        {
            InitializeComponent();
            
            message = messageService;
        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                message.Show("You have to enter a name");
                return;
            }

            if (numBalance.Value < 10_000 || numBalance.Value > 1_000_000)
            {
                message.Show("Must be between 10k and 1MM");
                return;
            }

            if (File.Exists("authkey.txt") is false)
            {
                message.Show("Missing authorization key");
                return;
            }

            lblResults.Text = (numBalance.Value * numInterestRate.Value).ToString("c");
        }
    }
}