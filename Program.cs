using System;
using System.Collections;

namespace BlackJackSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cards cardsUser = new Cards(0, new ArrayList());
            Cards cardsDealer = new Cards(0, new ArrayList());
            printRules();
            shortcut("User", cardsUser);
            shortcut("Dealer", cardsDealer);
            hitQuestion(cardsUser, cardsDealer);
        }

        public static void hitQuestion(Cards cardsUser, Cards cardsDealer)
        {
            int flag = 0;
            string user;
            do
            {
                Console.WriteLine("Hit or stand?" + Environment.NewLine + "Type HIT to hit and STAND for stand!");
                user = Console.ReadLine();
                exitCheck(user);
                if (user == "HIT")
                {
                    Console.WriteLine("User hits!");
                    shortcut("User", cardsUser);
                    if (cardsUser.Sum > 21) {
                        Console.WriteLine("User bust! Dealer Wins!"); return;
                    }
                    else if (cardsDealer.Sum == 21){
                        Console.WriteLine("User has 21! User Wins!"); return;
                    }
                }
                else if (user == "STAND") flag = 1;
                else Console.WriteLine("Wrong input!");
            } while (flag == 0);
            while (cardsDealer.Sum <= 16)
            {
                Console.WriteLine("Dealer hits!");
                shortcut("Dealer", cardsDealer);
            }
            if (cardsDealer.Sum > 21) Console.WriteLine("Dealer bust! User Wins!");
            else
            {
                if (cardsUser.Sum > cardsDealer.Sum) Console.WriteLine("User's hand is closer to 21! User Wins!");
                else if(cardsDealer.Sum == 21) Console.WriteLine("Dealer has 21! Dealer Wins!");
                else Console.WriteLine("Dealer's hand is closer to 21! Dealer Wins!");
            }

        }

        public static void printRules()
        {
            int flag = 0;
            string userStart;
            Console.WriteLine("Welcome to my Blackjack Program!");
            Console.WriteLine("GOAL: Get cards which sum is closer to 21." + Environment.NewLine + "Hope that the dealer doesn't get close to 21!");
            Console.WriteLine("Type START to start!" + Environment.NewLine + "Type EXIT anytime to exit!");
            do
            {
                userStart = Console.ReadLine();
                exitCheck(userStart);
                if (userStart == "START") flag = 1;
                else Console.WriteLine("Wrong input!");
            } while (flag == 0);
        }

        public static void getHand(Cards cards)
        {
            Random rand = new Random();
            int num = rand.Next(1, 14);
            cards.Sum += num;
            string result = faceCards(num);
            cards.CardsHand.Add(result);
            Console.WriteLine(" hits " + result);
        }
        
        public static void printHand(string name, Cards cards)
        {
            Console.WriteLine(name + " has a total of: " + cards.Sum);
            Console.Write(name + " has ");
            foreach(string card in cards.CardsHand)
            {
                Console.Write(card + " ");
            }
            Console.WriteLine("");
        }

        public static void shortcut(String name, Cards cards)
        {
            Console.Write(name + " ");
            getHand(cards);
            printHand(name, cards);
        }

        public static string faceCards(int num)
        {
            switch (num)
            {
                case 1:
                    return "A";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return num.ToString();
            }
        }

        public static void exitCheck(string userInput)
        {
            if (userInput == "EXIT")
            {
                System.Environment.Exit(0);
            }
        }
    }

    public class Cards
    {
        public int Sum;
        public ArrayList CardsHand;
        public Cards(int sum, ArrayList cards)
        {
            Sum = sum;
            CardsHand = cards;
        }
    }
}


