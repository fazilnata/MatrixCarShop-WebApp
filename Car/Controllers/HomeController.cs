using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Car.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Car.Controllers
{
    public class HomeController : Controller
    {
       
            CarShopContext _context = new CarShopContext();

            public IActionResult MainPage()
            {
            CardGeneralModel model = new CardGeneralModel()
            {
                AllAdss = _context.AllAds
                      .Include(i => i.Brand).Include(i => i.Model).Include(i => i.ImgAds).Include(i => i.Currency).ThenInclude(i => i.AllAdsCurrency).Include(i => i.EngineVolume).ThenInclude(i => i.AllAdsEngineVolume)

                      .ToList()
            };
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Currency = _context.GeneralInfo.Where(x => x.TypeId == 3).ToList();
            ViewBag.City = _context.GeneralInfo.Where(x => x.TypeId == 7).ToList();
            try
            {  model.AllAdss = JsonConvert.DeserializeObject<List<AllAds>>(HttpContext.Session.GetString("Ads"));
            HttpContext.Session.Clear();
            return View(model);

            }
            catch (Exception)
            {

                return View(model);

            }



        }
        [HttpPost]
        public IActionResult MainPage(CardGeneralModel cmodel)
        {
            CardGeneralModel model = new CardGeneralModel();

            model.AllAdss = _context.AllAds.Include(i => i.ImgAds).Include(i => i.Brand).Include(i => i.Model).Include(i => i.EngineVolume).ThenInclude(i => i.AllAdsEngineVolume).ToList();

            if (cmodel.BrandId != null)
                model.AllAdss = model.AllAdss.Where(i => i.BrandId == cmodel.BrandId).ToList(); 
            if (cmodel.ModelId != null)
                model.AllAdss = model.AllAdss.Where(i => i.ModelId == cmodel.ModelId).ToList();
            if (cmodel.CurrencyId != null)
                model.AllAdss = model.AllAdss.Where(i => i.CurrencyId == cmodel.CurrencyId).ToList();
            if (cmodel.CityId != null)
                model.AllAdss = model.AllAdss.Where(i => i.CityId == cmodel.CityId).ToList();
            if (cmodel.minPrice != null)
                model.AllAdss = model.AllAdss.Where(i => i.Price >= cmodel.minPrice).ToList();
            if (cmodel.maxPrice != null)
                model.AllAdss = model.AllAdss.Where(i => i.Price <= cmodel.maxPrice).ToList();
            if (cmodel.minYear != null)
                model.AllAdss = model.AllAdss.Where(i => i.FounderYear >= cmodel.minYear).ToList();
            if (cmodel.maxYear != null)
                model.AllAdss = model.AllAdss.Where(i => i.FounderYear == cmodel.maxYear).ToList();
            if (cmodel.Credit)
                model.AllAdss = model.AllAdss.Where(i => i.Credit == true).ToList();
            if (cmodel.Barter)
                model.AllAdss = model.AllAdss.Where(i => i.Barter == true).ToList();
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Currency = _context.GeneralInfo.Where(x => x.TypeId == 3).ToList();
            ViewBag.City = _context.GeneralInfo.Where(x => x.TypeId == 7).ToList();

        

            return View(model);


        }

        public JsonResult GetModelId(int id)

            {
                List<Models1> list = new List<Models1>();
                list = _context.Models1.Where(a => a.BrandId == id).ToList();

                return Json(new SelectList(list, "Id", "ModelName"));
            }

        public IActionResult GeneralSearch()
        {
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.FuelType = _context.GeneralInfo.Where(x => x.TypeId == 4).ToList();
            ViewBag.Trans = _context.GeneralInfo.Where(x => x.TypeId == 5).ToList();
            ViewBag.BodyType = _context.GeneralInfo.Where(x => x.TypeId == 1).ToList();
            ViewBag.GearBox = _context.GeneralInfo.Where(x => x.TypeId == 6).ToList();
            ViewBag.EngineVolume = _context.GeneralInfo.Where(x => x.TypeId == 8).ToList();
            ViewBag.Color = _context.GeneralInfo.Where(x => x.TypeId == 2).ToList();
            ViewBag.Currency = _context.GeneralInfo.Where(x => x.TypeId == 3).ToList();
            ViewBag.City = _context.GeneralInfo.Where(x => x.TypeId == 7).ToList();
            List<int> Years = new List<int>();
            int currentYear = DateTime.Now.Year;
            for (int i = 1980; i <= currentYear; i++)
            {
                Years.Add(i);
            }
            ViewBag.Years = Years;
            return View();
        }

        [HttpPost]
        public IActionResult GeneralSearch(CardGeneralModel cmodel)
        {
            CardGeneralModel model = new CardGeneralModel();

            model.AllAdss = _context.AllAds.Include(i => i.ImgAds).Include(i => i.Brand).Include(i => i.Model).Include(i => i.EngineVolume).ThenInclude(i => i.AllAdsEngineVolume).ToList();

            if (cmodel.BrandId != null)
                model.AllAdss = model.AllAdss.Where(i => i.BrandId == cmodel.BrandId).ToList();
            if (cmodel.ModelId != null)
                model.AllAdss = model.AllAdss.Where(i => i.ModelId == cmodel.ModelId).ToList();
            if (cmodel.CurrencyId != null)
                model.AllAdss = model.AllAdss.Where(i => i.CurrencyId == cmodel.CurrencyId).ToList();
            if (cmodel.EngineVolumeId != null)
                model.AllAdss = model.AllAdss.Where(i => i.EngineVolumeId == cmodel.EngineVolumeId).ToList();
            if (cmodel.ColorId != null)
                model.AllAdss = model.AllAdss.Where(i => i.ColorId == cmodel.ColorId).ToList();
            if (cmodel.FuelTypeId != null)
                model.AllAdss = model.AllAdss.Where(i => i.FuelTypeId == cmodel.FuelTypeId).ToList();
            if (cmodel.Credit)
                model.AllAdss = model.AllAdss.Where(i => i.Credit == true).ToList();
            if (cmodel.Barter)
                model.AllAdss = model.AllAdss.Where(i => i.Barter == true).ToList();
            if (cmodel.BodyTypeId != null)
                model.AllAdss = model.AllAdss.Where(i => i.BodyTypeId == cmodel.BodyTypeId).ToList();
            if (cmodel.FuelTypeId != null)
                model.AllAdss = model.AllAdss.Where(i => i.CurrencyId == cmodel.FuelTypeId).ToList();
            if (cmodel.CityId != null)
                model.AllAdss = model.AllAdss.Where(i => i.CityId == cmodel.CityId).ToList();
            if (cmodel.minPrice != null)
                model.AllAdss = model.AllAdss.Where(i => i.Price >= cmodel.minPrice).ToList();
            if (cmodel.maxPrice != null)
                model.AllAdss = model.AllAdss.Where(i => i.Price <= cmodel.maxPrice).ToList();
            if (cmodel.minWalk != null)
                model.AllAdss = model.AllAdss.Where(i => i.Walk >= cmodel.minWalk).ToList();
            if (cmodel.maxWalk != null)
                model.AllAdss = model.AllAdss.Where(i => i.Walk <= cmodel.maxWalk).ToList();

            if (cmodel.VolumeId != null)
                model.AllAdss = model.AllAdss.Where(i => i.EngineVolumeId == cmodel.VolumeId).ToList();
            if (cmodel.maxYear != null)
                model.AllAdss = model.AllAdss.Where(i => i.FounderYear == cmodel.maxYear).ToList();
            if (cmodel.minYear != null)
                model.AllAdss = model.AllAdss.Where(i => i.FounderYear >= cmodel.minYear).ToList();
            if (cmodel.TransmissionId != null)
                model.AllAdss = model.AllAdss.Where(i => i.TransmissionId == cmodel.TransmissionId).ToList();
            if (cmodel.GearboxId != null)
                model.AllAdss = model.AllAdss.Where(i => i.GearboxId == cmodel.GearboxId).ToList();

            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.FuelType = _context.GeneralInfo.Where(x => x.TypeId == 4).ToList();
            ViewBag.Trans = _context.GeneralInfo.Where(x => x.TypeId == 5).ToList();
            ViewBag.BodyType = _context.GeneralInfo.Where(x => x.TypeId == 1).ToList();
            ViewBag.GearBox = _context.GeneralInfo.Where(x => x.TypeId == 6).ToList();
            ViewBag.EngineVolume = _context.GeneralInfo.Where(x => x.TypeId == 8).ToList();
            ViewBag.Color = _context.GeneralInfo.Where(x => x.TypeId == 2).ToList();
            ViewBag.Currency = _context.GeneralInfo.Where(x => x.TypeId == 3).ToList();
            ViewBag.City = _context.GeneralInfo.Where(x => x.TypeId == 7).ToList();
            List<AllAds> Ads = model.AllAdss;
            HttpContext.Session.SetString("Ads",JsonConvert.SerializeObject(Ads));
            return RedirectToAction("MainPage"); 



        }

    }
}
