using DevForum.Helpers;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Reply;
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
    public class PostReplyController : ControllerBase
    {
        private IPostReplyService _postReplyService;

        public PostReplyController(IPostReplyService postReplyService)
        {
            _postReplyService = postReplyService;
        }

        [AllowAnonymous]
        [HttpGet("{id}/{pageNum}/{pageSize}")]
        public object Get(int id, int pageNum, int pageSize, [FromQuery] PostReplySearchObject model)
        {
            var res = _postReplyService.Get(id, model);
            var p = new PaginatedResponse<PostReplyViewModel>(res, pageNum, pageSize);
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
        public async Task<PostReplyViewModel> GetById(int id)
        {
            return await _postReplyService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<PostReplyViewModel> Insert(PostReplyInsertModel model)
        {
            return await _postReplyService.Insert(model);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<PostReplyViewModel> Update(int id, PostReplyUpdateModel model)
        {

            return await _postReplyService.Update(id, model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postReplyService.Delete(id);
        }
    }
}
