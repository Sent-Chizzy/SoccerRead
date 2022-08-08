using SoccerRead.Models;
using SoccerRead.Models.Comments;
using SoccerRead.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerRead.Interfaces
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        IndexViewModel GetAllPost(int pageNumber, string category);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();

        void AddSubComment(SubComment comment);
    }
}
