using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.PostLike;
using DevForum.ViewModels.PostReplyLike;
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
    public class PostReplyLikeService : IPostReplyLikeService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public PostReplyLikeService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<PostReplyLikeViewModel> Insert(PostReplyLikeInsertModel model)
        {
            var entity = _mapper.Map<PostReplyLike>(model);
            var postReplyLikes = _applicationDbContext.Set<PostReplyLike>().ToList();
            var postReplies = _applicationDbContext.Set<PostReply>().ToList();

            for (int i = 0; i < postReplies.Count; i++)
            {
                if (postReplies[i].Id == entity.PostReplyId)
                {
                    if (!postReplyLikes.Any(x => x.ProfileId == model.ProfileId && x.PostReplyId == model.PostReplyId))
                    {
                        var x = new PostReplyLike
                        {
                            CreatedAt = DateTime.Now,
                            PostReplyId = postReplies[i].Id,
                            ProfileId = entity.ProfileId
                        };
                        postReplies[i].LikeCount += 1;
                        await _applicationDbContext.PostReplyLikes.AddAsync(x);
                        await _applicationDbContext.SaveChangesAsync();
                        return _mapper.Map<PostReplyLikeViewModel>(entity);
                    }
                    else
                    {
                        var z = postReplyLikes.Find(x => x.PostReplyId == model.PostReplyId && x.ProfileId == model.ProfileId);
                        postReplies[i].LikeCount -= 1;
                        _applicationDbContext.PostReplyLikes.Remove(z);
                        await _applicationDbContext.SaveChangesAsync();
                        return _mapper.Map<PostReplyLikeViewModel>(entity);
                    }
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<PostReplyLikeViewModel>(entity);
        }
    }
}
