﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpesaClient
{
    public class ApiClientOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
        public bool Ssl { get; set; }
        public ApiMethodTypes MethodType { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Path { get; set; } = string.Empty;
        public Dictionary<string, string>? Headers { get; set; }
        public Dictionary<string, string>? Parameters { get; set; }
    }
}
