using JustBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Repositories.Category;
using JustBlog.Repositories.Comment;
using JustBlog.Repositories.Post;
using JustBlog.Repositories.Role;
using JustBlog.Repositories.Tag;
using JustBlog.Repositories.User;

namespace JustBlog.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IPostRepository PostRepository { get; }
        public ITagRepository TagRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        void Save();
    }
}
