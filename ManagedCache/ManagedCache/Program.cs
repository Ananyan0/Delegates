namespace MangedCache;

class Program
{
    public static  (Func<int,bool> IsPrime, Action ClearCache) ManagedCache(Func<int, bool> isPrime, Action clearCache)
    {
        Dictionary<int, bool> cache = new Dictionary<int, bool>();

        Func<int, bool> IsPrime = (x) => 
        {
            if(cache.ContainsKey(x))
            {
                return cache[x];
            }
            else
            {
                bool result = isPrime(x);
                cache.Add(x, result);
                return result;
            }
        };

        Action ClearCache = () => {
            cache.Clear();
            Console.WriteLine("Cache Cleared");
        };

        return (isPrime, clearCache);
    }


    static void Main(string[] args)
    {
        Func<int, bool> isPrime = (int n) =>{
            if(n < 2) return false;
            int count = 0;
            for(int i = n; i >= 1; i--)
            {
                if(n % i == 0)
                {
                    count++;
                }
            }
            if(count == 2) return true;
            else return false;
        };

        Action ClearCache = () => {
            Console.WriteLine("Cache Cleared");
         };



        var managedCache = ManagedCache(isPrime, ClearCache);
        
        Console.WriteLine(managedCache.IsPrime(5)); 
        Console.WriteLine(managedCache.IsPrime(5)); 

   
        managedCache.ClearCache();

        Console.WriteLine(managedCache.IsPrime(5));
    }

}

