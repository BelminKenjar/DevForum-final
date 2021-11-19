using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        private ApplicationDbContext _applicationDbContext;

        public NewsController(INewsService newsService, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _newsService = newsService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<NewsViewModel> Get()
        {
            return _newsService.Get();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public NewsViewModel GetById(int id)
        {
            return _newsService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<NewsViewModel> Insert(NewsInsertModel model)
        {
            return await _newsService.Insert(model);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<NewsViewModel> Update(int id, NewsUpdateModel model)
        {
            return await _newsService.Update(id, model);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _newsService.Delete(id);
        }
    }
}
