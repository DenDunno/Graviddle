


public static class Algorithms
{
    public static void Swap<T>(T firstElement, T secondElement)
    {
        T temp = firstElement;

        firstElement = secondElement;
        secondElement = temp;
    }
}
