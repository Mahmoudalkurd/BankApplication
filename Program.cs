using System.Collections.Generic;
namespace BankApplikation
{
    internal class Program
    {
        static BankAccount Person = new BankAccountperson(1, "Johan");
        static BankAccount Saving = new BankAccountsavings(2, "Johan");
        static BankAccount Investment = new BankAccountsaldo(3, "Johan");
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till bankapplikationen.");
                Console.WriteLine("1. Sätt in pengar");
                Console.WriteLine("2. Ta ut pengar");
                Console.WriteLine("3. Visa saldo");
                Console.WriteLine("4. överföra");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DepositMoney();
                        break;
                    case "2":
                        WithdrawMoney();
                        break;
                    case "3":
                        CheckSaldo();
                        break;
                    case "4":
                        TransferMoney();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }

        public static void TransferMoney()
        {
            Console.WriteLine(" från vilket konto ");
            int accountNummer = Convert.ToInt32(Console.ReadLine());
            if (accountNummer <= 0)
            {
                Console.WriteLine("Invalid account numer");
                return;
            }

            BankAccount fromAccount = Find(accountNummer);
            Console.WriteLine(" till vilket konto");
            accountNummer = Convert.ToInt32(Console.ReadLine());
            if (accountNummer <= 0)
            {
                Console.WriteLine("Invalid account numer");
                return;
            }

            BankAccount tillAccount = Find(accountNummer);
            Console.WriteLine("hur mycker penger");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            fromAccount.Saldo -= amount;
            tillAccount.Saldo += amount;
            Console.WriteLine($"{amount} transfered from {fromAccount.Id} till {tillAccount.Id}");

        }

        public static void CheckSaldo()
        {
            Console.WriteLine("vilket konto vill du kolla");
            int accountNummer = Convert.ToInt32(Console.ReadLine());
            if (accountNummer <= 0)
            {
                Console.WriteLine("Invalid account numer");
                return;
            }

            BankAccount account = Find(accountNummer);
            if (account == null)
            {
                Console.WriteLine("Invalid account");
                return;
            }
            Console.WriteLine($"Saldo för konto {accountNummer} är {account.Saldo}");
        }
        public static void DepositMoney()
        {
            Console.WriteLine("hur mycket penger vill du sätta in ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine (" Till vilket konto vill du flytta pengarna");
            int accountNummer = Convert.ToInt32(Console.ReadLine());
            if (accountNummer <= 0)
            {
                Console.WriteLine("Invalid account numer");
                return;
            }

            BankAccount account = Find(accountNummer);
            if (account == null)
            {
                Console.WriteLine("Invalid account");
                return;
            }
            account.Saldo += amount;
            Console.WriteLine($"{amount} deposited to {accountNummer}");

        }

        public static void WithdrawMoney()
        {
            Console.WriteLine("hur mycket penger vill du ta ut");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(" Till vilket konto vill du flytta pengarna");
            int accountNummer = Convert.ToInt32(Console.ReadLine());
            if (accountNummer <= 0)
            {
                Console.WriteLine("Invalid account numer");
                return;
            }

            BankAccount account = Find(accountNummer);
            if (account == null)
            {
                Console.WriteLine("Invalid account");
                return;
            }
            account.Saldo -= amount;
            Console.WriteLine($"{amount} withdrew from {accountNummer}");

        }
        public static BankAccount? Find(int accountNummer)
        {
            switch(accountNummer)
            {
                case 1:
                    return Person;
                case 2:
                    return Saving;
                case 3:
                    return Investment;
                default: return null;
            }
        }
    }

    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Saldo { get; set; }

        public BankAccount(int id, string name) {
            Id = id;
            Name = name;
            Saldo = 0;
        }
    }

 
    public class BankAccountperson : BankAccount 
    {
        public BankAccountperson (int id, string name): base(id, name) { 
        }
    }

    public class BankAccountsavings : BankAccount
    {
        public BankAccountsavings (int id, string name): base(id, name)
        {

        }

    }
    public class BankAccountsaldo : BankAccount
    {
        public BankAccountsaldo(int id, string name): base(id, name)
        {

        }
    }
}
