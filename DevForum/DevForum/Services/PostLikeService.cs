using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.PostLike;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
            var postLikes = _applicationDbContext.Set<PostLike>().ToList();
            var posts = _applicationDbContext.Set<Post>().ToList();

            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == entity.PostId)
                {
                    if (!postLikes.Any(x=>x.ProfileId == model.ProfileId && x.PostId == model.PostId))
                    {
                        var x = new PostLike
                        {
                            CreatedAt = DateTime.Now,
                            PostId = posts[i].Id,
                            ProfileId = entity.ProfileId
                        };
                        posts[i].LikeCount += 1;
                        await _applicationDbContext.PostLikes.AddAsync(x);
                        await _applicationDbContext.SaveChangesAsync();
                        return _mapper.Map<PostLikeViewModel>(entity);
                    }
                    else
                    {
                        var z = postLikes.Find(x => x.PostId == model.PostId && x.ProfileId == model.ProfileId);
                        posts[i].LikeCount -= 1;
                        _applicationDbContext.PostLikes.Remove(z);
                        await _applicationDbContext.SaveChangesAsync();
                        return _mapper.Map<PostLikeViewModel>(entity);
                    }
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostLikeViewModel>(entity);
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
        //    var likes = _applicationDbContext.Set<Post>().Find(PostId);
        //    var query = _applicationDbContext.Set<PostLike>().AsQueryable();
        //    query = query.Where(x => x.PostId == PostId);
        //    query.Where(x => x.PostId == PostId).Select(x => x.Profile.FirstName);
        //    var res = query.Include(x => x.Profile).ThenInclude(z => z.Posts).ToList();

        //    return _mapper.Map<IEnumerable<PostLikeViewModel>>(res);
        //}

    }
}
