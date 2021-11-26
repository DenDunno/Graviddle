

public static class Algorithms
{
    public static void Swap<T>(ref T firstElement, ref T secondElement)
    {
        T temp = firstElement;

        firstElement = secondElement;
        secondElement = temp;
    }
}
