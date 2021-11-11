using AutoMapper;
using DevForum.Data;
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

        public async Task<ProfileViewModel> Insert(ProfileInsertModel model)
        {
            var entity = _mapper.Map<Models.Profile>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<ProfileViewModel>(entity);
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
