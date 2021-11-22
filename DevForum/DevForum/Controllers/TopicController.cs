using DevForum.Helpers;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Topic;
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
    public class TopicController : ControllerBase
    {
        private ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [AllowAnonymous]
        [HttpGet("{pageNum}/{pageSize}")]
        public object Get(int pageNum, int pageSize, [FromQuery] TopicSearchObject model = null)
        {
            var res = _topicService.Get(model);
            var p = new PaginatedResponse<TopicViewModel>(res, pageNum, pageSize);
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
        public async Task<TopicViewModel> GetById(int id)
        {
            return await _topicService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<TopicViewModel> Insert(TopicInsertModel model)
        {
            return await _topicService.Insert(model);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<TopicViewModel> Update(int id, TopicUpdateModel model)
        {
            return await _topicService.Update(id, model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _topicService.Delete(id);
        }
    }
}
