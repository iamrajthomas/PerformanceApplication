//  -------------------------------------------------------------------------
//  <copyright file="User.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       User Model
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Model
{
    using System;

    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
    }
}
