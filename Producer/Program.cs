using Newtonsoft.Json;
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
            //redis.ListRightPush(listKey, new RedisValue(JsonConvert.SerializeObject(new MessageModel { Id = 1, Message = "Message1", PatientId = 1 })));
            //redis.ListRightPush(listKey, new RedisValue(JsonConvert.SerializeObject(new MessageModel { Id = 2, Message = "Message2", PatientId = 2 })));

            //Push data to redis list 
            redis.ListRightPush(listKey, 1);
            redis.ListRightPush(listKey, 2);

            Console.ReadLine();
        }
    }
}