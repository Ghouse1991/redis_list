using StackExchange.Redis;

namespace Consumer
{
    public class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel";

        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;

            //Redis Key
            var listKey = "listKey";
            Console.WriteLine("ListRange", string.Concat(redis.ListRange(listKey)));

            var lastElement = redis.ListRange(listKey, 0, 1);
            Console.WriteLine("List: FirstElement", string.Concat(lastElement));

            //Pop data to redis list 
            var firstElement = redis.ListLeftPop(listKey);

            Console.WriteLine("List: After removal", string.Concat(redis.ListRange(listKey)));

            Console.ReadLine();
        }
    }
}