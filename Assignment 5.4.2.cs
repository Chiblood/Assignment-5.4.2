/* Assignment 5.4.2
Write a C# Sharp program to find the sum of the right diagonals of a matrix.
Test Data :
Input the size of the square matrix : 2
Input elements in the first matrix :
element - [0],[0] : 1
element - [0],[1] : 2
element - [1],[0] : 3
element - [1],[1] : 4
Expected Output :
The matrix is :
1 2
3 4
Addition of the right Diagonal elements is :5
*/
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Input the size of the square matrix: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[size, size];

        Console.WriteLine("Input elements in the matrix:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"element - [{i}],[{j}] : ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("The matrix is:");
        PrintMatrix(matrix);

        double rightDiagonalSum = AddRightDiagonal(matrix);
        Console.WriteLine($"Addition of the right Diagonal elements is: {rightDiagonalSum}");

        double leftDiagonalSum = AddLeftDiagonal(matrix);
        Console.WriteLine($"Addition of the left Diagonal elements is: {leftDiagonalSum}");

    }
    
    private static int[] TakeUserArray() // Prompts the user to enter a series of integers separated by spaces, parses them, and returns the resulting array.
    {
        Console.Write("Enter integers separated by space: ");
        string? input = Console.ReadLine();
        if (input != null)
        {
            string[] parts = input.Split(' ');
            int[] nums = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i].Trim(), out int num))
                {
                    nums[i] = num;
                }
                else
                {
                    Console.WriteLine($"Invalid integer: {parts[i]}");
                    return new int[0]; // Return an empty array for invalid input
                }
            }
            Console.WriteLine($"You entered: [{string.Join(", ", nums)}]");
            return nums; // Return the parsed array
        }
        else
        {
            Console.WriteLine("No input provided.");
            return new int[0]; // Return an empty array if no input is provided
        }
    }
    private static double AddRightDiagonal(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        double sum = 0;
        for (int i = 0; i < size; i++)
        {
            sum += matrix[i, size - 1 - i];
        }
        return sum;
    }
    private static double AddLeftDiagonal(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        double sum = 0;
        for (int i = 0; i < size; i++)
        {
            sum += matrix[i, i];
        }
        return sum;
    }
    private static void PrintMatrix(int[,] matrix) // print matrix with automatic width formatting
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Determine the maximum width of any element in the matrix for padding
        int maxWidth = 0;
        foreach (int value in matrix)
        {
            maxWidth = Math.Max(maxWidth, value.ToString().Length);
        }

        for (int i = 0; i < rows; i++)
        {
            Console.Write("|"); // start of row
            for (int j = 0; j < cols; j++)
            {
                Console.Write($" {matrix[i, j].ToString().PadLeft(maxWidth)} |");
            }
            Console.WriteLine();
        }
    }
}