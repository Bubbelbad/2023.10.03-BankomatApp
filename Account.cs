using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatApplikation
{
    class Account
    {
        //Variabler för klassen Account
        public string name;
        public string address;
        public int holdings;
        public int pinCode;


        //Klassen Account
        public Account()
        {
            this.Name = name;
            this.Address = address;
            this.Holdings = holdings;
            this.PinCode = pinCode;
        }

        //Constructor-man kan sätta in argument i skapandet av klassen.
        public Account(string name, string address, int pinCode, int holdings = 0)
        {
            this.Name = name;
            this.Address = address;
            this.Holdings = holdings;
            this.PinCode = pinCode;
        }

        //Properties: 
        public string Name
        { get; set; }
        

        public string Address
        {
            get { return address; }    
            set { address = value; }
        }

        public int Holdings
        {
            get { return holdings; }
            set
            {
                if (value < 0) { holdings = 0; }
                else { holdings = value; }
            }
        }

        public int PinCode
        {
            get { return pinCode; }
            set { pinCode = value; }
        }



        //Variabler för funktioner: 
        int[] change = { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };


        //Funktioner: 
        public static void StartProgram()
        {
            Console.WriteLine("*** Välkommen till bankomaten! *** \n \n" +

                              "Sätt in ditt kort    [1] \n" +
                              "Avsluta              [2]\n");

            bool start = false;
            int card_input = 0;
            while (!start)
            {
                try
                {
                    card_input = Convert.ToInt16(Console.ReadLine());
                    if (card_input == 1)
                    {
                        start = true;
                    }
                    else if (card_input == 2)
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Vänligen välj alternativ [1] eller [2]:");
                    }
                }
                catch
                {
                    Console.Write("Vänligen välj alternativ [1] eller [2] med siffror: ");
                }
            }
        }
        public bool WithdrawCash()
        {
            int withdraw_sum = 0;
            int sum = 0;
            List<int> list = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, }; 
            Console.Write("Hur mÿcket pengar vill du ta ut? ");

            try
            {
                withdraw_sum = Convert.ToInt32(Console.ReadLine());
                sum = withdraw_sum;
                Console.WriteLine("\n");
            }
            catch
            {
                Console.WriteLine("Skriv in ett belopp med siffror\n");
            } 
            
            if (withdraw_sum <= holdings)
            {
                Console.Clear();
                for (int i = 0; i < change.Length; i++)
                {
                    while (change[i] <= sum)
                    {
                        sum -= change[i];
                        list[i]++;
                    }
                }

                for (int i = 0; i < change.Length; i++)
                {
                    if (list[i] > 0)
                    {
                        Console.WriteLine($"Du får ut {list[i]} stycken av {change[i]}.");
                    }
                    else if (list[i] == 0)
                    {
                        continue;
                    }
                }
                Console.WriteLine($"\nDitt nya saldo är nu {holdings - withdraw_sum} SEK.\n");
                holdings -= withdraw_sum;
                return true;

            }
            else if (withdraw_sum > holdings)   
            {
                Console.WriteLine($"*** Du har för lite pengar på kontot! ***\n");
                return false;
            }

            else
            {
                return false;
            }
        }



        List<Int16> list = new List<Int16>(9);
        public void DepositCash()
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < change.Length; i++)
            {
                Console.WriteLine($"Hur många av {change[i]} vill du sätta in? ");

                try
                {
                    count = Convert.ToInt16(Console.ReadLine());
                    sum += count * change[i];
                    continue;
                }
                catch
                {
                    Console.WriteLine("Vänligen skriv in en siffra: ");
                }
            }
            holdings += sum;
            Console.Clear();
            Console.WriteLine($"Ditt nya saldo är {holdings} SEK.\n");
        }


        public void ChangePinCode()
        {
            int new_pincode = 0;
            bool changePin = false;
            while (!changePin)
            {
            Console.Write("Knappa in din nya pinkod: ");
                try
                {
                    new_pincode = Convert.ToInt16(Console.ReadLine());
                    pinCode = new_pincode;
                    Console.Clear();
                    Console.WriteLine("*** Din pinkod har nu ändrats ***\n\n");
                    break;
                }
                catch
                {
                    Console.WriteLine("Felmeddelande! Vänligen knappa in en fyrsiffrig pinkod: ");
                    break;
                }
            }
        }
    }
}
