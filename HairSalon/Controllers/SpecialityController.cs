using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialitiesController : Controller
  {

    [HttpGet("/Specialities")]
    public ActionResult Index()
    {
      List<Stylist> allSpecialities = Specialists.GetAll();
      return View(allStylists);
    }
  }
}
