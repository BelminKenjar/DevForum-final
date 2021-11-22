using DevForum.ViewModels.Subtopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface ISubtopicService
    {
        IEnumerable<SubtopicViewModel> Get(int topicId, SubtopicSearchObject model = null);
        Task<SubtopicViewModel> GetById(int id);
        Task<SubtopicViewModel> Insert(SubtopicInsertModel model);
        Task<SubtopicViewModel> Update(int id, SubtopicUpdateModel model);
        Task Delete(int id);
    }
}
