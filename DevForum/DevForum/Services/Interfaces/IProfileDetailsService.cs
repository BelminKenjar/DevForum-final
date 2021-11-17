using DevForum.ViewModels.ProfileDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface IProfileDetailsService
    {
        Task<ProfileDetailsViewModel> Update(int profileDetailsId, ProfileDetailsUpdateModel model);
        Task<ProfileDetailsViewModel> Insert(ProfileDetailsInsertModel model);
    }
}
