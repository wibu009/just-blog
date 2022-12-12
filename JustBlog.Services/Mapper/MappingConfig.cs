using AutoMapper;
using JustBlog.Core.Entities;
using JustBlog.ViewModels.Category;
using JustBlog.ViewModels.Comment;
using JustBlog.ViewModels.Post;
using JustBlog.ViewModels.Role;
using JustBlog.ViewModels.Tag;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Services.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Core.Entities.Category, CategoryViewModel>();
            CreateMap<Core.Entities.Comment, CommentViewModel>();
            CreateMap<Core.Entities.Post, PostViewModel>().ForMember(pvm => pvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag)));
            CreateMap<Core.Entities.Post, PostAdminViewModel>();
            CreateMap<Core.Entities.Post, PostDetailsViewModel>().ForMember(pdvm => pdvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag)));
            CreateMap<Core.Entities.Tag, TagViewModel>();
            CreateMap<Core.Entities.Tag, TagToUpdateViewModel>();
            CreateMap<TagToUpdateViewModel, Core.Entities.Tag>();
            CreateMap<CategoryToCreateViewModel, Core.Entities.Category>();
            CreateMap<CategoryToUpdateViewModel, Core.Entities.Category>();
            CreateMap<Core.Entities.Category, CategoryToUpdateViewModel>();
            CreateMap<Core.Entities.Comment, CommentToUpdateViewModel>();
            CreateMap<CommentToUpdateViewModel, Core.Entities.Comment>();
            CreateMap<PostToUpdateViewModel, Core.Entities.Post>();
            CreateMap<Core.Entities.Post, PostToUpdateViewModel>().ForMember(p => p.TagIds, epvm => epvm.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.TagId)));
            CreateMap<Core.Entities.Category, CategoryDetailsViewModel>();
            CreateMap<Core.Entities.Comment, CommentDetailsViewModel>().ForMember(c => c.Post, cdvm => cdvm.MapFrom(c => c.Post.Title));
            CreateMap<Core.Entities.Tag, TagDetailsViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<UserViewModel, Core.Entities.User>();
            CreateMap<Core.Entities.User, UserViewModel>();
            CreateMap<NewUserViewModel, Core.Entities.User>();
            CreateMap<RoleToCreateViewModel, IdentityRole>();
            CreateMap<Core.Entities.User, UserDetailsViewModel>();
            CreateMap<UserDetailsViewModel, EditUserViewModel>().ForMember(euvm => euvm.RoleIds, m => m.MapFrom(udvm => udvm.Roles.Select(r => r.Id)));
            CreateMap<EditUserViewModel, Core.Entities.User>();
        }
    }
}
