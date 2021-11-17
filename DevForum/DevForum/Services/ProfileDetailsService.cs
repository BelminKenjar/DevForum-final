using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.ProfileDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class ProfileDetailsService : IProfileDetailsService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public ProfileDetailsService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<ProfileDetailsViewModel> Insert(ProfileDetailsInsertModel model)
        {
            var entity = _mapper.Map<ProfileDetails>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<ProfileDetailsViewModel>(entity);
        }

        public async Task<ProfileDetailsViewModel> Update(int profileDetailsId, ProfileDetailsUpdateModel model)
        {
            var entity = _applicationDbContext.Set<ProfileDetails>().Find(profileDetailsId);
            _mapper.Map(model, entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<ProfileDetailsViewModel>(entity);
        }
    }
}
