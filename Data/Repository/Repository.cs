using Microsoft.EntityFrameworkCore;
using SoccerRead.Interfaces;
using SoccerRead.Models;
using SoccerRead.Models.Comments;
using SoccerRead.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerRead.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return _context.Posts.ToList();
        }

        public IndexViewModel GetAllPost(int pageNumber, string category)
        {
            Func<Post, bool> InCategory = (Post) =>
            {
                return Post.Category.ToLower().Equals(category.ToLower());

            };

            int pageSIze = 5;
            int skipAmount = pageSIze * (pageNumber - 1);

            var query = _context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(x => InCategory(x));

            int postscount = query.Count();

            return new IndexViewModel
            {
                PageNumber = pageNumber,
                NextPage = postscount > skipAmount + pageNumber,
                Category = category,
                Posts = query
                         .Skip(skipAmount)
                         .Take(pageSIze)
                         .ToList()
            };
        }

        public Post GetPost(int id)
        {
            return _context.Posts.Include(p=>p.MainComments).
                ThenInclude(m=>m.SubComments)
                .FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public void RemovePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public void AddSubComment(SubComment comment)
        {
            _context.SubComments.Add(comment);
        }
    }
}
