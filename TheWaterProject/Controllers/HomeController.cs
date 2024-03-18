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

        public IActionResult Index(int pageNum)
        {
            int pageSize = 2;

            var blah = new ProjectsListViewModel
            {
                Projects = _waterRepo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _waterRepo.Projects.Count()

                }
            };

            

            

            return View(blah);
        }

    }
}
