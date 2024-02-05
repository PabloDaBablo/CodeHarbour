﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WMBA_7_2_.Data;
using WMBA_7_2_.Models;

namespace WMBA_7_2_.Controllers
{
    public class PlayerModalController : Controller
    {

        private readonly WMBAContext _context;

        public PlayerModalController(WMBAContext context)
        {
            _context = context;
        }   

        public IActionResult Index()
        {

			ViewData["DivisionID"] = new SelectList(_context.Divisions, "ID", "DivisionTeams");
			ViewData["TeamID"] = new SelectList(_context.Teams, "ID", "TeamName");
			return View();
        }

		[HttpGet]
public JsonResult GetPlayers(int page = 1, int pageSize = 10, string sortColumn = "divAge", string sortDirection = "asc")
{
    var query = _context.Players
        .Include(p => p.Team)
        .Include(p => p.Division)
        .AsQueryable();

    // Apply sorting
    if (sortColumn == "teamName")
    {
        query = sortDirection == "asc" ? query.OrderBy(p => p.Team.TeamName) : query.OrderByDescending(p => p.Team.TeamName);
    }
    else if (sortColumn == "divAge")
    {
        query = sortDirection == "asc" ? query.OrderBy(p => p.Division.DivAge) : query.OrderByDescending(p => p.Division.DivAge);
    }

    var totalRecords = query.Count();
    var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

    var players = query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(p => new
        {
            id = p.ID,
            p.PlayerMemberID,
            p.PlayerFirstName,
            p.PlayerLastName,
            p.PlayerNumber,
            TeamName = p.Team.TeamName,
            p.DivisionID,
            DivAge = p.Division.DivAge,
            p.IsActive
        })
        .ToList();

    return Json(new { players, totalPages });
}

		[HttpPost]
        public JsonResult Insert(Player model)
        {
            if (ModelState.IsValid)
            {
                _context.Players
                    .Add(model);
                _context.SaveChanges();


				return Json("Player saved successfully.");
            }
            return Json("Model validation failed.");
        }

		[HttpGet]
		public JsonResult Edit(int? id)
		{
			var player = _context.Players
								 .Include(p => p.Team)
                                 .Include(p => p.Division)
								 .FirstOrDefault(p => p.ID == id);

			if (player == null)
			{
				return Json(new { error = "Player not found." });
			}

			var result = new
			{
				id = player.ID,
				playerMemberID = player.PlayerMemberID,
				playerFirstName = player.PlayerFirstName,
				playerLastName = player.PlayerLastName,
				playerNumber = player.PlayerNumber,
				teamID = player.Team?.ID,
                divisionID = player.Division?.ID,
                divAge = player.Division?.DivAge
			};

			return Json(result);
		}

		[HttpPost]
		public JsonResult Update(Player model)
		{
            if (ModelState.IsValid)
            {
                _context.Players.Update(model);
                _context.SaveChanges();

                return Json("Player updated successfully."); 
            }
            return Json("Model validation failed.");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var player = _context.Players.Find(id);

            if(player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
                return Json("Player deleted successfully.");
			}
            return Json("Player not found.");
        }

		public class PlayerStatusUpdateModel
		{
			public int Id { get; set; }
		}

		[HttpPost]
		public IActionResult ToggleStatus([FromBody] PlayerStatusUpdateModel model)
		{
			var player = _context.Players.FirstOrDefault(p => p.ID == model.Id);
			if (player != null)
			{
				player.IsActive = !player.IsActive;
				_context.SaveChanges();
				return Json(new { success = true, isActive = player.IsActive });
			}
			return Json(new { success = false });
		}
	}
}
