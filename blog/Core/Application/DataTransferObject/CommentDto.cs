using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class CommentDto
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        public int? ArticleId { get; set; }

    }
}
