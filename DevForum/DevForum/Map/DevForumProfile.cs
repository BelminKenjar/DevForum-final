using DevForum.Models;
using DevForum.ViewModels.News;
using DevForum.ViewModels.PostLike;
using DevForum.ViewModels.PostReplyLike;
using DevForum.ViewModels.Posts;
using DevForum.ViewModels.Profile;
using DevForum.ViewModels.ProfileDetails;
using DevForum.ViewModels.ProfileStats;
using DevForum.ViewModels.Reply;
using DevForum.ViewModels.Subtopic;
using DevForum.ViewModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Map
{
    public class DevForumProfile : AutoMapper.Profile
    {
        public DevForumProfile()
        {
            //news
            CreateMap<News, NewsViewModel>();
            CreateMap<NewsInsertModel, News>();
            CreateMap<NewsUpdateModel, News>();

            //profile
            CreateMap<Profile, ProfileViewModel>();
            CreateMap<ProfileInsertModel, Profile>();
            CreateMap<ProfileUpdateModel, Profile>();

            //profile details
            CreateMap<ProfileDetails, ProfileDetailsViewModel>();
            CreateMap<ProfileDetailsInsertModel, ProfileDetails>();
            CreateMap<ProfileDetailsUpdateModel, ProfileDetails>();

            //profile stats
            CreateMap<ProfileStats, ProfileStatsViewModel>();

            //topic
            CreateMap<Topic, TopicViewModel>();
            CreateMap<TopicInsertModel, Topic>();
            CreateMap<TopicUpdateModel, Topic>();

            //subtopic
            CreateMap<SubTopic, SubtopicViewModel>();
            CreateMap<SubtopicInsertModel, SubTopic>();
            CreateMap<SubtopicUpdateModel, SubTopic>();

            //post
            CreateMap<Post, PostViewModel>();
            CreateMap<PostInsertModel, Post>();
            CreateMap<PostUpdateModel, Post>();

            //postreply
            CreateMap<PostReply, PostReplyViewModel>();
            CreateMap<PostReplyInsertModel, PostReply>();
            CreateMap<PostReplyUpdateModel, PostReply>();

            //postlike
            CreateMap<PostLike, PostLikeViewModel>();
            CreateMap<PostLikeInsertModel, PostLike>();
            CreateMap<PostLikeUpdateModel, PostLike>();

            //postreplylike
            CreateMap<PostReplyLike, PostReplyLikeViewModel>();
            CreateMap<PostReplyLikeInsertModel, PostReplyLike>();
        }
    }
}
