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

        [Route("/")]
        [Route("/Home")]
        [Route("/Index")]
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
            Silo silo = sqlRepository.FindSilo(id);
            if (silo != null)
            {
                sqlRepository.DeleteSilo(silo);
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




        [HttpGet]
        public ViewResult Record()
        {
            Record_ViewModel recordViewModel = new Record_ViewModel();
            //recordViewModel.allRecords = sqlRepository.GetAllRecords();
            recordViewModel.siloNames = sqlRepository.GetAllSilos().Select(s => s.Name);
            recordViewModel.siloName = "All";
            //recordViewModel.startDate = new DateTime(2020, 10, 10);
            //recordViewModel.siloName = recordViewModel.siloNames.FirstOrDefault();
            return View("Record_view", recordViewModel);
        }


        [HttpPost]
        public ViewResult Record(Record_ViewModel recordViewModel)
        {
            recordViewModel.siloNames = sqlRepository.GetAllSilos().Select(s => s.Name);
            recordViewModel.allRecords = sqlRepository.GetAllRecords();
            if (recordViewModel.siloName != null && recordViewModel.siloName != "All") recordViewModel.allRecords = recordViewModel.allRecords.Where(r => r.Silo.Name == recordViewModel.siloName);

            return View("Record_View", recordViewModel);
        }


        [HttpGet]
        public ViewResult AddRecord()
        {
            Record_ViewModel recordViewModel = new Record_ViewModel();
            recordViewModel.allRecords = sqlRepository.GetAllRecords();
            ViewBag.type = "create";
            return View("Record_view", recordViewModel);
        }



        [HttpPost]
        public IActionResult AddRecord(Record record)
        {
            sqlRepository.AddRecord(record);
            return RedirectToAction("Record");
        }


        public IActionResult DeleteRecord(int id)
        {
            Record record = sqlRepository.FindRecord(id);
            sqlRepository.DeleteRecord(record);
            return RedirectToAction("Record");
        }


        [HttpGet]
        public ViewResult UpdateRecord(int id)
        {
            Record_ViewModel recordViewModel = new Record_ViewModel();
            recordViewModel.allRecords = sqlRepository.GetAllRecords();
            recordViewModel.record = sqlRepository.FindRecord(id);
            recordViewModel.siloNames = sqlRepository.GetAllSilos().Select(s => s.Name);
            ViewBag.type = "update";
            return View("Record_view", recordViewModel);
            //var x = recordViewModel.allRecords.Select(r => new { r.Silo.ID, r.Silo.Name, });
        }


        [HttpPost]
        public IActionResult UpdateRecord(Record_ViewModel recordViewModel)
        {
            Record record = new Record();
            record = recordViewModel.record;
            record.Silo = sqlRepository.GetAllSilos().FirstOrDefault(s => s.Name == recordViewModel.record.Silo.Name);
            sqlRepository.UpdateRecord(record);

            return RedirectToAction("Record");
        }


        public ViewResult Filter()
        {
            return View("Silo_View");
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
