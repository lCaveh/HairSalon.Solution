using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      List<Speciality> allSpecialities = Speciality.GetAll();
      return View(allSpecialities);
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName, List<int> stylistSpecialities)
    {
      Stylist stylist = new Stylist(stylistName);
      stylist.Save();
      foreach (var specialityId in stylistSpecialities)
      {
        stylist.AddSpeciality(specialityId);
      }

      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      List<Speciality> stylistSpecialities = selectedStylist.GetSpecialities();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      model.Add("specialities", stylistSpecialities);
      return View(model);
    }

    [HttpGet("/stylists/{id}/delete")]
     public ActionResult Delete(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(id);
      List<Client> stylistClients = stylist.GetClients();

      foreach(Client client in stylistClients)
      {
        Client.DeleteClients(client.GetId());
      }

      Stylist.DeleteStylist(id);

      model.Add("stylist", stylist);
      model.Add("clients", stylistClients);
      return View("Delete", model);

    }


    //This one creates new Clients within a given Stylist, not new Stylists:
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(string clientName, string clientPhone, int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, clientPhone, stylistId);
      newClient.Save();
      List<Client> stylistClients = foundStylist.GetClients();
      model.Add("clients", stylistClients);
      model.Add("stylist", foundStylist);
      return View("Show", model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/delete")]
     public ActionResult Delete(int stylistId, int clientId)
     {
       Client client = Client.Find(clientId);
       Client.DeleteClients(client.GetId());
       Dictionary<string, object> model = new Dictionary<string, object>();
       Stylist stylist = Stylist.Find(stylistId);
       List<Client> stylistClients = stylist.GetClients();
       model.Add("stylist", stylist);
       model.Add("clients", stylistClients);
       return View("Show", model);

     }



  }
}
