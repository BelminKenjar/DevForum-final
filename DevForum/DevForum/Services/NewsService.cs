using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.News;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class NewsService : INewsService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;
        public NewsService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public IEnumerable<NewsViewModel> Get()
        {
            var res = _applicationDbContext.Set<News>().Include(x => x.Profile).OrderByDescending(x => x.CreatedAt).ToList();
            return _mapper.Map<IEnumerable<NewsViewModel>>(res);
        }

        public NewsViewModel GetById(int id)
        {
            var res = _applicationDbContext.Set<News>().Find(id);
            return _mapper.Map<NewsViewModel>(res);
        }

        public async Task<NewsViewModel> Insert(NewsInsertModel model)
        {
            var entity = _mapper.Map<News>(model);
            await _applicationDbContext.Set<News>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<NewsViewModel>(entity);
        }

        public async Task<NewsViewModel> Update(int id, NewsUpdateModel model)
        {
            var entity = _applicationDbContext.Set<News>().Find(id);
            _mapper.Map(model, entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<NewsViewModel>(entity);
        }
        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<News>().Find(id);
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
