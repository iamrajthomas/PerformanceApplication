//  -------------------------------------------------------------------------
//  <copyright file="IndependentTimeConsumingTask.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Independent Time Consuming Task Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public static class IndependentTimeConsumingTask 
    {
        /// <summary>
        /// Time Consuming Task
        /// </summary>
        public static List<User> DoThisTask()
        {
            var TenLakhs_Limit = ConfigurationManager.AppSettings.Get("TenLakhs_Limit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("TenLakhs_Limit")) : 1000000;
            var UserList = new List<User>();
            for (var i = 1; i <= TenLakhs_Limit; i++)
            {
                UserList.Add(new User()
                {
                    ID = Guid.NewGuid(),
                    FirstName = "James_" + i,
                    LastName = "Herbert_" + i,
                    Age = new Random().Next(1, 100),
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    PhoneNumber = i.ToString(),
                    EmailID = "abc@abc.com",
                    Address = "Baker Street, London, UK"
                });
            }
            return UserList;
        }
    }
}
