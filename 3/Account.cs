struct AccountChange {
    DateTime date;
    float amount;

    public AccountChange(DateTime date, float amount){
        this.date = date;
        this.amount = amount;
    }

    public string getInfo(){
        return $"Date: {this.date.ToString()}, Amount: {amount.ToString()}; ";
    }
}

class Account {
    public readonly int id;
    public float balance {get; private set;}

    List<AccountChange> incomeHistory;
    List<AccountChange> outcomeHistory;

    Account(Bank bank, int id){
        this.id = id;
        this.balance = 0;
        this.incomeHistory = new List<AccountChange>();
        this.outcomeHistory = new List<AccountChange>();
        bank.AddAccount(this);
    }

    static public Account OpenAccount(Client client, Bank bank, int id){
        Account account = new Account(bank, id);
        client.AddAccount(account.id);
        return account;
    }

    static public void CloseAccount(out Account? account){
        account = null; 
    }

    public float inputMoney(float money){
        this.balance += money;
        this.incomeHistory.Add(new AccountChange(DateTime.Now, money));
        return this.balance;
    }

    public float outputMoney(float money){
        this.balance -= money;
        this.outcomeHistory.Add(new AccountChange(DateTime.Now, money));
        return this.balance;
    }

    public string getHumanReadableIncomeHistory(){
        return string.Join(" ", incomeHistory.Select((el) => el.getInfo()).ToArray());
    }

    public string getHumanReadableOutcomeHistory(){
        return string.Join(" ", outcomeHistory.Select((el) => el.getInfo()).ToArray());
    }
}