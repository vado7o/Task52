// Задача 52: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Console.Clear();
Console.WriteLine("Программа, высчитывающая среднее арифметическое каждого из столбцов двумерного массива");

int row = 0;
int column = 0;

AskForInput("row");
AskForInput("column");

int[,] array = FillArray(row, column, 0, 10);

Console.Write("\nCгенерированный массив: \n");
PrintArray(array);

CalcAverageColumn(array);

///////////////// функции: //////////////////////////////
int[,] FillArray(int row, int column, int min, int max)
{
    int[,] filledArray = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
        filledArray[i, j] = new Random().Next(min, max);
        }
    }
    return filledArray;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
    Console.WriteLine();
    }   
}

void AskForInput(string str)
{
    while (true)
    {
        if(str == "row")
        {
            Console.Write("\nНапишите - из скольки строк должен состоять массив? :");
        }
        else if(str == "column") 
        {
            Console.Write("\nНапишите - из скольки столбцов должен состоять массив? :");
        }
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number > 0)
            {
                if(str == "row")
                {
                    row = number;
                }
                else if(str == "column")
                {
                    column = number;
                }
                break;
            }
            else Console.WriteLine("Некорректно указано количество строк массива!\n");
        }
        else Console.WriteLine("Некорректно указано количество строк массива!\n");
    }
}

void CalcAverageColumn(int[,] array)
{
    double sum = 0.0;
    int count = 1;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            sum += Convert.ToDouble(array[j, i]);
        }
        Console.WriteLine("Среднее арифметическое столбца " + count + " массива: " + sum / Convert.ToDouble(array.GetLength(0)));
        count++;
        sum = 0;
    }
}