using System.Collections.Generic;

class Client {
    public string name { get; private set; }
    string surname;
    string patronymic;
    int age;
    string workplace;
    public List<int> accountsNumbers {get; private set; }

    public Client(string name, string surname, string patronymic, int age, string workplace, Bank bank){
        this.name = name;
        this.surname = surname;
        this.patronymic = patronymic;
        this.age = age;
        this.workplace = workplace;
        this.accountsNumbers = new List<int>();
        bank.AddClient(this);
    }

    public void AddAccount(int accountNumber){
        accountsNumbers.Add(accountNumber);
    }

    public string getInfo()
    {
        return $"Имя: {name}, Фамилия: {surname}, Отчество: {surname}, Возраст: {age}, Место работы: {workplace}.";
    }
}