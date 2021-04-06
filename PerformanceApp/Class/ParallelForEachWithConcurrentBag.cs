//  -------------------------------------------------------------------------
//  <copyright file="ParallelForEachWithConcurrentBag.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Parallel ForEach With ConcurrentBag Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;
    public static class ParallelForEachWithConcurrentBag
    {
        /// <summary>
        /// Responsible for Invoking ParallelForEachWithConcurrentBag
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_ParallelForEach_WCB = new ConcurrentBag<User>();
            var LocalUserList_ParallelForEach_WCB = new List<User>();

            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            List<int> SimpleForEachLoop_Limit = Enumerable.Range(1, LoopLimit).ToList();

            Parallel.ForEach(SimpleForEachLoop_Limit, i =>
            {
                //Console.WriteLine("Executing ParallelForLoopEach Invoke Started Iteration: " + i);

                LocalUserList_ParallelForEach_WCB = IndependentTimeConsumingTask.DoThisTask();

                Parallel.ForEach(LocalUserList_ParallelForEach_WCB, j =>
                {
                    GlobalUserList_ParallelForEach_WCB.Add(j);
                });

                //Console.WriteLine("Executing ParallelForLoopEach Invoke Ended Iteration: " + i);
            });

            return GlobalUserList_ParallelForEach_WCB.ToList();
        }
    }
}
