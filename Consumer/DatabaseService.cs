using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class DatabaseService
    {
        public static MessageModel RetrieveMessageFromDatabase(int id)
        {
            //return mockup data
            return new MessageModel { Id = 1, Message = "Message1", PatientId = 1 };
        }
    }
}
