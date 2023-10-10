namespace PSB_ex6.Refactor;

public class MatrixMultiplication
{
    public static void Launch()
    {
        Console.WriteLine("Вас приветствует программа быстрого перемножения матриц методом Штрассена" + Environment.NewLine + Environment.NewLine);
        int width1, height1, width2, height2;
        int userChoise;
        var l = 2;

        // Ввод размеров матрицы пользователем.
        do
        {
            Console.WriteLine("Введите размеры первой матрицы" + Environment.NewLine);
            width1 = int.Parse(Console.ReadLine());
            height1 = int.Parse(Console.ReadLine());
        }
        while (width1 <= 0 || height1 <= 0);

        do
        {
            Console.WriteLine("Введите размеры второй матриц" + Environment.NewLine);
            width2 = int.Parse(Console.ReadLine());
            height2 = int.Parse(Console.ReadLine());
        }
        while (width2 <= 0 || height2 <= 0);

        int[][] matrix1 = Functions.InitialiseMatrix(width1, height1);
        int[][] matrix2 = Functions.InitialiseMatrix(width2, height2);

        // Выбор способа заполнения и заполнение матриц.
        do
        {
            Console.WriteLine($"Выберите способ заполнения матриц{Environment.NewLine}1 - Вручную{Environment.NewLine}2 - Случайным образом{Environment.NewLine}");
            userChoise = int.Parse(Console.ReadLine());
        }
        while (userChoise < 1 || userChoise > 2);

        if (userChoise == 1)
        {
            Functions.FillMatrix(width1, height1, matrix1);
            Functions.FillMatrix(width2, height2, matrix2);
        }
        else
        {
            Functions.FillRandomMatrix(width1, height1, matrix1);
            Functions.FillRandomMatrix(width2, height2, matrix2);
        }

        Console.WriteLine(Environment.NewLine + "Матрица 1" + Environment.NewLine + Environment.NewLine);
        Functions.PrintMatrix(width1, height1, matrix1);

        Console.WriteLine(Environment.NewLine + "Матрица 2" + Environment.NewLine + Environment.NewLine);
        Functions.PrintMatrix(width2, height2, matrix2);

        // Приведение матриц к требуемому размеру.
        while (l < width1 ||
               l < width2 ||
               l < height1 ||
               l < height2)
        {
            l *= 2;
        }

        int[][] scaledMatrix1 = Functions.InitialiseMatrix(l, l);
        int[][] scaledMatrix2 = Functions.InitialiseMatrix(l, l);

        Functions.CopyMatrix(width1, height1, scaledMatrix1, matrix1);
        Functions.CopyMatrix(width2, height2, scaledMatrix2, matrix2);

        Console.WriteLine("Приведенные матрицы" + Environment.NewLine);
        Console.WriteLine(Environment.NewLine + "Матрица 1" + Environment.NewLine + Environment.NewLine);
        Functions.PrintMatrix(l, l, scaledMatrix1);

        Console.WriteLine(Environment.NewLine + "Матрица 2" + Environment.NewLine + Environment.NewLine);
        Functions.PrintMatrix(l, l, scaledMatrix2);

        // Разбиение матриц на подматрицы и их заполнение.
        int[][][] subMatrices = new int[8][][];
        for (int i = 0; i < 8; i++) {
            subMatrices[i] = Functions.InitialiseMatrix(l / 2, l / 2);
        }
        for (var i = 0; i < l / 2; i++)
        {
            for (var j = 0; j < l / 2; j++)
            {
                subMatrices[0][i][j] = scaledMatrix1[i][j];
                subMatrices[1][i][j] = scaledMatrix1[i][j + l / 2];
                subMatrices[2][i][j] = scaledMatrix1[i + l / 2][j];
                subMatrices[3][i][j] = scaledMatrix1[i + l / 2][j + l / 2];
                subMatrices[4][i][j] = scaledMatrix2[i][j];
                subMatrices[5][i][j] = scaledMatrix2[i][j + l / 2];
                subMatrices[6][i][j] = scaledMatrix2[i + l / 2][j];
                subMatrices[7][i][j] = scaledMatrix2[i + l / 2][j + l / 2];
            }
        }

        // Создание промежуточных матриц.
        int[][][] tempMatrices =
        {
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2)
        };

        // Вычисление значений промежуточных матриц.
        for (var i = 0; i < l / 2; i++)
        {
            for (var j = 0; j < l / 2; j++)
            {
                for (var z = 0; z < l / 2; z++)
                {
                    tempMatrices[0][i][j] +=
                        (subMatrices[0][i][z] + subMatrices[3][i][z]) *
                        (subMatrices[4][z][j] + subMatrices[7][z][j]);

                    tempMatrices[1][i][j] +=
                        (subMatrices[2][i][z] + subMatrices[3][i][z]) *
                        subMatrices[4][z][j];

                    tempMatrices[2][i][j] +=
                        subMatrices[0][i][z] *
                        (subMatrices[5][z][j] - subMatrices[7][z][j]);

                    tempMatrices[3][i][j] +=
                        subMatrices[3][i][z] *
                        (subMatrices[6][z][j] - subMatrices[4][z][j]);

                    tempMatrices[4][i][j] +=
                        (subMatrices[0][i][z] + subMatrices[1][i][z]) *
                        subMatrices[7][z][j];

                    tempMatrices[5][i][j] +=
                        (subMatrices[2][i][z] - subMatrices[0][i][z]) *
                        (subMatrices[4][z][j] + subMatrices[5][z][j]);

                    tempMatrices[6][i][j] +=
                        (subMatrices[1][i][z] - subMatrices[3][i][z]) *
                        (subMatrices[6][z][j] + subMatrices[7][z][j]);
                }
            }
        }

        // Создание вспомогательных матриц.
        int[][][] auxiliaryMatrices =
        {
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2),
            Functions.InitialiseMatrix(l / 2, l / 2)
        };

        // Подсчет значений вспомогательных матриц из промежуточных.
        for (var i = 0; i < l / 2; i++)
        {
            for (var j = 0; j < l / 2; j++)
            {
                auxiliaryMatrices[0][i][j] =
                    tempMatrices[0][i][j] + tempMatrices[3][i][j] -
                    tempMatrices[4][i][j] + tempMatrices[6][i][j];

                auxiliaryMatrices[1][i][j] =
                    tempMatrices[2][i][j] + tempMatrices[4][i][j];

                auxiliaryMatrices[2][i][j] =
                    tempMatrices[1][i][j] + tempMatrices[3][i][j];

                auxiliaryMatrices[3][i][j] =
                    tempMatrices[0][i][j] - tempMatrices[1][i][j] +
                    tempMatrices[2][i][j] + tempMatrices[5][i][j];
            }
        }

        // Создание результирующей матрицы.
        int[][] scaledResultMatrix = Functions.InitialiseMatrix(l, l);

        // Занесение информации из вспомогательных матриц в результирующую.
        for (var i = 0; i < l / 2; i++)
        {
            for (var j = 0; j < l / 2; j++)
            {
                scaledResultMatrix[i][j] = auxiliaryMatrices[0][i][j];
                scaledResultMatrix[i][j + l / 2] = auxiliaryMatrices[1][i][j];
                scaledResultMatrix[i + l / 2][j] = auxiliaryMatrices[2][i][j];
                scaledResultMatrix[i + l / 2][j + l / 2] = auxiliaryMatrices[3][i][j];
            }
        }

        // Выравнивание границ результирующей матрицы.
        var width = 100;
        var height = 100;
        for (var i = 0; i < l; i++)
        {
            var zeroWidthCounter = 0;
            var zeroHeightCounter = 0;
            for (var j = 0; j < l; j++)
            {
                if (scaledResultMatrix[i][j] != 0)
                {
                    zeroWidthCounter++;
                    width = 100;
                }

                if (scaledResultMatrix[j][i] != 0)
                {
                    zeroHeightCounter++;
                    height = 100;
                }
            }

            if (zeroWidthCounter == 0 && i < width)
            {
                width = i;
            }

            if (zeroHeightCounter == 0 && i < height)
            {
                height = i;
            }
        }

        int[][] resultMatrix = Functions.InitialiseMatrix(width, height);
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                resultMatrix[i][j] = scaledResultMatrix[i][j];
            }
        }

        // Вывод результирующей матрицы.
        Console.WriteLine(Environment.NewLine + "Результирующая матрица" + Environment.NewLine + Environment.NewLine);
        Functions.PrintMatrix(width, height, resultMatrix);
    }
}