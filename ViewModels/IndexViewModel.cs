using SoccerRead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerRead.ViewModels
{
    public class IndexViewModel
    {
        public int PageNumber { get; set; }
        public bool NextPage { get; set; }
        public string Category { get; set; }
        public string Search { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
