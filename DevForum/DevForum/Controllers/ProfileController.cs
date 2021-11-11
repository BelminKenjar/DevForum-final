using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Profile;
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
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        //[Authorize(Roles = "Admin")]
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

        [HttpPost]
        public async Task<ProfileViewModel> Insert(ProfileInsertModel model)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.ApplicationUserId = id;
            return await _profileService.Insert(model);
        }

        [HttpPost("{id}")]
        public async Task<ProfileViewModel> Update(int id, ProfileUpdateModel model)
        {
            return await _profileService.Update(id, model);
        }
    }
}
