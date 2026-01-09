using System;

namespace lab2
{
    public class ATMEventArgs : EventArgs
    {
        public string Message { get; }
        public bool Success { get; }
        public ATMEventArgs(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }

    public class Account
    {
        public string CardNumber { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }
    }

    public class AutomatedTellerMachine
    {
        public string Id { get; set; }
        public decimal CashInMachine { get; set; }
        private Account _currentAccount;

        public event EventHandler<ATMEventArgs> OnWithdraw;
        public event EventHandler<ATMEventArgs> OnMessage;

        public bool Authenticate(Account acc, string pin)
        {
            if (acc.PinCode == pin)
            {
                _currentAccount = acc;
                return true;
            }
            return false;
        }

        public void Withdraw(decimal amount)
        {
            if (_currentAccount == null)
            {
                OnWithdraw?.Invoke(this, new ATMEventArgs("Помилка: Немає авторизації!", false));
                return;
            }

            if (amount <= _currentAccount.Balance && amount <= CashInMachine)
            {
                _currentAccount.Balance -= amount;
                CashInMachine -= amount;
                OnWithdraw?.Invoke(this, new ATMEventArgs($"Успішно знято {amount} грн", true));
            }
            else
            {
                OnWithdraw?.Invoke(this, new ATMEventArgs("Недостатньо коштів!", false));
            }
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (_currentAccount != null && _currentAccount.Balance >= amount)
            {
                _currentAccount.Balance -= amount;
                toAccount.Balance += amount;
                OnMessage?.Invoke(this, new ATMEventArgs($"Переказано {amount} на карту {toAccount.CardNumber}", true));
            }
            else
            {
                OnMessage?.Invoke(this, new ATMEventArgs("Переказ неможливий!", false));
            }
        }

        public class Bank
        {
            public string Name { get; set; }
            public void OnATMMessageReceived(object sender, ATMEventArgs e)
            {
                Console.WriteLine($"[БАНК {Name} ОПОТЕРЕЖЕННЯ]: {e.Message}");
            }
        }
    }
}