using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        public static void PrintTriangle(int x)
        {
            try
            {
                int n, i, j;
                //We will first declare the integers I and J since we are going to use them later in our for loop
                Console.WriteLine("How many rows do you need in your pyramid?:");
                n = Convert.ToInt32(Console.ReadLine());
                //Now getting the input from the user 
                for (i = 1; i <= n; i++)
                //The way that I have decided to build this pyramid is through matrix notation. I here will represent the row
                //whereas J will represent the column. So this loop is designed in a way that it will first deal with the
                //rows and then with the columns.
                {
                    for (j = 1; j <= 2 * n - 1; j++)
                    //2n-1 is used here because that is the odd number progression. In the 2nd row we need 3 stars for example.
                    //once J increases more than 2n-1, the loop returns to the previous line.  
                    {
                        if (j >= n - (i - 1) && j <= n + (i - 1))
                        //This line is important for the pyramid to be center aligned.
                        {
                            Console.Write("*");
                        }
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine("\n");//When the program is done printing the stars in a row, it is instructed 
                                            //to start printing from the new line.
                }
                return;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            try
            {
                int i, n2, s = 0;

                Console.WriteLine("Please enter the number of terms here:");

                n2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("The odd numbers are ");

                for (i = 1; i <= n2; i++)//The code will only iterate to the number of terms chosen by the user
                {
                    Console.Write(2 * i - 1);//Over here, I have used 2x-1 technique to generate the sequence of 
                                             //odd numbers.
                    s = s + (2 * i - 1);//This line of code simply adds all the terms in every iteration.
                    if (i < n2)//This block of code is only written to avoid printing a comma in the end.
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine(".");
                    }

                }
                Console.Write("The sum is ");
                Console.WriteLine(s + ".");

            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                int i;
                Boolean increasing = true;//We have to check 2 conditions. One where the series is increasing and one where it is decereasing.
                Boolean decreasing = true;

                for (i = 0; i < n.Length - 1; i++)
                {
                    if (n[i] > n[i + 1])
                    {
                        increasing = false;//Increasing would be false when the previous number is larger than the next number
                    }
                    if (n[i] < n[i + 1])//Thos would be false in the opposite scenario.
                    {
                        decreasing = false;
                    }
                }
                return increasing || decreasing;//This piece of code ensures that the program returns true when either of the conditions return true. 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return false;
        }

        public static int DiffPairs(int[] arr, int k)
        {
            try
            {
                {
                    // Removing duplicates from array
                    arr = arr.Distinct().ToArray();
                    int count = 0;


                    // Pick all elements one by one 
                    for (int i = 0; i < arr.Length; i++)
                    {

                        // See if there is a pair 
                        // of this picked element 
                        for (int j = i + 1; j < arr.Length; j++)
                            if (arr[i] - arr[j] == k ||
                                  arr[j] - arr[i] == k)//This ensures that the difference is check in both directions.
                                count++;
                    }

                    return count;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {

            try
            {
                int[] map = new int[26];//making a new integer array to popultate integers to the length of the keyboard to map the integers to the keyboard characters
                for (int i = 0; i < keyboard.Length; i++)
                {
                    map[keyboard[i] - 'a'] = i;
                }
                int time = 0;
                for (int i = -1, j = 0; j < word.Length; i++, j++)
                {
                    if (i == -1)
                    {
                        time += Math.Abs(map[word[0] - 'a'] - 0);//This ensures that the value starts from the first letter
                    }
                    else
                    {
                        time += Math.Abs(map[word[j] - 'a'] - map[word[i] - 'a']);//This piece of code checks the absolute value between the character in the word with the next character in word. This is why i starts from -1 and j starts from 0 so that i trails by 1.
                                                                                  //By adding map, the code returns with an integer value which is infact the difference between the characters on the initial keyboard.
                    }
                }
                return time;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                //This is a standard minimum value calculator. We will be using this to find the minimum
                //number of edits required.
                static int min(int x, int y, int z)
                {
                    if (x <= y && x <= z)
                        return x;
                    if (y <= x && y <= z)
                        return y;
                    else
                        return z;
                }
                //Over here I am defining the length of the strings. This will make it easier to 
                //iterate over the strings.

                int m = 0;
                int n = 0;
                m = str1.Length;
                n = str2.Length;

                //Create a table to store the results 

                int[,] edits = new int[m + 1, n + 1];

                // We are going to figure out where the strings differ through this code
                for (int i = 0; i <= m; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        // If first string is empty, only option is to 
                        // insert all characters of second string 
                        if (i == 0)

                            // Min. operations = j 
                            edits[i, j] = j;

                        // If second string is empty, only option is to 
                        // remove all characters of second string 
                        else if (j == 0)

                            // Min. operations = i 
                            edits[i, j] = i;

                        // If last characters are same, ignore last char 
                        // and recur for remaining string 
                        else if (str1[i - 1] == str2[j - 1])
                            edits[i, j] = edits[i - 1, j - 1];

                        // If the last character is different, consider all 
                        // possibilities and find the minimum 
                        else
                            edits[i, j] = 1 + min(edits[i, j - 1], // Insert 
                                               edits[i - 1, j], // Remove 
                                               edits[i - 1, j - 1]); // Replace 
                    }
                }

                return edits[m, n];
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}
