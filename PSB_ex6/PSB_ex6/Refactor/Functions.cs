using System.Security.Cryptography;

namespace PSB_ex6.Refactor;

public class Functions
{
    public static void CopyMatrix(int width, int height, int[][] toMatrix, int[][] fromMatrix)
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                toMatrix[i][j] = fromMatrix[i][j];
            }
        }
    }

    public static void FillMatrix(int width, int height, int[][] matrix)
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                matrix[i][j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public static void FillRandomMatrix(int width, int height, int[][] matrix)
    {
        var randomGenerator = new Random();
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                matrix[i][j] = randomGenerator.Next(100);
            }
        }
    }

    public static void PrintMatrix(int width, int height, int[][] matrix)
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }

            Console.WriteLine(Environment.NewLine);
        }
    }

    public static int[][] InitialiseMatrix(int width, int height)
    {
        var matrix = new int[width][];
        for (var i = 0; i < width; i++)
        {
            matrix[i] = new int[height];
        }

        return matrix;
    }
}