using UnityEngine;


public static class Extensions
{
    public static void Swap<T>(ref T input1, ref T input2)
    {
        T temp = default(T);

        temp = input2;
        input2 = input1;
        input1 = temp;
    }
}