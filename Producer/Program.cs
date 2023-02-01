using StackExchange.Redis;

namespace Producer
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
            redis.KeyDelete(listKey, CommandFlags.FireAndForget);

            //Push data to redis list 
            redis.ListRightPush(listKey, "Element1");
            redis.ListRightPush(listKey, "Element2");

            Console.ReadLine();
        }
    }
}