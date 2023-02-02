using Newtonsoft.Json;
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

            //Select using list range
            var elementByRange = redis.ListRange(listKey, 0, 1);
            var deserializeObject = JsonConvert.DeserializeObject<MessageModel>(elementByRange.FirstOrDefault());
            Console.WriteLine("List: FirstElement", deserializeObject);

            //Select specific value
            var elementbyIndex = redis.ListGetByIndex(listKey, 2);
            deserializeObject = JsonConvert.DeserializeObject<MessageModel>(elementbyIndex);
            Console.WriteLine("List: FirstElement", deserializeObject);


            //Left Pop
            var popElement = redis.ListLeftPop(listKey);
            deserializeObject = JsonConvert.DeserializeObject<MessageModel>(popElement);

            Console.WriteLine("List: After removal", string.Concat(redis.ListRange(listKey)));

            Console.ReadLine();
        }
    }
}