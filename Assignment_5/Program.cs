using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Jamesbond = "James Bond is a fictional character created by novelist Ian Fleming in 1953. A British secret agent working for MI6 under the codename 007, he has been portrayed on film by actors Sean Connery, David Niven, George Lazenby, Roger Moore, Timothy Dalton, Pierce Brosnan and Daniel Craig in twenty-seven productions. All but two films were made by Eon Productions, which now holds the adaptation rights to all of Fleming's Bond novels.[1][2]In 1961, producers Albert R.Broccoli and Harry Saltzman purchased the filming rights to Flemings novels.[3] They founded Eon Productions and, with financial backing by United Artists, produced Dr. No, directed by Terence Young and featuring Connery as Bond.[4] Following its release in 1962, Broccoli and Saltzman created the holding company Danjaq to ensure future productions in the James Bond film series.[5] The series currently has twenty-five films, with the most recent, No Time to Die, released in September 2021. With a combined gross of nearly $7 billion to date, it is the fifth-highest-grossing film series.[6] Accounting for inflation, it has earned over $14 billion at current prices.[a] The films have won five Academy Awards: for Sound Effects (now Sound Editing) in Goldfinger (at the 37th Awards), to John Stears for Visual Effects in Thunderball (at the 38th Awards), to Per Hallberg and Karen Baker Landers for Sound Editing, to Adele and Paul Epworth for Original Song in Skyfall (at the 85th Awards) and to Sam Smith and Jimmy Napes for Original Song in Spectre (at the 88th Awards). Several of the songs produced for the films have been nominated for Academy Awards for Original Song, including Paul McCartney's \"Live and Let Die\", Carly Simon's \"Nobody Does It Better\" and Sheena Easton's \"For Your Eyes Only\".In 1982 Albert R. Broccoli received the Irving G.Thalberg Memorial Award.[8]";
            int a = 0;
            while(a==0)
            {
                Console.WriteLine("\n Please enter your choice\n 1. Press 1 for Blank Spaces\n 2. Press 2 for No of words\n 3. Press 3 for no of dots\n 4.Press 4 for No of statements\n 5.Press 5 for no of Digits 6.Press 6 for No of vovel\n 7.Press 7 for special strings and index\n 8.Press 8 for number and positions of comma\n 9. Press 9 to reverse each word\n 10.Press 10 to reverse entire string\n 11.Press 11 to print each statement in seperateLine\n 12.press 12 to print all  Decorated words within\n 13.Press 13 for  first letter in uppercase\n 14. Press 14 to print month.   ");
                int Press=Convert.ToInt32(Console.ReadLine());
                switch(Press)
                {
                    case 1:
                        NoOfBlankSpace(Jamesbond);
                        break;
                        
                    case 2:

                        NoOfBlankSpace(Jamesbond);
                        break;

                    case 3:
                        Dot(Jamesbond);
                        break;
                    case 4:
                        Dot(Jamesbond);
                        break;
                    case 5:
                        NoOfDigits(Jamesbond);
                        break;
                    case 6:
                        Vovel(Jamesbond);
                        break;
                    case 7:
                        Word(Jamesbond, "and");
                        Word(Jamesbond, "the");
                        Word(Jamesbond, "is");
                        Word(Jamesbond, "to");
                        break;
                    case 8:
                        Comma(Jamesbond);
                        break;
                    case 9:
                        RevEachWord(Jamesbond);
                        break;
                    case 10:
                        Reverse(Jamesbond);
                        break;
                    case 11:
                        Seperate(Jamesbond);
                        break;
                    case 12:
                        Decorators(Jamesbond);
                        break;
                    case 13:
                        Upper(Jamesbond);
                        break;
                    case 14:
                        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                        foreach (string item in months)
                        {
                            if (Jamesbond.Contains(item))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 15:
                        a++;
                        break;
                }

            }

        }
        public static void NoOfBlankSpace(string JamesBond)
        {
            int count = 0;
            foreach(char c in JamesBond)
            {
                if(c == ' ')
                {
                    count++;
                }
            }
            Console.WriteLine(count++);
        }
        public static void Dot(string Jamesbond)
        {
            int count = 0;
            foreach(char c in Jamesbond)
            {
                if(c=='.')
                {
                    count++;

                }

            }
            Console.WriteLine(count);
        }
        public static void NoOfDigits(string JamesBond)
        {
            int count=0;
            foreach(char c in JamesBond)
            {
                if(char.IsDigit(c))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        public static void Vovel(string JamesBond)
        {
            char[] vov = { 'A', 'a', 'E', 'e', 'I', 'i', 'O','o', 'U', 'u' };
            int count = 0;
            foreach(char c in JamesBond)
            {
                foreach(char c2 in vov)
                {
                    if(c==c2)
                    {
                        count++;
                    }
                }

            }
            Console.WriteLine(count);
         }
        public static void Word(string JamesBond,  string wrd)
        {
            string[] split = JamesBond.Split(" ");  // removed all the spaces and saved in split
            
            int count = 0;
            int i=0;
            
            while(i<split.Length)
            {
                if(wrd.Equals(split[i]))
                            // Equals(String, String) is a String method.
                   {
                    Console.WriteLine($"index of words \"{ wrd}\"={i}");
                    count++;
                    }         // It is used to determine whether two String
                i++;         // objects have the same value or not.
            }
            Console.WriteLine($"Count of \"{wrd}\"= {count}");

        }
        public static void Comma(string Jamesbond)
        {
           
            int i = 0;
            int count = 0;
            char comma = ',';
            while(i<Jamesbond.Length)
            {
                if(comma.Equals(Jamesbond[i]))   // it is basically checking comma=","
                {

                    count++;
                    Console.WriteLine($"index of comma = {i}");

                }
                i++;
            }
            Console.WriteLine($"No of comma={count}");
        }
        public static void Reverse(string Jamesbond )
        {
           string rev= "";    // make an empty string
            for(int i=Jamesbond.Length-1;i>=0;i--)
            {
                rev += Jamesbond[i];
               
            }
            Console.WriteLine(rev);

        }
        public static void RevEachWord(string Jamesbond)
        {
             string res = string.Join(" ", Jamesbond.Split(' ')  // used link to reverse the each word in string /// After reverse of all the word we will join them using substring 
             .Select(x => new String(x.Reverse().ToArray()))); // we are convering this iENumerable to ca char array // then string constructor is storing them
            Console.WriteLine(res);


        }
         
        public static void Seperate(string Jamesbond)
        {
            foreach (string a in Jamesbond.Split('.'))  // remove the dots and seperate the lines
            {
                Console.WriteLine(a);
            }
        }
        public static void Decorators(string Jamesbond)
        {
            var dec = new Regex("\".*?  \"");  //. will check the data btween the ""
            var mat = dec.Matches(Jamesbond);
            foreach (var item in mat)                                   //* will specify an expression to its left 0 or more time
            {
                Console.WriteLine(item.ToString());  
            }
        }                                       //? will specify an expression to its left 0 or onetime
        public static void Upper(string Jamesbond)

        {
            string[] words = Jamesbond.Split(' ');
            string t = " ";
            foreach(string word in words)
            {
                t+= char.ToUpper(word[0] )+ word.Substring(1) + " ";  // we are making first char upper and adding remaining char in t with space
                
            }
            Console.WriteLine(t);

        }
        


    }
}
