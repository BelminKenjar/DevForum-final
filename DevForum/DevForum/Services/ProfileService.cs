using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Profile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class ProfileService : IProfileService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public ProfileService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task Delete(string applicationUserId)
        {
            var profile = _applicationDbContext.Set<Models.Profile>().FirstOrDefault(x => x.ApplicationUserId.Equals(applicationUserId));
            var stats = _applicationDbContext.Set<ProfileStats>().FirstOrDefault(x => x.ProfileId == profile.Id);
            var details = _applicationDbContext.Set<ProfileDetails>().FirstOrDefault(x => x.ProfileId == profile.Id);
            var user = _applicationDbContext.Set<ApplicationUser>().FirstOrDefault(x => x.Id == applicationUserId);
            if(details != null)
                _applicationDbContext.Remove(details);
            _applicationDbContext.Remove(stats);
            _applicationDbContext.Remove(profile);
            _applicationDbContext.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
        }

        public IEnumerable<ProfileViewModel> Get()
        {
            var res = _applicationDbContext.Set<Models.Profile>().AsQueryable();
            res = res.Include(x => x.ApplicationUser).Include(x => x.ProfileStats);
            return _mapper.Map<IEnumerable<ProfileViewModel>>(res);
        }

        public ProfileViewModel GetById(int id)
        {
            var res = _applicationDbContext.Set<Models.Profile>()
                     .Include(x => x.ApplicationUser)
                     .Include(x => x.ProfileDetails)
                     .Include(x => x.ProfileStats)
                     .Include(x => x.Posts).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ProfileViewModel>(res);
        }

        public ProfileViewModel GetCurrentProfile(string userId)
        {
            var res = _applicationDbContext.Set<Models.Profile>()
                      .Include(x => x.ApplicationUser)
                      .Include(x => x.ProfileDetails)
                      .Include(x => x.ProfileStats)
                      .Include(x => x.Posts).FirstOrDefault(x => x.ApplicationUserId == userId);
            return _mapper.Map<ProfileViewModel>(res);
        }

        public async Task<ProfileViewModel> Update(int id, ProfileUpdateModel model)
        {
            var entity = _applicationDbContext.Set<Models.Profile>().Find(id);
            _mapper.Map(model, entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<ProfileViewModel>(entity);
        }
    }
}
