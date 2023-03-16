using DevForum.Services.Interfaces;
using DevForum.ViewModels.PostLike;
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
    public class PostLikeController : ControllerBase
    {
        private IPostLikeService _postLikeService;

        public PostLikeController(IPostLikeService postLikeService)
        {
            _postLikeService = postLikeService;
        }
        [Authorize]
        [HttpPost]
        public async Task<PostLikeViewModel> Insert(PostLikeInsertModel model)
        {
            return await _postLikeService.Insert(model);
        }
    }
}
