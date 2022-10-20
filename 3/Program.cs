class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        Console.WriteLine("Testing the classes");
        Client client = new Client("Ivan", "Ivanov", "Ivanovich", 21, "BMSTU", bank);
        Account? account = Account.OpenAccount(client, bank, 1);
        Console.WriteLine($"{string.Join(" ", client.accountsNumbers.ToArray())}");
        account.inputMoney(123.2f);
        account.inputMoney(443.8f);
        Console.WriteLine($"After adding money the balance is {account.balance}");
        account.outputMoney(15.5f);
        account.outputMoney(39.9f);
        Console.WriteLine($"After taking money the balance is {account.balance}");
        Console.WriteLine($"Income history: {account.getHumanReadableIncomeHistory()}");
        Console.WriteLine($"Outcome history: {account.getHumanReadableOutcomeHistory()}");
        Account.CloseAccount(out account);
        Console.WriteLine($"Account after deletion: {account}");
    }
}

