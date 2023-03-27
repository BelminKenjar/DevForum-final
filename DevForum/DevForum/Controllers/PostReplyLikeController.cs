using DevForum.Services.Interfaces;
using DevForum.ViewModels.PostLike;
using DevForum.ViewModels.PostReplyLike;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostReplyLikeController : ControllerBase
    {
        private IPostReplyLikeService _postReplyLikeService;

        public PostReplyLikeController(IPostReplyLikeService postReplyLikeService)
        {
            _postReplyLikeService = postReplyLikeService;
        }
        [Authorize]
        [HttpPost]
        public async Task<PostReplyLikeViewModel> Insert(PostReplyLikeInsertModel model)
        {
            return await _postReplyLikeService.Insert(model);
        }
    }
}
