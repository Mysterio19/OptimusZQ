using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class File : Entity
    {
        public string FileName { get; set; }

        public Folder Folder { get; set; }
    }
}
