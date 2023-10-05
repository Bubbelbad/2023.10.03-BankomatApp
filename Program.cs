using System;
using System.Security.Cryptography.X509Certificates;

namespace BankomatApplikation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lista där alla konton kommer att läggas in: 
            List<Account> accounts = new List<Account>();


            //Lägger till konton/objekt från klassen Accounts till programmet
            Account a = new Account();
            a.Name = "Victor";
            a.Address = "Stjärnvägen 30";
            a.Holdings = 10000;
            a.PinCode = 1234;
            accounts.Add(a);


            Account b = new Account();
            b.Name = "Hassan";
            b.Address = "Hasselvägen 44";
            b.Holdings = 25000;
            b.PinCode = 5678;
            accounts.Add(b);


            Account c = new Account();
            c.Name = "Mr. Myagi";
            c.Address = "Skåpgatan 1";
            c.Holdings = 200;
            c.PinCode = 1122;
            accounts.Add(c);


            Account d = new Account();
            d.Name = "Lenin";
            d.Address = "Banalvägen 3";
            d.Holdings = 350000;
            d.PinCode = 3344;
            accounts.Add(d);


            //Constructor, där en kan mata in tre argument och holdings blir 0 av default:
            Account e = new Account("Edward", "Myntgatan 344", 4338);
            accounts.Add(e);

            //Skapar och lägger till nya konton rakt in i listan. Tex: 
            accounts.Add(new Account("Kalle", "Marklandsgatan 58", 3500, 6868));






            //Startar programmet. En static void funktion! YES..
            Account.StartProgram();


            //För att välja vilket konto man loggar in i. Jag sparar index i variabel x för framtida användning. 
            //---(((Denna funktion behöver en failsafe ifall man skrivfer in fel namn)))---

            string account_name = "";
            int x = -2;
            bool account_choice = false;

            Console.Clear();
            Console.Write("*** Vilket konto vill du använda? *** \n\n");
            while (!account_choice)
            {
                Console.Write("Skriv in ditt namn: ");
                account_name = Console.ReadLine();
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (account_name == accounts[i].Name)
                    {
                        x = i;
                        account_choice = true;

                    }
                }
            }




            //Här itererar vi igenom listan med accounts för att verifiera pinkoden med rätt konto. 
            bool login_status = false;
            int code_input = 0;
            int count = 0;
            while (!login_status)
            {
                Console.Write("\nKnappa in din kod: ");
          
                try
                {
                    code_input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("Något gick fel. Prova igen att mata in en fyrsiffrig kod: ");
                }
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (code_input == accounts[x].PinCode)
                    {
                        login_status = true;
                        break;
                    }
                    else if (code_input != accounts[x].PinCode)
                    {
                        while (code_input != accounts[i].PinCode)
                        {
                            Console.WriteLine("*** Du har angett fel pinkod! *** \n");
                            Console.WriteLine("Försök igen: \n");
                            try
                            {
                                code_input = Convert.ToInt16(Console.ReadLine());
                                count++;
                                if (code_input != accounts[i].PinCode && count > 1)
                                {
                                    Console.WriteLine("*** Kortet är spärrat. *** \nKontakta närmsta lokalkontor för tisdbokning och klagomål.\n");
                                    System.Environment.Exit(0);
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Försök igen med siffror...");
                            }
                        }
          
                    }
          
                }
          
            }
            Console.Clear();
            Console.WriteLine("**** Pinkod Accepterad ***\n");
            Console.WriteLine($"{accounts[x].Name}s konto. Saldo: {accounts[x].holdings} SEK.\n");
           


            //Här väljer vi vilken funktion vi ska kalla på: 
            bool this_loop = true;
            int new_pincode = 0;
            int with_or_depos;
            while (this_loop)
            {
                Console.WriteLine("Vad vill du göra?\n \n" +
                                  "Ta ut pengar         [1]\n" +
                                  "Sätta in pengar      [2]\n" +
                                  "Ändra pinkod         [3]\n" +
                                  "Avsluta              [4]");

           
                int code_input2 = 0;
                try
                {
                    code_input2 = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\n");
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("\n*** Felmeddelande! ***\nVänligen skriv in en siffra mellan 1- 4:\n");
                }
           
                switch (code_input2)
                {
                    case 1: 
                        accounts[x].WithdrawCash();
                        break;

                    case 2:
                        accounts[x].DepositCash();
                        break;

                    case 3:
                        accounts[x].ChangePinCode();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
           
                }        
           
            }

        }

    }
}