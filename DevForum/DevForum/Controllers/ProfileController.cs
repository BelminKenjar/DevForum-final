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
        private UserManager<ApplicationUser> _userManger;
        public ProfileController(IProfileService profileService, UserManager<ApplicationUser> userManager)
        {
            _profileService = profileService;
            _userManger = userManager;
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
        [HttpGet]
        public ProfileViewModel GetUserProfile()
        {
            var user = _userManger.GetUserAsync(User).Result;
            return _profileService.GetCurrentProfile(user.Id);
        }
    }
}
