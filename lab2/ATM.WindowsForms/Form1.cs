using System;
using System.Windows.Forms;
using lab2;

namespace ATM.WindowsForms
{
    public partial class Form1 : Form
    {
        private AutomatedTellerMachine _atm;
        private Account _userAccount;

        public Form1()
        {
            InitializeComponent();

            _atm = new AutomatedTellerMachine { Id = "ATM-01", CashInMachine = 10000 };
            _userAccount = new Account { CardNumber = "1234", PinCode = "1111", Balance = 5000 };

            _atm.Authenticate(_userAccount, "1111");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                _atm.OnWithdraw += ShowWindowMessage;
                _atm.Withdraw(amount);
                _atm.OnWithdraw -= ShowWindowMessage;
            }
            else
            {
                MessageBox.Show("Введіть коректну суму!");
            }
        }

        private void ShowWindowMessage(object sender, ATMEventArgs e)
        {
            MessageBox.Show(e.Message, e.Success ? "Успіх" : "Помилка");
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Account target = new Account { CardNumber = txtTargetCard.Text, Balance = 0 };

            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                _atm.OnMessage += ShowWindowMessage;
                _atm.Transfer(target, amount);
                _atm.OnMessage -= ShowWindowMessage;
            }
            else
            {
                MessageBox.Show("Введіть коректну суму для переказу.");
            }
        }
    }
}