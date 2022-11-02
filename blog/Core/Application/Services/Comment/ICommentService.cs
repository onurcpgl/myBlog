using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICommentService 
    {
        Task<bool> saveComment(CommentDto CommnetDto);

        Task<Comment> getCommentById(int id);
        Task<List<Comment>> CommentList();
    }
}
