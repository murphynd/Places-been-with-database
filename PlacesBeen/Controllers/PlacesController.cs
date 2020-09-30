using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PlacesBeen.Models;

namespace PlacesBeen.Controllers
{
    public class PlacesController : Controller
    {

      [HttpGet("/places")]
      public ActionResult Index()
      {
        List<Place> allPlaces = Place.GetAll();
        return View();
      }
      [HttpGet("/places/new")]
      public ActionResult New()
      {
        return View();
      }
      [HttpPost("/places")]
    public ActionResult Create()
    {
      Place myPlace = new Place();
      return RedirectToAction("Index");
    }
    }
}