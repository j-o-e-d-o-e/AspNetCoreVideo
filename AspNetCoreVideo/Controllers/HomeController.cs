﻿using System;
using System.Linq;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.Services;
using AspNetCoreVideo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVideo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video => new VideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Genre = video.Genre.ToString()
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);
            if (model == null)
                return RedirectToAction("Index");
            return View(new VideoViewModel()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Genre = Enum.GetName(typeof(Genres), model.Genre.ToString())
                }
            );
        }
    }
}