using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Speciality
  {
    private string _name;
    private int _id;

    public Speciality(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM Specialities;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Speciality> GetAll()
    {
      List<Speciality> allSpeciality = new List<Speciality> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Specialities;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialityId = rdr.GetInt32(0);
        string SpecialityName = rdr.GetString(1);
        Speciality newSpeciality = new Speciality(SpecialityName, SpecialityId);
        allSpeciality.Add(newSpeciality);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpeciality;
    }

    public static Speciality Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Specialities WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int SpecialityId = 0;
      string SpecialityName = "";
      while(rdr.Read())
      {
        SpecialityId = rdr.GetInt32(0);
        SpecialityName = rdr.GetString(1);
      }
      Speciality newSpeciality = new Speciality(SpecialityName, SpecialityId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpeciality;
    }

    public List<Client> GetClients()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE Speciality_id = @Speciality_id;";
      MySqlParameter SpecialityId = new MySqlParameter();
      SpecialityId.ParameterName = "@Speciality_id";
      SpecialityId.Value = this._id;
      cmd.Parameters.Add(SpecialityId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientPhone = rdr.GetString(2);
        int clientSpecialityId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, clientPhone, clientSpecialityId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public override bool Equals(System.Object otherSpeciality)
    {
      if (!(otherSpeciality is Speciality))
      {
        return false;
      }
      else
      {
        Speciality newSpeciality = (Speciality) otherSpeciality;
        bool idEquality = this.GetId().Equals(newSpeciality.GetId());
        bool nameEquality = this.GetName().Equals(newSpeciality.GetName());
        return (idEquality && nameEquality);
      }
    }
    public override int GetHashCode()
    {
      string combinedHash = this.GetId() + this.GetName();
      return combinedHash.GetHashCode();
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO Specialities (name) VALUES (@name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialities
          JOIN specialists ON (specialities.id = specialists.speciality_id)
          JOIN stylists ON (specialists.stylist_id = stylists.id)
          WHERE specialities.id = @specialityId;";
      MySqlParameter specialityIdParameter = new MySqlParameter();
      specialityIdParameter.ParameterName = "@specialityId";
      specialityIdParameter.Value = _id;
      cmd.Parameters.Add(specialityIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
      int stylistId = rdr.GetInt32(0);
      string stylistTitle = rdr.GetString(1);

      Stylist newStylist = new Stylist(stylistTitle, stylistId);
      stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
      conn.Dispose();
      }
      return stylists;
    }
    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialities SET name = @newName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
