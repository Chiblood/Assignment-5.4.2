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

        Console.WriteLine("Input elements in the first matrix:");
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

        int rightDiagonalSum = 0;
        for (int i = 0; i < size; i++)
        {
            rightDiagonalSum += matrix[i, size - 1 - i];
        }

        Console.WriteLine($"Addition of the right Diagonal elements is: {rightDiagonalSum}");
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