using Microsoft.AspNetCore.Mvc;
using SoccerRead.Data.FileManager;
using SoccerRead.Interfaces;
using SoccerRead.Models;
using SoccerRead.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerRead.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository _repo;
        private readonly IFileManager _fileManager;

        public PostController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _repo.GetAllPost();
            return View(posts);
        }
        public IActionResult Detail(int id)
        {
            return View(_repo.GetPost(id));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return View(new PostViewModel());
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    CurrentImage = post.Image,
                    Description = post.Description,
                    Category = post.Category,
                    Tags = post.Tags
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Description = vm.Description,
                Category = vm.Category,
                Tags = vm.Tags
            };
            if (vm.Image == null)
            {
                post.Image = vm.CurrentImage;
            }
            else
            {
                post.Image = await _fileManager.SaveImage(vm.Image);
            }

            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
            {
                _repo.AddPost(post);
            }
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
            {
                return View(post);
            }
        }
    }
}
