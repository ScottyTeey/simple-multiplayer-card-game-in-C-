using System;
/*author: Lebogang J Papo
We've created a simple multiplayer card game called "Add 'Em Up" where 5 players are dealt 5 cards from a standard 52 card pack, and the winner is the one with the highest score. The score for each player is calculated by adding up the card values for each player, where the number cards have their face value, J = 11, Q = 12, K = 13 and A = 1 (not 11). In the event of a tie, list all winners.
You are required to write a program that will read the data from the scanner, find the winner(s) and write them to the console.

 */

namespace winner
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] players = new string[5];
            players[0] = "Lebogang:AH,3C,8C,2S,JD";
            players[1] = "Kevin:KD,QH,TC,4C,AC";
            players[2] = "Kurumba:6S,8D,3D,JH,2D";
            players[3] = "Michael:5H,3S,KH,AS,9D";
            players[4] = "Sbu:JS,3H,2H,2C,4D";

            int biggest = 0;
            String winner = "";
            //iterate every player in the string array
            for (int i = 0; i < players.Length; i++)
            {
                string player = players[i];
                String[] nameCards = player.Split(":");
                String name = nameCards[0];
                String cards = nameCards[1];
                //initializing calcPoints to holds the points of the cards
                int points = calculatePoints(cards);
                Console.WriteLine(name + " " + cards + " = " + points);

                if(points > biggest)
                {
                    biggest = points;
                    winner = name;
                } else if(points == biggest)
                {
                    winner = winner + "," + name;
                }
            }
            //the output stating the winner
            Console.WriteLine(winner + " :" + biggest);
            Console.WriteLine("Press Enter Key To Exit The Assessment Program");
            Console.ReadLine();
        }
        //creating a method to give me the string cards and calc the points
        public static int calculatePoints(string cards)
        {
            String[] cardArray = cards.Split(",");
            int points = 0;
            for (int i = 0; i < cardArray.Length; i++)   //for every card get 1 card, get point until it loops through the array
            {
                string card = cardArray[i];
                //We pass beginIndex and endIndex number position in the C# substring method where beginIndex is inclusive, 
                //and endIndex is exclusive. In other words, the beginIndex starts from 0, whereas the endIndex starts from 1.
                String value = card.Substring(0, 1);
                if (value.Equals("A"))
                {
                    points += 1;
                }
                else if (value.Equals("T"))
                {
                    points += 10;
                }
                else if (value.Equals("J"))
                {
                    points += 11;
                }
                else if (value.Equals("Q"))
                {
                    points += 12;
                }
                else if (value.Equals("K"))
                {
                    points += 13;
                }
                else
                {
                    points += int.Parse(value);
                }

            }
            return points;
        }
        
    }
}


/* expected output
 * The output should contain a single line, with one of the following 2 possibilities:
- The name of the winner and their score (colon separated).
- A comma separated list of winners in the case of a tie and the score (colon separated).

E.g.
NameX:40
// or
NameX,NameY:35
 */