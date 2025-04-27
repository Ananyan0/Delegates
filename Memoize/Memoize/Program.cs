namespace Memoize;

class Program
{

    public static Func<T, T> Memoize<T>(Func <T, T> func)
    {

        Dictionary<T, T> cache = new Dictionary<T, T>();
       
        return (x) => {
            if (cache.ContainsKey(x)) 
            {
                return cache[x];
            }
            else
            {
                T result = func(x);
                cache.Add(x, result);
                return result;
            }
        };
    }


    static void Main(string[] args)
    {
        Func<int, int> factorial = (int p) => {
            if(p == 0) return 1;
            int temp = 1;
            for(int i = 2; i <= p; i++)
            {
                temp *= i;
            }
            return temp;
        };

        var memoFact = Memoize(factorial);

        
        Console.WriteLine((memoFact(5))); // 120
        Console.WriteLine((memoFact(4)));
        Console.WriteLine((memoFact(5)));
        Console.WriteLine((memoFact(5)));
        Console.WriteLine((memoFact(8)));
        
    }
}
