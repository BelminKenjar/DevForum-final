
using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Reply;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class PostReplyService : IPostReplyService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public PostReplyService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<PostReplyViewModel> Insert(PostReplyInsertModel model)
        {
           
            var entity = _mapper.Map<PostReply>(model);
            var posts = _applicationDbContext.Set<Post>();
            //foreach (var p in posts)
            //{
            //    if (p.Id == entity.PostId)
            //    {
            //        p.ReplyCount++;
            //    }
            //}
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            
            return _mapper.Map<PostReplyViewModel>(entity);
        }
        public async Task<PostReplyViewModel> Update(int id, PostReplyUpdateModel model)
        {

            var entity = _applicationDbContext.Set<PostReply>().Find(id);
            _mapper.Map(model, entity);
            entity.EditedAt = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostReplyViewModel>(entity);
        }
        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<PostReply>().Find(id);
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<PostReplyViewModel> GetById(int id)
        {
            var entity = await _applicationDbContext.Set<PostReply>()
                               .Include(x => x.Post)
                               .Include(x => x.Profile)
                               .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PostReplyViewModel>(entity);
        }
        public IEnumerable<PostReplyViewModel> Get(int PostId, PostReplySearchObject model = null)
        {
            var reply = _applicationDbContext.Set<Post>().Find(PostId);
            var query = _applicationDbContext.Set<PostReply>().AsQueryable();
            if (!String.IsNullOrEmpty(model?.Content))
                query = query.Where(x => x.Content.ToLower().Contains(model.Content.ToLower()));
            query = query.Where(x => x.PostId == PostId);
            query.Where(x => x.PostId == PostId).Select(x => x.Profile.FirstName);

            var res = query.Include(x => x.Profile).ThenInclude(z => z.Posts).ToList();
            reply.ReplyCount = res.Count();

            _applicationDbContext.SaveChanges();
            return _mapper.Map<IEnumerable<PostReplyViewModel>>(res);
        }
    }
}
