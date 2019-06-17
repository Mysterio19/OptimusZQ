using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.Services
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public string SecretKey { get; set; }

        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }
    }
}
