using DevForum.Helpers;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Subtopic;
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
    public class SubtopicController : ControllerBase
    {
        private ISubtopicService _subtopicService;

        public SubtopicController(ISubtopicService subtopicService)
        {
            _subtopicService = subtopicService;
        }

        [AllowAnonymous]
        [HttpGet("{id}/{pageNum}/{pageSize}")]
        public object Get(int id, int pageNum, int pageSize, [FromQuery] SubtopicSearchObject model)
        {
            var res = _subtopicService.Get(id, model);
            var p = new PaginatedResponse<SubtopicViewModel>(res, pageNum, pageSize);
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
        public async Task<SubtopicViewModel> GetById(int id)
        {
            return await _subtopicService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<SubtopicViewModel> Insert(SubtopicInsertModel model)
        {
            return await _subtopicService.Insert(model);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<SubtopicViewModel> Update(int id, SubtopicUpdateModel model)
        {
            return await _subtopicService.Update(id, model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _subtopicService.Delete(id);
        }
    }
}
