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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICommentReadRepository _commentReadRepository; 
        private readonly IMapper _mapper;
        public ArticleService(ICommentReadRepository commentReadRepository, IArticleReadRepository articleReadRepository, IArticleWriteRepository articleWriteRepository, ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _articleReadRepository = articleReadRepository;
            _articleWriteRepository = articleWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _commentReadRepository = commentReadRepository;
            _mapper = mapper;
        }

        public async Task<List<Article>> articleList()
        {
            List<Article> articleList = await _articleReadRepository.GetAll().ToListAsync();
            return articleList;
        }

        public async Task<Article> getArticleListById(int id)
        {
            List<Comment> childComment = await _commentReadRepository.GetWhereWithInclude(x => x.ArticleId == id, true, x => x.ChildComment).ToListAsync();
            var article = await _articleReadRepository.GetWhereWithInclude(x => x.Id == id, true, x => x.Category, x => x.Comments).FirstOrDefaultAsync();
            article.Comments = childComment;
            return article;
        }

        public async Task<bool> saveArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            article.Code = Guid.NewGuid().ToString();
            var getCategory = await _categoryReadRepository.GetByIdAsync(articleDto.CategoryId);
            article.Category = getCategory;
            var result = await _articleWriteRepository.AddAsync(article);
            return result;
        }
    }
}
