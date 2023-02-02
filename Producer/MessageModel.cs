﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
