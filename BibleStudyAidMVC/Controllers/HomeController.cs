using AutoMapper;
using BibleStudyAidBusinessLogic.ControllerLogic;
using BibleStudyAidMVC.Models;
using BibleStudyAidMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibleStudyAidMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DashboardLogic _dashboardLogic;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, DashboardLogic dashboardLogic, IMapper mapper)
        {
            _logger = logger;
            _dashboardLogic = dashboardLogic;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allDashboardItems=await _dashboardLogic.LoadDashboardItems();
            var viewModel = _mapper.Map<AllDashboardItemsViewModel>(allDashboardItems);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}