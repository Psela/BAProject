using DatabaseModel;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace BA_Project.Models
{
  public class LoginModel
  {
    [Required]
    [Display(Name = "Login")]
    public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

    public bool CheckLogin(string _username, string _password)
    {
      try
      {
        //var result = new SignInStatus();
        using (var context = new BAProjectEntities())
        {
          var existingUser = context.users.FirstOrDefault(x => x.username.Contains(_username));
          if (existingUser != null)
          {
            if (existingUser.password.Equals(_password))
            {
              return true;
            }
          }

        }
      }
      catch (Exception ex)
      {
        if (ex is EntityException || ex is NullReferenceException)
        {
          MessageBox.Show("Couldn't connect to the database. Please try again later.");
        }
        else
        {
          throw;
        }
      }
      return false;
    }
  }
}