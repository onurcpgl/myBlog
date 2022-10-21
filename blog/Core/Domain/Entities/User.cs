using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string userName { get; set; }
        public string firstName { get; set; }   
        public string lastName { get; set; }    
        public int age { get; set; }
        public DateTime createdDate { get; set; }
        public string emailAdress { get; set; } 
        public string password { get; set; }
        public DateTime lastLogin { get; set; }
        public string role { get; set; }

    }
}
