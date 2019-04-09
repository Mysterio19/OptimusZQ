using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case Entity castObj:
                    return castObj.Id == Id;
                default:
                    return false;
            }
        }
    }
}
