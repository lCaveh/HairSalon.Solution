using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialitiesController : Controller
  {

    [HttpGet("/specialities")]
    public ActionResult Index()
    {
      List<Speciality> allSpecialities = Speciality.GetAll();
      return View(allSpecialities);
    }
    [HttpGet("/specialities/new")]
    public ActionResult New()
    {
      return View();
    }
     [HttpPost("/specialities")]
    public ActionResult Index(string specialityName)
    {
      Speciality speciality = new Speciality(specialityName);
      speciality.Save();
      List<Speciality> allSpecialities = Speciality.GetAll();
      return View(allSpecialities);
    }
    [HttpGet("/specialities/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string,object> model= new Dictionary<string,object>();
        Speciality speciality= Speciality.Find(id);
        List<Stylist> stylists= speciality.GetStylists();
        model.Add("speciality",speciality);
        model.Add("stylists",stylists);
        return View(model);
    }
  }
}
