using System.Collections.Generic;

class Bank {
    List<Client> clients;
    List<Account> accounts;

    public Bank(){
        this.clients = new List<Client>();
        this.accounts = new List<Account>();
    }

    public List<Client> AddClient(Client client){
        clients.Add(client);
        return clients;
    }

    public List<Account> AddAccount(Account account){
        accounts.Add(account);
        return accounts;
    }

    public Client? FindClientByName(string name){
        return clients.Find(el => el.name == name );
    }

    public Account? FindAccountById(int id){
        return accounts.Find(el => el.id == id );
    }

    public List<Client>? FindAllClientsByName(string name)
    {
        return clients.FindAll(el => el.name == name);
    }

    public List<Account>? FindAllAccountsById(int id)
    {
        return accounts.FindAll(el => el.id == id);
    }
}