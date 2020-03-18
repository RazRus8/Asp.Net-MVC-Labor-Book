﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Models.SELECT
{
    public class ValidateUser
    {
        public static bool Validating(SigninUserModel user)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                foreach (SigninUserModel md in db.SigninUsers)
                {
                    if (user.Username == md.Username && user.Password == md.Password)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}