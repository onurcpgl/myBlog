using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
