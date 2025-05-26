namespace ExceptionsLibrary;

public class DemoCode
{
    public int GrandparentMethod(int position)
    {
        return ParentMethod(position);
    }

    public int ParentMethod(int position)
    {
        return GetNumber(position);
    }

    public int GetNumber(int position)
    {
        int[] numbers = { 1, 4, 7, 2 };

        return numbers[position];
    }
}
