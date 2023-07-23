﻿using ecinema_aspnet_mvc_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecinema_aspnet_mvc_app.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _context.Actors.ToListAsync();
            return View(data);
        }
    }
}
