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
    public class ArticleService : IArticleService
    {
        private readonly IArticleReadRepository _articleReadRepository;
        private readonly IArticleWriteRepository _articleWriteRepository;
        private readonly IMapper _mapper;
        public ArticleService(IArticleReadRepository articleReadRepository, IArticleWriteRepository articleWriteRepository, IMapper mapper)
        {
            _articleReadRepository = articleReadRepository;
            _articleWriteRepository = articleWriteRepository;
            _mapper = mapper;
        }

        public async Task<Article> getArticleListById(int id)
        {
            var category = await _articleReadRepository.GetWhereWithInclude(x => x.Id == id, true, x => x.Category).FirstOrDefaultAsync();
            return category;
        }

        public async Task<bool> saveArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            article.Code = Guid.NewGuid().ToString();
            var result = await _articleWriteRepository.AddAsync(article);
            return result;
        }
    }
}
