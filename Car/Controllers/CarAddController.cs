using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Car.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Car.Controllers
{
    public class CarAddController : Controller
    {
        CarShopContext _context = new CarShopContext();

        [HttpGet]
        public IActionResult CarAdd()
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
        public JsonResult GetModelId(int id)

        {
            List<Models1> list = new List<Models1>();
            list = _context.Models1.Where(a => a.BrandId == id).ToList();

            return Json(new SelectList(list, "Id", "ModelName"));
        }




        [HttpPost]
        public async Task<IActionResult> CarAdd(int? BrandId, AllAds adsModel, List<IFormFile> files)
        {


            if (ModelState.IsValid)
            {
                var car = new AllAds()
                {
                    BrandId = adsModel.BrandId,
                    ModelId = adsModel.ModelId,
                    BodyTypeId = adsModel.BodyTypeId,
                    Walk = adsModel.Walk,
                    ColorId = adsModel.ColorId,
                    Price = adsModel.Price,
                    CurrencyId = adsModel.CurrencyId,
                    Credit = adsModel.Credit,
                    Barter = adsModel.Barter,
                    FuelTypeId = adsModel.FuelTypeId,
                    TransmissionId = adsModel.TransmissionId,
                    GearboxId = adsModel.GearboxId,
                    FounderYear = adsModel.FounderYear,
                    EngineVolumeId = adsModel.EngineVolumeId,
                    Hp = adsModel.Hp,
                    Note = adsModel.Note,
                    AlloyWheels = adsModel.AlloyWheels,
                    CentralClosure = adsModel.CentralClosure,
                    LeatherSalon = adsModel.LeatherSalon,
                    SeatVentilation = adsModel.SeatVentilation,
                    Usa = adsModel.Usa,
                    ParkingRadar = adsModel.ParkingRadar,
                    Xenon = adsModel.Xenon,
                    Luke = adsModel.Luke,
                    Conditioner = adsModel.Conditioner,
                    RearCamera = adsModel.RearCamera,
                    RainSensor = adsModel.RainSensor,
                    SeatHeating = adsModel.SeatHeating,
                    SideCurtains = adsModel.SideCurtains,
                    Name = adsModel.Name,
                    CityId = adsModel.CityId,
                    Contact = adsModel.Contact

                };

                _context.AllAds.Add(car);
                _context.SaveChanges();

                int adsId = car.Id;

                foreach (var file in files)
                {
                    if (file != null && file.Length>3)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var filename = string.Format($"{Guid.NewGuid()}{extension}");
                        adsModel.ImgAds.Add(new ImgAds() { Image = filename, AdsId = adsId });
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }

                _context.ImgAds.AddRange(adsModel.ImgAds);
                _context.SaveChanges();

                return RedirectToAction("MainPage","Home");
            }
            return View(adsModel);
        
        }
        public IActionResult CardInfo(int id)
        {
            var model = _context.AllAds
                    .Include(i => i.Brand)
                    .Include(i => i.Model)
                    .Include(i => i.ImgAds)
                    .Where(i => i.Id == id)
                    .Include(i => i.EngineVolume)
                    .ThenInclude(i => i.AllAdsEngineVolume)
                    .Include(i => i.City)
                    .ThenInclude(i => i.AllAdsCity)
                    .Include(i => i.BodyType)
                    .ThenInclude(i => i.AllAdsBodyType)
                    .Include(i => i.Gearbox)
                    .ThenInclude(i => i.AllAdsGearbox)
                    .Include(i => i.Color)
                    .ThenInclude(i => i.AllAdsColor)
                    .Include(i => i.FuelType)
                    .ThenInclude(i => i.AllAdsFuelType)
                    .Include(i => i.Transmission)
                    .ThenInclude(i => i.AllAdsTransmission)
                    .Include(i => i.Currency)
                    .ThenInclude(i => i.AllAdsCurrency)
                    .FirstOrDefault();
            return View(model);

        }
       
       
    }
}
