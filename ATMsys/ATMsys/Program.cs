using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1 Deposit");
            Console.WriteLine("2 Withdraw");
            Console.WriteLine("3 Show balance");
            Console.WriteLine("4 Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money you would like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("thank you for your money. Your new balance is: " + currentUser.getBalance());

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money you would like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Sorry isufficient balance :(");

            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance:" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "José", "Caveira", 745.84));
        cardHolders.Add(new cardHolder("4532784253654878", 4512, "Ronaldo", "Fenomeno", 745.84));
        cardHolders.Add(new cardHolder("4532785612301222", 8521, "Cristian", "Almeida", 745.84));
        cardHolders.Add(new cardHolder("4532702134562324", 1852, "Amilio", "Joaquim", 745.84));
        cardHolders.Add(new cardHolder("4532788852300211", 1147, "Kayser", "Sozhen", 745.84));
        cardHolders.Add(new cardHolder("4532765432145678", 1963, "Roberto", "Pettersom", 745.84));
        cardHolders.Add(new cardHolder("4532789456231236", 1123, "Robson", "Algusto", 745.84));
        cardHolders.Add(new cardHolder("4532772878912544", 7896, "Rafaela", "Lerinballe", 745.84));
        cardHolders.Add(new cardHolder("4538425312456456", 7412, "Camilla", "Cabello", 745.84));
        cardHolders.Add(new cardHolder("7895431245645679", 8746, "Camilla", "Pitanga", 745.84));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }

            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }

        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect Pin. Please try again."); }

        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
               option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }

}