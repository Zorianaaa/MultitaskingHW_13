using System;
using System.Threading.Tasks;

class ArrayOperations
{
    private int[] array;

    public ArrayOperations(int[] array)
    {
        this.array = array;
    }

    public int FindMin()
    {
        int min = array[0];
        foreach (var num in array)
        {
            if (num < min)
                min = num;
        }
        return min;
    }

    public int FindMax()
    {
        int max = array[0];
        foreach (var num in array)
        {
            if (num > max)
                max = num;
        }
        return max;
    }

    public int CalculateSum()
    {
        int sum = 0;
        foreach (var num in array)
        {
            sum += num;
        }
        return sum;
    }

    public double CalculateAverage()
    {
        return CalculateSum() / (double)array.Length;
    }
}
