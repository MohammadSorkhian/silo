using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using silo_project.Models;
using silo_project.ViewModel;

namespace silo_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISQLRepository sqlRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ISQLRepository sqlRepository, IHostingEnvironment hostingEnvironment)
        {
            this.sqlRepository = sqlRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        #region Silo

        public ViewResult ListOfSilos()
        {
            Silo_ViewModel siloViewModel = new Silo_ViewModel();
            siloViewModel.allSilos = sqlRepository.GetAllSilos();
            ViewBag.type = "read";
            return View("Silo_View", siloViewModel);
        }


        [HttpGet]
        public ViewResult AddSilo()
        {
            Silo_ViewModel SiloViewModel = new Silo_ViewModel();
            SiloViewModel.allSilos = sqlRepository.GetAllSilos();
            ViewBag.type = "create";
            //return View("AddSiloView", Silo_ViewModel);
            return View("Silo_View", SiloViewModel);
        }


        [HttpPost]
        public IActionResult AddSilo(Silo_ViewModel Silo_ViewModel)
        {
            var newSilo = sqlRepository.AddSilo(Silo_ViewModel.silo);
            return RedirectToAction("ListOfSilos");
        }


        [HttpPost]
        public IActionResult DeleteSilo(int id)
        {
            Silo siloToDelete = sqlRepository.FindSilo(id);
            if (siloToDelete != null)
            {
                sqlRepository.DeleteSilo(siloToDelete);
                return RedirectToAction("ListOfSilos");
            }
            return RedirectToAction("ListOfSilos");
        }


        [HttpGet]
        public ViewResult EditSilo(int id)
        {
            Silo_ViewModel SiloViewModel = new Silo_ViewModel();
            SiloViewModel.allSilos = sqlRepository.GetAllSilos();
            SiloViewModel.silo = sqlRepository.FindSilo(id);
            ViewBag.type = "update";
            return View("Silo_View", SiloViewModel);
        }


        [HttpPost]
        public IActionResult UpdateSilo(Silo_ViewModel siloViewModel)
        {
            if (siloViewModel != null)
            {
                sqlRepository.UpdateSilo(siloViewModel.silo);
            }
            return RedirectToAction("ListOfSilos");
        }
        #endregion




        [Route("/")]
        [Route("/Home")]
        [Route("/Index")]
        public ViewResult ListOfRecords()
        {
            Record_ViewModel recordViewModel = new Record_ViewModel();
            recordViewModel.allRecords = sqlRepository.GetAllRecords();
            return View("Record_view", recordViewModel);
        }





        //    private readonly ILogger<HomeController> _logger;

        //    public HomeController(ILogger<HomeController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    public IActionResult ListOfSilos()
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
