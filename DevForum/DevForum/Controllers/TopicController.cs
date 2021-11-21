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
        [HttpGet]
        public IEnumerable<TopicViewModel> Get([FromQuery] TopicSearchObject model = null)
        {
            return _topicService.Get(model);
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

        [HttpPost("id")]
        public async Task<TopicViewModel> Update(int id, TopicUpdateModel model)
        {
            return await _topicService.Update(id, model);
        }

        public async Task Delete(int id)
        {
            await _topicService.Delete(id);
        }
    }
}
