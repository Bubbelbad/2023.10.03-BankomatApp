using System;
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

        int thousand = 0;
        int fivehundred = 0;
        int twohundred = 0;
        int hundred = 0;
        int fifty = 0;
        int twenny = 0;
        int ten = 0;
        int five = 0;
        int one = 0;

        int sum = 0;


        //Funktioner: 

        public bool WithdrawCash(int withdraw)
        {
            if (withdraw <= holdings)
            {

                holdings -= withdraw;
                while (withdraw >= 1000)
                {
                    withdraw -= 1000; thousand++;
                }
                while (withdraw >= 500)
                {
                    withdraw -= 500; fivehundred++;
                }
                while (withdraw >= 200)
                {
                    withdraw -= 200; twohundred++;
                }
                while (withdraw >= 100)
                {
                    withdraw -= 100; hundred++;
                }
                while (withdraw >= 50)
                {
                    withdraw -= 50; fifty++;
                }
                while (withdraw >= 20)
                {
                    withdraw -= 20; twenny++;
                }
                while (withdraw >= 10)
                {
                    withdraw -= 10; ten++;
                }
                while (withdraw >= 5)
                {
                    withdraw -= 5; five++;
                }
                while (withdraw >= 1)
                {
                    withdraw -= 1; one++;
                }

                Console.WriteLine($"Du får ut följande: \n" +
                    $"1000-lappar: {thousand} \n" +
                    $"500-lappar: {fivehundred}\n" +
                    $"200-lappar: {twohundred}\n" +
                    $"100-lappar: {hundred}\n" +
                    $"50-lappar: {fifty}\n" +
                    $"20-lappar: {twenny}\n" +
                    $"10-kronor: {ten}\n" +
                    $"5-kronor: {five}\n" +
                    $"1-kronor: {one}\n\n" +
                    $"Ditt nuvarande saldo är {holdings} SEK");
                return true;

            }
            else if (withdraw > holdings)   
            {
                Console.WriteLine($"*** Du har för lite pengar på kontot! ***\n");
                return false;
            }
            else
            {
                return false;
            }
        }


        //För att neräkna hur många sedlar och mynt användaren vill sätta in: 

        int[] change = { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };
        int count; 
        List<Int16> list = new List<Int16>(9);
        public void DepositCash()
        {
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
            Console.WriteLine($"Ditt nya saldo är {holdings}");
        }
    }
}
