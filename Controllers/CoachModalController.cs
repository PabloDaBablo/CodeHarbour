﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMBA_7_2_.Data;
using WMBA_7_2_.Models;
using WMBA_7_2_.ViewModels;

namespace WMBA_7_2_.Controllers
{
	public class CoachModalController : Controller
	{

		private readonly WMBAContext _context;

		public CoachModalController(WMBAContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var teams = _context.Teams.ToList(); 
			ViewData["TeamCoaches"] = new SelectList(teams, "ID", "TeamName");
			return View();
		}


		[HttpGet]
		public JsonResult GetCoaches()
		{
			try
			{
				var coaches = _context.Coaches
					.Include(c => c.TeamCoach)
						.ThenInclude(tc => tc.Team)
					.Select(c => new
					{
						id = c.ID,
						CoachMemberID = c.CoachMemberID,
						CoachName = c.CoachName,
						CoachNumber = c.CoachNumber,
						CoachPosition = c.CoachPosition,
						Teams = c.TeamCoach.Select(tc => new { tc.TeamID, tc.Team.TeamName }).ToList()
					})
					.ToList();

				return Json(coaches);
			}
			catch (Exception ex)
			{
				return Json(new { error = "An error occurred while processing your request. Please try again later." });
			}
		}

		[HttpPost]
		public JsonResult Insert([FromBody] CoachViewModel viewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var coach = new Coach
					{
						ID = viewModel.ID,
						CoachMemberID = viewModel.CoachMemberID,
						CoachName = viewModel.CoachName,
						CoachNumber = viewModel.CoachNumber,
						CoachPosition = viewModel.CoachPosition,
					};

					if (viewModel.ID > 0)
					{
						var existingAssociations = _context.Team_Coaches.Where(tc => tc.CoachID == viewModel.ID);
						_context.Team_Coaches.RemoveRange(existingAssociations);
					}

					foreach (var teamId in viewModel.SelectedTeamIds)
					{
						coach.TeamCoach.Add(new Team_Coach { CoachID = coach.ID, TeamID = teamId });
					}

					if (viewModel.ID == 0)
					{
						_context.Coaches.Add(coach);
					}
					else
					{
						_context.Entry(coach).State = EntityState.Modified;
					}

					_context.SaveChanges();

					return Json("Coach saved successfully.");
				}

				return Json("Model validation failed.");
			}
			catch (Exception ex)
			{
				return Json(new { error = "An error occurred while processing your request. Please try again later." });
			}
		}


		[HttpGet]
		public JsonResult Edit(int? id)
		{
			try
			{
				var coaches = _context.Coaches
									 .Include(p => p.TeamCoach)
										.ThenInclude(tc => tc.Team)
									 .FirstOrDefault(p => p.ID == id);

				if (coaches == null)
				{
					return Json(new { error = "Coach not found." });
				}


				var teams = coaches.TeamCoach.Select(tc => new { tc.TeamID, tc.Team.TeamName }).ToList();

				var result = new
				{
					id = coaches.ID,
					coachMemberID = coaches.CoachMemberID,
					coachName = coaches.CoachName,
					coachNumber = coaches.CoachNumber,
					coachPosition = coaches.CoachPosition,
					teams = teams
				};

				return Json(result);
			}
			catch (Exception ex)
			{

				return Json(new { error = "An error occurred while processing your request." });
			}
		}

		[HttpPost]
		public async Task<JsonResult> Update([FromBody] CoachViewModel viewModel)
		{
			if (viewModel.ID <= 0)
			{
				return Json("Invalid coach ID.");
			}

			var coachToUpdate = await _context.Coaches
				.Include(c => c.TeamCoach)
				.FirstOrDefaultAsync(c => c.ID == viewModel.ID);

			if (coachToUpdate == null)
			{
				return Json("Coach not found.");
			}

			if (await TryUpdateModelAsync<Coach>(
					coachToUpdate,
					"",
					c => c.CoachMemberID, c => c.CoachName, c => c.CoachNumber, c => c.CoachPosition))
			{
				try
				{
					var existingTeamIds = coachToUpdate.TeamCoach.Select(tc => tc.TeamID).ToList();
					var newTeamIds = viewModel.SelectedTeamIds.Except(existingTeamIds).ToList();
					var removedTeamIds = existingTeamIds.Except(viewModel.SelectedTeamIds).ToList();

					foreach (var newTeamId in newTeamIds)
					{
						coachToUpdate.TeamCoach.Add(new Team_Coach { TeamID = newTeamId });
					}

					foreach (var removedTeamId in removedTeamIds)
					{
						var toRemove = coachToUpdate.TeamCoach.FirstOrDefault(tc => tc.TeamID == removedTeamId);
						if (toRemove != null)
						{
							coachToUpdate.TeamCoach.Remove(toRemove);
						}
					}

					await _context.SaveChangesAsync();
					return Json("Coach updated successfully.");
				}
				catch (DbUpdateException)
				{
					
					return Json("Unable to save changes. Try again, and if the problem persists, see your system administrator.");
				}
			}
			else
			{
				return Json("Model validation failed.");
			}
		}
		/*public JsonResult Delete(int id)
		{
			var coaches = _context.Coaches.Find(id);

			if (coaches != null)
			{
				_context.Coaches.Remove(coaches);
				_context.SaveChanges();
				return Json("Coach deleted successfully.");
			}
			return Json("Coach not found.");
		}

		*/ //bugged at the moment, not sure if teachers
		   // want a delete option for coaches since they dont want one for players



	}
}