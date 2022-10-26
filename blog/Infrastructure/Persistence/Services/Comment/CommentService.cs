using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
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

        public Task<Comment> getChildCommets(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> saveComment(CommentDto commentDto)
        {
            var commnet = _mapper.Map<Comment>(commentDto);
            var getUser = await _userReadRepository.GetByIdAsync(commentDto.UserId);
            commnet.User = getUser;
            var getArticle = await _articleReadRepository.GetByIdAsync(commentDto.ArticleId);
            commnet.Article = getArticle;
            var result = await _commentWriteRepository.AddAsync(commnet);
            return result; 
        }
    }
}
