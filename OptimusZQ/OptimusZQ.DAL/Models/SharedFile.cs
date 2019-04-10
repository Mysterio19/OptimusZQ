using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class SharedFile : File
    {
        public string Scopes { get; set; }

        public User User { get; set; }
    }
}
