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
      List<Speciality> allSpecialities = Speciality.GetAll();
      return View(allSpecialities);
    }
    [HttpGet("/Specialities/new")]
    public ActionResult New()
    {
      return View();
    }
     [HttpPost("/Specialities")]
    public ActionResult Index(string specialityName)
    {
      Speciality speciality = new Speciality(specialityName);
      speciality.Save();
      List<Speciality> allSpecialities = Speciality.GetAll();
      return View(allSpecialities);
    }
  }
}
