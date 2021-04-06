//  -------------------------------------------------------------------------
//  <copyright file="ParallelForEachWithLock.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Parallel ForEach With Lock Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ParallelForEachWithLock
    {
        /// <summary>
        /// Responsible for Invoking ParallelForEachWithLock
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_ParallelForEachWithLock = new List<User>();
            var LocalUserList_ParallelForEachWithLock = new List<User>();

            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            List<int> SimpleForEachLoopWithLock_Limit = Enumerable.Range(1, LoopLimit).ToList();
            object _lockObj = new object();

            Parallel.ForEach(SimpleForEachLoopWithLock_Limit, i =>
            {
                lock (_lockObj)
                {
                    LocalUserList_ParallelForEachWithLock = IndependentTimeConsumingTask.DoThisTask();
                    GlobalUserList_ParallelForEachWithLock.AddRange(LocalUserList_ParallelForEachWithLock);
                }
            });

            return GlobalUserList_ParallelForEachWithLock;
        }
    }
}
