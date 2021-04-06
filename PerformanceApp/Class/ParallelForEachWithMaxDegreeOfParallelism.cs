//  -------------------------------------------------------------------------
//  <copyright file="ParallelForEachWithMaxDegreeOfParallelism.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Parallel ForEach With Max Degree Of Parallelism Class
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp.Class
{
    using PerformanceApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public static class ParallelForEachWithMaxDegreeOfParallelism
    {
        /// <summary>
        /// Responsible for Invoking ParallelForEachWithMaxDegreeOfParallelism
        /// </summary>
        public static List<User> Invoke()
        {
            var GlobalUserList_ParallelForEach_WMDP = new List<User>();
            var LocalUserList_ParallelForEach_WMDP = new List<User>();

            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            List<int> SimpleForEachLoop_Limit = Enumerable.Range(1, LoopLimit).ToList();
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };

            Parallel.ForEach(SimpleForEachLoop_Limit, options, i =>
            {
                Console.WriteLine(@"value of i = {0}, thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
                //Console.WriteLine("Executing ParallelForLoopEach Invoke Started Iteration: " + i);
                LocalUserList_ParallelForEach_WMDP = IndependentTimeConsumingTask.DoThisTask();
                GlobalUserList_ParallelForEach_WMDP.AddRange(LocalUserList_ParallelForEach_WMDP);
                //Console.WriteLine("Executing ParallelForLoopEach Invoke Ended Iteration: " + i);
            });

            return GlobalUserList_ParallelForEach_WMDP;
        }
    }
}
