namespace Extension_Every;

static class Extension
{
    public static bool Every<T>(this List<T> list, Func<T, bool> isOkay)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(isOkay(list[i]))
            {
                return true;
            }
        }
        return false;
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 7, 7};

        bool result = list.Every(a => a > 7);

        Console.WriteLine(result);
    }
}