using DevForum.ViewModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicViewModel> Get(TopicSearchObject search);
        Task<TopicViewModel> GetById(int id);
        Task<TopicViewModel> Insert(TopicInsertModel model);
        Task<TopicViewModel> Update(int id, TopicUpdateModel model);
        Task Delete(int id);
    }
}
