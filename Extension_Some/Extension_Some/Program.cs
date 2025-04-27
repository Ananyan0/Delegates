namespace Extension_Some;

static class Extension
{
    public static bool Some<T>(this List<T> list, Func<T, bool> func)
    {
       foreach(var item in list)
       {
        if(func(item))
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
        List<int> list = new List<int>(){ 1, 2, 3, 4, 5, -6, 7, 8, 9};

        
        bool result = list.Some(a => a < 0);
        System.Console.WriteLine(result);
    }
}