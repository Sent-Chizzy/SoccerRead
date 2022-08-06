using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerRead.Models
{
    public class Post
    {
        public Post()
        {
            Created = DateTime.Now;
            Title = string.Empty;
            Body = string.Empty;
            Image = string.Empty;
            Description = string.Empty;
            Tags = string.Empty;
            Category = string.Empty;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; } 
        public string Image { get; set; } 
        public string Description { get; set; } 
        public string Tags { get; set; } 
        public string Category { get; set; } 
        public DateTime Created { get; set; }
    }
}
