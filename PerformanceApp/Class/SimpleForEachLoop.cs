//  -------------------------------------------------------------------------
//  <copyright file="SimpleForEachLoop.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Simple ForEach Loop Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    public static class SimpleForEachLoop
    {
        /// <summary>
        /// Responsible for Invoking SimpleForEachLoop
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_SimpleForEach = new List<User>();
            var LocalUserList_SimpleForEach = new List<User>();

            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            List<int> SimpleForEachLoop_Limit = Enumerable.Range(1, LoopLimit).ToList();
            foreach (int i in SimpleForEachLoop_Limit)
            {
                LocalUserList_SimpleForEach = IndependentTimeConsumingTask.DoThisTask();
                GlobalUserList_SimpleForEach.AddRange(LocalUserList_SimpleForEach);
            };
            return GlobalUserList_SimpleForEach;
        }

    }
}
