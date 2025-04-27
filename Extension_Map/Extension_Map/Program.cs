namespace Extension_Map;

static class Extension
{
    public static List<T> Map<T>(this List<T> list, Func<T, T> isOkay)
    {
        List<T> newList = new List<T>();

        for(int i = 0; i < list.Count; i++)
        {
            newList.Add(isOkay(list[i]));
        }

        return newList;
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9};

        List<int> result = list.Map(a => a + 10);

        foreach(int i in result)
        {
            System.Console.WriteLine(i);
        }
    }
}