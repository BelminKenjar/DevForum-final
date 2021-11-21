using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Topic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class TopicService : ITopicService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public TopicService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public IEnumerable<TopicViewModel> Get(TopicSearchObject search = null)
        {
            var query = _applicationDbContext.Set<Topic>().AsQueryable();
            if(!String.IsNullOrEmpty(search?.Title))
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            var res = query.ToList();
            return _mapper.Map<IEnumerable<TopicViewModel>>(res);
        }

        public async Task<TopicViewModel> GetById(int id)
        {
            var res = await _applicationDbContext.Set<Topic>()
                      .Include(x => x.SubTopics).ThenInclude(x => x.Posts)
                      .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TopicViewModel>(res);
        }

        public async Task<TopicViewModel> Insert(TopicInsertModel model)
        {
            var entity = _mapper.Map<Topic>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<TopicViewModel>(entity);
        }

        public async Task<TopicViewModel> Update(int id, TopicUpdateModel model)
        {
            var entity = _applicationDbContext.Set<Topic>().Find(id);
            _mapper.Map(model, entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<TopicViewModel>(entity);
        }
        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<Topic>().Find(id);
            //update
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
