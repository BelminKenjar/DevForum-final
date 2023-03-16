using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class PostService : IPostService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public PostService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<PostViewModel> Insert(PostInsertModel model)
        {
            var entity = _mapper.Map<Post>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostViewModel>(entity);
        }
        public async Task<PostViewModel> Update(int id, PostUpdateModel model)
        {
            var entity = _applicationDbContext.Set<Post>().Find(id);
            _mapper.Map(model, entity);
            entity.EditedAt = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostViewModel>(entity);
        }
        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<Post>().Find(id);
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
        public IEnumerable<PostViewModel> Get(int SubTopicId, PostSearchObject model = null)
        {
            var query = _applicationDbContext.Set<Post>().AsQueryable();
            if (!String.IsNullOrEmpty(model?.Title))
                query = query.Where(x => x.Title.ToLower().Contains(model.Title.ToLower()));
            query = query.Where(x => x.SubTopicId == SubTopicId);
            var res = query.Include(x=>x.Profile).ToList();
            return _mapper.Map<IEnumerable<PostViewModel>>(res);
        }
        public async Task<PostViewModel> GetById(int id)
        {
            var entity = await _applicationDbContext.Set<Post>()
                               .Include(x => x.SubTopic)
                               .Include(x=> x.Profile)
                               .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PostViewModel>(entity);
        }
    }
}
