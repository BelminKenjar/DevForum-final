using AutoMapper;
using DevForum.Data;
using DevForum.Models;
using DevForum.Services.Interfaces;
using DevForum.ViewModels.Subtopic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services
{
    public class SubtopicService : ISubtopicService
    {
        private ApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public SubtopicService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var entity = _applicationDbContext.Set<SubTopic>().Find(id);
            _applicationDbContext.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public IEnumerable<SubtopicViewModel> Get(int topicId, SubtopicSearchObject model = null)
        {
            var query = _applicationDbContext.Set<SubTopic>().AsQueryable();
            if (!String.IsNullOrEmpty(model?.Title))
                query = query.Where(x => x.Name.ToLower().Contains(model.Title.ToLower()));
            query = query.Where(x => x.TopicId == topicId);
            var res = query.ToList();
            return _mapper.Map<IEnumerable<SubtopicViewModel>>(res);
        }

        public async Task<SubtopicViewModel> GetById(int id)
        {
            var entity = await _applicationDbContext.Set<SubTopic>()
                               .Include(x => x.Topic)
                               .Include(x => x.Posts)
                               .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SubtopicViewModel>(entity);
        }

        public async Task<SubtopicViewModel> Insert(SubtopicInsertModel model)
        {
            var entity = _mapper.Map<SubTopic>(model);
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<SubtopicViewModel>(entity);
        }

        public async Task<SubtopicViewModel> Update(int id, SubtopicUpdateModel model)
        {
            var entity = _applicationDbContext.Set<SubTopic>().Find(id);
            _mapper.Map(model, entity);
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<SubtopicViewModel>(entity);
        }
    }
}
