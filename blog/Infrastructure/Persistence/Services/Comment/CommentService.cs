using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository, IArticleReadRepository articleReadRepository, IUserReadRepository userReadRepository, IMapper mapper)
        {
            _commentReadRepository = commentReadRepository;
            _commentWriteRepository = commentWriteRepository;
            _articleReadRepository = articleReadRepository;
            _userReadRepository = userReadRepository;
            _mapper = mapper;   
        }

     
        public async Task<List<Comment>> CommentList()
        {
            List<Comment> commentList2 = await _commentReadRepository.GetWhereWithInclude(x => x.ParentCommentId == null,true, x => x.ChildComment).ToListAsync();
            return commentList2;
        }

        public async Task<Comment> getCommentById(int id)
        {
            var result = await _commentReadRepository.GetWhereWithInclude(x => x.Id == id, true, x => x.ChildComment).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> saveComment(CommentDto commentDto)
        {
            var commnet = _mapper.Map<Comment>(commentDto);
            var result = await _commentWriteRepository.AddAsync(commnet);
            return result; 
        }
    }
}
