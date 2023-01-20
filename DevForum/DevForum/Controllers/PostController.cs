using DevForum.Helpers;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Posts;
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
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet("{id}/{pageNum}/{pageSize}")]
        public object Get(int id, int pageNum, int pageSize, [FromQuery] PostSearchObject model)
        {
            var res = _postService.Get(id, model);
            var p = new PaginatedResponse<PostViewModel>(res, pageNum, pageSize);
            var totalCount = res.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var response = new
            {
                Page = p,
                TotalPages = totalPages
            };
            return response;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<PostViewModel> GetById(int id)
        {
            return await _postService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<PostViewModel> Insert(PostInsertModel model)
        {
            return await _postService.Insert(model);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<PostViewModel> Update(int id, PostUpdateModel model)
        {

            return await _postService.Update(id, model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postService.Delete(id);
        }
    }
}
