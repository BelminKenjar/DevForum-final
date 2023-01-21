using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.PostLike;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class PostLikeService : IPostLikeService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public PostLikeService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<PostLikeViewModel> Insert(PostLikeInsertModel model)
        {
            var entity = _mapper.Map<PostLike>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostLikeViewModel>(entity);
        }
        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<PostLike>().Find(id);
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
        //public async Task<PostLikeViewModel> GetById(int id)
        //{
        //    var entity = await _applicationDbContext.Set<PostLike>()
        //                       .Include(x => x.Post)
        //                       .Include(x => x.Profile)
        //                       .FirstOrDefaultAsync(x => x.Id == id);
        //    return _mapper.Map<PostLikeViewModel>(entity);
        //}
        //public IEnumerable<PostLikeViewModel> Get(int PostId)
        //{
        //    var query = _applicationDbContext.Set<PostLike>().AsQueryable();
        //    if (!String.IsNullOrEmpty(model?.Content))
        //        query = query.Where(x => x.Content.ToLower().Contains(model.Content.ToLower()));
        //    query = query.Where(x => x.PostId == PostId);
        //    query.Where(x => x.PostId == PostId).Select(x => x.Profile.FirstName);

        //    var res = query.Include(x => x.Profile).ThenInclude(z => z.Posts).ToList();

        //    return _mapper.Map<IEnumerable<PostLikeViewModel>>(res);
        //}

    }
}
