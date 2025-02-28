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
            var profileEntity = _applicationDbContext.ProfileStats.FirstOrDefault(x => x.ProfileId == model.ProfileId);
            profileEntity.PostsCreated++;
            _applicationDbContext.Update(profileEntity);
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
            var replyEntity = _applicationDbContext.Set<PostReply>().Where(x=>x.PostId == id).ToList();
            foreach(var reply in replyEntity)
            { 
            _applicationDbContext.Remove(reply);
            }
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
            var postReplies = _applicationDbContext.PostReplies.Where(x => x.PostId == id).ToList();
            var likes = _applicationDbContext.PostReplyLikes.ToList();
            var brojacLike = 0;
            foreach (var reply in postReplies)
            {
                foreach (var like in likes)
                {
                    if (like.PostReplyId == reply.Id)
                    {
                        brojacLike++;
                    }
                }
                reply.LikeCount = brojacLike;
                brojacLike = 0;
                _applicationDbContext.PostReplies.Update(reply);
                _applicationDbContext.SaveChanges();
            }
            return _mapper.Map<PostViewModel>(entity);
        }
    }
}
