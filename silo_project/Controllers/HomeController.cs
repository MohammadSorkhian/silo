using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using silo_project.Models;
using silo_project.ViewModel;

namespace silo_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiloRepository sqlSiloRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ISiloRepository sqlSiloRepository, IHostingEnvironment hostingEnvironment)
        {
            this.sqlSiloRepository = sqlSiloRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("/")]
        [Route("/Home")]
        [Route("/Index")]
        public ViewResult Index()
        {
            var allSilos = sqlSiloRepository.GetAllSilos();
            return View(allSilos);
        }

        [HttpGet]
        public ViewResult AddSilo()
        {
            AddSiloViewModel addSiloViewModel = new AddSiloViewModel();
            addSiloViewModel.allSilos = sqlSiloRepository.GetAllSilos();
            addSiloViewModel.silo = new Silo();
            return View("AddSiloView", addSiloViewModel);
        }

        [HttpPost]
        public IActionResult AddSilo(AddSiloViewModel silo)
        {
            //Console.WriteLine("received");
            //sqlSiloRepository.AddSilo(silo);
            return RedirectToAction("Index");

        }


        

        //    private readonly ILogger<HomeController> _logger;

        //    public HomeController(ILogger<HomeController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    public IActionResult Privacy()
        //    {
        //        return View();
        //    }

        //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
    }
}
