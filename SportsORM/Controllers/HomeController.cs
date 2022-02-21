using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }


        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.AllWomenLeague = _context.Leagues
            .Where(w => w.Name.Contains("Women")).ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(a => a.Sport.Contains("Hockey"))
                .ToList();
             ViewBag.NoFootball = _context.Leagues
                .Where(no => !no.Sport.Contains("Football"))
                .ToList();
             ViewBag.Conference = _context.Leagues
                .Where(b => b.Name.Contains("Conference"))
                .ToList();
            ViewBag.AtlanticRegion = _context.Leagues
                .Where(e => e.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(d => d.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(r => r.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(c => c.Location.Contains("City"))
                .ToList();
            ViewBag.StartT = _context.Teams
                .Where(t => t.TeamName.Contains("T"))
                .ToList();
            ViewBag.LocationOrder = _context.Teams
                .OrderBy( alp => alp.Location)
                .ToList();
            ViewBag.ReverseOrder = _context.Teams
                .OrderByDescending(alp => alp.TeamName)
                .ToList();
            ViewBag.Cooper = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .ToList();
             ViewBag.Joshua = _context.Players
                .Where(f => f.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.NoJosh = _context.Players
                .Where(j => j.LastName.Contains("Cooper") &&
                 !j.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.First = _context.Players
                .Where(p => p.FirstName.Contains("Alexander") &&
                p.FirstName.Contains("Wyatt"))
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}