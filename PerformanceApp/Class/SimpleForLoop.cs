//  -------------------------------------------------------------------------
//  <copyright file="SimpleForLoop.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Simple For Loop Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public static class SimpleForLoop
    {
        /// <summary>
        /// Responsible for Invoking SimpleForLoop
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_SimpleFor = new List<User>();
            var LocalUserList_SimpleFor = new List<User>();

            var SimpleForLoop_Limit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            for (int i = 1; i <= SimpleForLoop_Limit; i++)
            {
                LocalUserList_SimpleFor = IndependentTimeConsumingTask.DoThisTask();
                GlobalUserList_SimpleFor.AddRange(LocalUserList_SimpleFor);
            }

            return GlobalUserList_SimpleFor;
        }
    }
}
