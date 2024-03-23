using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {

        private IWaterRepository _waterRepo;
        public HomeController(IWaterRepository temp)
        {
            _waterRepo = temp;
        }

        public IActionResult Index(int pageNum, string? projectType)
        {
            int pageSize = 2;

            var blah = new ProjectsListViewModel
            {
                Projects = _waterRepo.Projects
                .Where(x => x.ProjectType == projectType || projectType == null)
                .OrderBy(x => x.ProjectName)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = projectType == null ? _waterRepo.Projects.Count() : _waterRepo.Projects.Where(x => x.ProjectType == projectType).Count()

                },

                CurrentProjectType = projectType


            };

            

            

            return View(blah);
        }

    }
}
