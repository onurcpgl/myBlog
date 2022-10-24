using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public Category CategoryId { get; set; }
    }
}
