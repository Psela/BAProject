using DatabaseModel;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BA_Project.Models
{
    public class LoginModel
    {
        public user user;

        public LoginModel()
        {
            if (user == null)
            {
                user = new user();
            }          
        }

        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        //public bool loginValidated { get; set; }

        //public void setLogin(bool validation)
        //{
        //    loginValidated = validation;
        //}

        //public bool GetLoginValue()
        //{
        //    return loginValidated;
        //}

        public bool  CheckLogin(string _username, string _password)
        {
            try
            {
                //var result = new SignInStatus();
                using (var context = new BAProjectEntities())
                {
                    var existingUser = context.users.FirstOrDefault(x => x.username.Contains(_username));

                    if (existingUser.password.Equals(_password))
                    {

                        //setLogin(true);
                        //Assigns corresponding information for the logged in user
                        user = existingUser;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                //return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public SignInStatus CheckLogin(LoginModel model)
        {
            try
            {
                var result = new SignInStatus();
                using (var context = new BAProjectEntities())
                {
                    var existingUserName = context.users.FirstOrDefault(x => x.username.Equals(model.Login));
                    if (existingUserName == null)
                    {
                        result = SignInStatus.Failure;
                    }
                    else if (existingUserName.password != model.Password)
                    {
                        result = SignInStatus.Failure;
                    }
                    else if (existingUserName.password == model.Password)
                    {
                        result = SignInStatus.Success;
                        //setLogin(true);
                        //Assigns corresponding information for the logged in user
                        user.email = existingUserName.email;
                        user.username = existingUserName.username;
                        user.type_of_user = existingUserName.type_of_user;
                        user.users_id = existingUserName.users_id;
                    }
                    else
                    {
                        result = SignInStatus.Failure;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}