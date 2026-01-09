using System;
using lab2;
using static lab2.AutomatedTellerMachine;

namespace ATM.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new AutomatedTellerMachine { Id = "ATM-01", CashInMachine = 5000 };
            var acc = new Account { CardNumber = "1111", PinCode = "1234", Balance = 1000 };
            var bank = new Bank { Name = "Приват" };

            atm.OnWithdraw += (s, e) => Console.WriteLine($"Подія зняття: {e.Message}");
            atm.OnMessage += bank.OnATMMessageReceived;

            Console.WriteLine("Вітаємо у банкоматі");
            Console.Write("Введіть ПІН: ");
            string pin = Console.ReadLine();

            if (atm.Authenticate(acc, pin))
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n1. Баланс | 2. Зняти | 3. Переказ | 4. Вихід");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Ваш баланс: {acc.Balance} грн");
                            break;
                        case "2":
                            Console.Write("Сума зняття: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                                atm.Withdraw(amount);
                            break;
                        case "3":
                            Console.Write("Сума переказу: ");
                            decimal.TryParse(Console.ReadLine(), out decimal tAmount);
                            atm.Transfer(new Account { CardNumber = "2222" }, tAmount);
                            break;
                        case "4":
                            exit = true;
                            break;
                    }
                }
            }
            else { Console.WriteLine("Невірний ПІН!"); }
            Console.ReadKey();
        }
    }
}