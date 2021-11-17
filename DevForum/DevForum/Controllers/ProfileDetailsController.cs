using DevForum.Services.Interfaces;
using DevForum.ViewModels.ProfileDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileDetailsController : ControllerBase
    {
        private IProfileDetailsService _profileDetailsService;

        public ProfileDetailsController(IProfileDetailsService profileDetailsService)
        {
            _profileDetailsService = profileDetailsService;
        }

        [HttpPost]
        public Task<ProfileDetailsViewModel> Insert(ProfileDetailsInsertModel model)
        {
            return _profileDetailsService.Insert(model);
        }

        [HttpPost("{id}")]
        public Task<ProfileDetailsViewModel> Update(int id, ProfileDetailsUpdateModel model)
        {
            return _profileDetailsService.Update(id, model);
        }
    }
}
