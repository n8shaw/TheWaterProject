using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;

namespace TheWaterProject.Components
{
    public class ProjectTypeViewComponent : ViewComponent
    {
        private IWaterRepository _waterRepository;
        public ProjectTypeViewComponent(IWaterRepository temp) 
        {
            _waterRepository = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"];

            var projectTypes = _waterRepository.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes);
        }
    }
}
