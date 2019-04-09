using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<Folder> Folders { get; set; }

        public ICollection<SharedFile> SharedFiles { get; set; }
    }
}
