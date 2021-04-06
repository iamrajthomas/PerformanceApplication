//  -------------------------------------------------------------------------
//  <copyright file="ParallelForEach.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Parallel For Each Class
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

    public static class ParallelForEach
    {
        /// <summary>
        /// Responsible for Invoking ParallelForEach
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_ParallelForEach = new List<User>();
            var LocalUserList_ParallelForEach = new List<User>();

            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            List<int> SimpleForEachLoop_Limit = Enumerable.Range(1, LoopLimit).ToList();

            Parallel.ForEach(SimpleForEachLoop_Limit, i =>
            {
                //Console.WriteLine("Executing ParallelForLoopEach Invoke Started Iteration: " + i);
                LocalUserList_ParallelForEach = IndependentTimeConsumingTask.DoThisTask();
                GlobalUserList_ParallelForEach.AddRange(LocalUserList_ParallelForEach);
                //Console.WriteLine("Executing ParallelForLoopEach Invoke Ended Iteration: " + i);
            });

            return GlobalUserList_ParallelForEach;
        }
    }
}
