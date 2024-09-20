using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.Data;
using Task_5.Models;

namespace Task_5.Controllers
{
    public class Task_5Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Task_5Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dropdown
        public async Task<IActionResult> Index()
        {
            // Seed data if not already present
            if (!_context.Dropdowns.Any())
            {
                var skills = new List<Dropdown>
                {
                    new Dropdown { Id = 1, Skill = "C#" },
                    new Dropdown { Id = 2, Skill = "Java" },
                    new Dropdown { Id = 3, Skill = "Python" },
                    new Dropdown { Id = 4, Skill = "JavaScript" },
                    new Dropdown { Id = 5, Skill = "SQL" },
                    new Dropdown { Id = 6, Skill = "LINQ" },
                    new Dropdown { Id = 7, Skill = "Entity Framework" },
                    new Dropdown { Id = 8, Skill = "Web API" },
                    new Dropdown { Id = 9, Skill = "DocuSign" },
                    new Dropdown { Id = 10, Skill = "HTML5" }
                };

                _context.Dropdowns.AddRange(skills);
                await _context.SaveChangesAsync();
            }

            // Retrieve data for dropdown
            ViewBag.mySkills = _context.Dropdowns.Select(d => new SelectListItem
            {
                Text = d.Skill,
                Value = d.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Dropdown
        [HttpPost]
        public IActionResult Index(int[] selectedSkills)
        {
            // Check if any skills were selected
            if (selectedSkills != null && selectedSkills.Length > 0)
            {
                // Join selected skill IDs into a comma-separated string
                string commaSeparatedIds = string.Join(",", selectedSkills);

                // For demonstration purposes, you can return the comma-separated IDs as a message
                ViewBag.Message = $"Selected Skill IDs: {commaSeparatedIds}";
            }
            else
            {
                ViewBag.Message = "No skills were selected.";
            }

            // Reload the dropdown list for the view
            ViewBag.mySkills = _context.Dropdowns.Select(d => new SelectListItem
            {
                Text = d.Skill,
                Value = d.Id.ToString()
            }).ToList();

            return View();
        }
    }
}
