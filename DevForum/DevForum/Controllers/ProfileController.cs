using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;
        private IHttpContextAccessor _httpContextAccessor;
        public ProfileController(IProfileService profileService, IHttpContextAccessor httpContextAccessor)
        {
            _profileService = profileService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<ProfileViewModel> Get()
        {
            return _profileService.Get();
        }

        [HttpGet("{id}")]
        public ProfileViewModel GetById(int id)
        {
            return _profileService.GetById(id);
        }

        [HttpPost("{id}")]
        public async Task<ProfileViewModel> Update(int id, ProfileUpdateModel model)
        {
            return await _profileService.Update(id, model);
        }

        [Authorize]
        [HttpGet("current")]
        public ProfileViewModel GetUserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _profileService.GetCurrentProfile(userId);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _profileService.Delete(id);
        }
    }
}
