using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class Folder : Entity
    {
        public string Name { get; set; }

        public string FullPath { get; set; }

        public User User { get; set; }

        public ICollection<File> Files { get; set; }

        public Folder ParentFolder { get; set; }

        public ICollection<Folder> Folders { get; set; }

    }
}
