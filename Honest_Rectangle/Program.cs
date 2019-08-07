using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honest_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Looper();
        }

        public List<int> RemovePrime(List<int> PossibleAreaValues, List<int> PossiblePerimeterValues, List<int[]>
            Length_Width)
        {
            /*This section removes Prime numbers (which would only yield 2 possible length/width values,
            thus giving away the answer). It also removes the corresponding Perimeter value. I considered using
            a dictionary to ensure that each Area value and each Perimeter value corresponded to the respective
            length and width values. Instead of using a dictionary, I made sure to remove the respective values
            from the two lists simultaneously.          */
            for (int i = 0; i < PossibleAreaValues.Count; i++)
            {
                int Counter = 0;
                for (int Divisor = 1; Divisor <= PossibleAreaValues[i]; Divisor++)
                {
                    if (PossibleAreaValues[i] % Divisor == 0)
                    {
                        Counter++;
                    }
                }
                if (Counter <= 2)
                {
                    PossibleAreaValues.Remove(PossibleAreaValues[i]);
                    PossiblePerimeterValues.Remove(PossiblePerimeterValues[i]);
                    Length_Width.Remove(Length_Width[i]);
                    /*I will take the value of i down one to compensate for the alteration of the two lists.*/
                    i--;
                }
            }
            return PossibleAreaValues;
        }

public List<int> CalculatePossibleAreas(int Upper, int Lower, List<int> PossibleAreaValues,
    List<int> PossiblePerimeterValues, List<int[]> Length_Width)
        {
            //the loop below pulls out each value individually and multiplies it with every other
            //value in the List to discover all possible areas of the rectangle.
            //since the first 'for' loop increments the variable Lower, the concern of redundancies
            //is resolved.
            for (int i = Lower; i <= Upper; i++)
            {
                for (int j = i; j <= Upper; j++)
                {
                    PossibleAreaValues.Add(i * j);
                    PossiblePerimeterValues.Add((2 * i) + (2 * j));
                    int[] next = new int[2] {i,j} ;
                    Length_Width.Add(next);
                }
            }
            RemovePrime(PossibleAreaValues, PossiblePerimeterValues, Length_Width);
          
            
            return PossibleAreaValues;
        }

        public static void ConsoleWrite(List<int> PossibleAreaValues, List<int> PossiblePerimeterValues,
            List <int[]> Length_Width)
        {
            Console.WriteLine("\nPossibleAreaValues.Count = " + PossibleAreaValues.Count.ToString() 
                + " PossiblePerimeterValues.Count = " + PossiblePerimeterValues.Count.ToString() + "\n");
            
                for (int i = 0; i<PossiblePerimeterValues.Count; i++)
                {
                Console.WriteLine("Possible Area: " + PossibleAreaValues[i].ToString() +
                    " Possible Perimeter: " + PossiblePerimeterValues[i].ToString());
                Console.WriteLine("Length = " + Length_Width[i][0].ToString()
                    + " Width= " + Length_Width[i][1].ToString()+ "\n");
               

            }
}

        public static void Looper()
        {
            Console.WriteLine("     In this program, you will discover an Honest Rectangle. " +
                "(project taken from codekerfuffle.com)");
            Console.WriteLine("This program will calculate possible height and width for a rectangle" +
                "based on the total perimeter length and the area");
            Console.WriteLine("The conditions are:\n");
            Console.WriteLine("1. Knowing the area alone is insufficient to determine the height and width");
            Console.WriteLine("2. The perimeter length PLUS the knowledge that " +
                "the area alone is insufficient combined are " +
                "sufficient to determine the height and width\n");
            Console.WriteLine("Please enter an integer to indicate the minimum height/width of the rectangle:\n");
            int.TryParse(Console.ReadLine(), out int basics);
            int Lower = basics;
            Console.WriteLine("Please enter an integer to indicate the maximum height/width of the rectangle:\n");
            int.TryParse(Console.ReadLine(), out int result);
            int Upper = result;
            Honest_Rectangle.Program junior = new Honest_Rectangle.Program();
           List<int> PossibleLengthWidth = new List<int>();
            List<int> PossiblePerimeterValues = new List<int>();
            List<int[]> Length_Width = new List<int[]>();
            List<int> PossibleAreaValues = junior.CalculatePossibleAreas(Upper, Lower, PossibleLengthWidth,
                PossiblePerimeterValues, Length_Width);
            ConsoleWrite(PossibleAreaValues, PossiblePerimeterValues, Length_Width);


                     /* The Console is completely unable to read the Console.ReadLine, why?
              I decided not to figure that out as I doubt many employers use Console apps anymore */
            if (Console.ReadLine().ToLower() != "exit" || Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Looper();
            }
        }
    }
}
