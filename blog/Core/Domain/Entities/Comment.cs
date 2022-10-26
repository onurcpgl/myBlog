using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public Comment? ParentComment { get; set; }
        public int? ParentCommentId { get; set; }
        public ICollection<Comment> ChildComment { get; set; }
        public Article Article { get; set; }
        public int ArticleId { get; set; }


    }
}
