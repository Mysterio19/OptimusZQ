using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class SharedFile : Entity
    {
        public string Scopes { get; set; }

        public User User { get; set; }

        public File File { get; set; }
    }
}
