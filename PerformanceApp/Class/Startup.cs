//  -------------------------------------------------------------------------
//  <copyright file="Startup.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Startup Class for Perf Application
//  </summary>
//  -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PerformanceApp.Class
{
    public static class Startup
    {
        /// <summary>
        /// Responsible for Initialziation of Perf Application
        /// </summary>
        public static void Init()
        {
            Dictionary<string, long> ElapsedTimeData = new Dictionary<string, long>();
            var LoopLimit = ConfigurationManager.AppSettings.Get("LoopLimit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoopLimit")) : 5;
            var TenLakhs_Limit = ConfigurationManager.AppSettings.Get("TenLakhs_Limit") != null ? Convert.ToInt32(ConfigurationManager.AppSettings.Get("TenLakhs_Limit")) : 1000000;
            var TotalLimit = LoopLimit * TenLakhs_Limit;

            #region Code For Simple For Loop 
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            var stopwatch_SimpleForLoop = new Stopwatch();
            stopwatch_SimpleForLoop.Start();

            DateTime StartDateTime_ForLoop = DateTime.Now;
            Console.WriteLine("Execution Started For SimpleForLoop Creating {0} Users: {1}", TotalLimit, StartDateTime_ForLoop);

            //Invoke the SimpleForLoop Here
            var TotalCreatedUser_ByForLoop = SimpleForLoop.Invoke();
            Console.WriteLine("Count of UserList Added by SimpleForLoop: {0}", TotalCreatedUser_ByForLoop.Count);

            DateTime EndDateTime_ForLoop = DateTime.Now;
            Console.WriteLine("Execution Ended For SimpleForLoop Creating  {0} Users: {1}", TotalLimit, EndDateTime_ForLoop);

            stopwatch_SimpleForLoop.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by For Loop: {0}", stopwatch_SimpleForLoop.ElapsedMilliseconds);

            ElapsedTimeData.Add("Simple For Loop", stopwatch_SimpleForLoop.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Simple For Each Loop 
            var stopwatch_SimpleForEachLoop = new Stopwatch();
            stopwatch_SimpleForEachLoop.Start();

            DateTime StartDateTime_ForEachLoop = DateTime.Now;
            Console.WriteLine("Execution Started For SimpleForLoopEach Creating  {0} Users: {1}", TotalLimit, StartDateTime_ForEachLoop);

            //Invoke the SimpleForEachLoop Here
            var TotalCreatedUser_ByForEachLoop = SimpleForEachLoop.Invoke();
            Console.WriteLine("Count of UserList Added by SimpleForLoopForEach: {0}", TotalCreatedUser_ByForEachLoop.Count);

            DateTime EndDateTime_ForEachLoop = DateTime.Now;
            Console.WriteLine("Execution Ended For SimpleForEachLoop Creating  {0} Users: {1}", TotalLimit, EndDateTime_ForEachLoop);
            stopwatch_SimpleForEachLoop.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by For Each Loop: {0}", stopwatch_SimpleForEachLoop.ElapsedMilliseconds);

            ElapsedTimeData.Add("Simple ForEach Loop", stopwatch_SimpleForEachLoop.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Parallel For Each Loop 
            var stopwatch_ParallelForEachLoop = new Stopwatch();
            stopwatch_ParallelForEachLoop.Start();

            DateTime StartDateTime_ParallelForEachLoop = DateTime.Now;
            Console.WriteLine("Execution Started For ParallelForLoopEach Creating  {0} Users: {1}", TotalLimit, StartDateTime_ParallelForEachLoop);

            //Invoke the SimpleForEachLoop Here
            var TotalCreatedUser_ByParallelForEachLoop = ParallelForEach.Invoke();
            Console.WriteLine("Count of UserList Added by ParallelForLoopForEach: {0}", TotalCreatedUser_ByParallelForEachLoop.Count);

            DateTime EndDateTime_ParallelForEachLoop = DateTime.Now;
            Console.WriteLine("Execution Ended For ParallelForEachLoop Creating  {0} Users: {1}", TotalLimit, EndDateTime_ParallelForEachLoop);
            stopwatch_ParallelForEachLoop.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by Parallel For Each Loop: {0}", stopwatch_ParallelForEachLoop.ElapsedMilliseconds);

            ElapsedTimeData.Add("Parallel ForEach Loop", stopwatch_ParallelForEachLoop.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Parallel For Each Loop With MaxDegreeOfParallelism
            var stopwatch_ParallelForEachLoop_WithMaxDegreeOfParallelism = new Stopwatch();
            stopwatch_ParallelForEachLoop_WithMaxDegreeOfParallelism.Start();

            DateTime StartDateTime_ParallelForEachLoop_WithMaxDegreeOfParallelism = DateTime.Now;
            Console.WriteLine("Execution Started For ParalleForLoopEach With MaxDegreeOfParallelism Creating  {0} Users: {1}", TotalLimit, StartDateTime_ParallelForEachLoop_WithMaxDegreeOfParallelism);

            //Invoke the SimpleForEachLoop Here
            var TotalCreatedUser_ByParallelForEachLoop_WithMaxDegreeOfParallelism = ParallelForEachWithMaxDegreeOfParallelism.Invoke();
            Console.WriteLine("Count of UserList Added by ParallelForLoopForEach With MaxDegreeOfParallelism: {0}", TotalCreatedUser_ByParallelForEachLoop_WithMaxDegreeOfParallelism.Count);

            DateTime EndDateTime_ParallelForEachLoop_WithMaxDegreeOfParallelism = DateTime.Now;
            Console.WriteLine("Execution Ended For ParallelForEachLoop With MaxDegreeOfParallelism Creating  {0} Users: {1}", TotalLimit, EndDateTime_ParallelForEachLoop_WithMaxDegreeOfParallelism);
            stopwatch_ParallelForEachLoop_WithMaxDegreeOfParallelism.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by Parallel For Each Loop With MaxDegreeOfParallelism: {0}", stopwatch_ParallelForEachLoop_WithMaxDegreeOfParallelism.ElapsedMilliseconds);

            ElapsedTimeData.Add("Parallel ForEach Loop With MaxDegreeOfParallelism", stopwatch_ParallelForEachLoop_WithMaxDegreeOfParallelism.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Parallel For Each Loop With Lock 
            var stopwatch_ParallelForEachLoopWithLock = new Stopwatch();
            stopwatch_ParallelForEachLoopWithLock.Start();

            DateTime StartDateTime_ParallelForEachLoopWithLock = DateTime.Now;
            Console.WriteLine("Execution Started For ParallelForLoopEach With Lock Creating  {0} Users: {1}", TotalLimit, StartDateTime_ParallelForEachLoopWithLock);

            //Invoke the SimpleForEachLoop Here
            var TotalCreatedUser_ByParallelForEachLoopWithLock = ParallelForEachWithLock.Invoke();
            Console.WriteLine("Count of UserList Added by ParallelForLoopForEach With Lock: {0}", TotalCreatedUser_ByParallelForEachLoopWithLock.Count);

            DateTime EndDateTime_ParallelForEachLoopWithLock = DateTime.Now;
            Console.WriteLine("Execution Ended For ParallelForEachLoop With Lock Creating  {0} Users: {1}", TotalLimit, EndDateTime_ParallelForEachLoopWithLock);
            stopwatch_ParallelForEachLoopWithLock.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by Parallel For Each Loop With Lock: {0}", stopwatch_ParallelForEachLoopWithLock.ElapsedMilliseconds);

            ElapsedTimeData.Add("Parallel ForEach Loop With Lock", stopwatch_ParallelForEachLoopWithLock.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Parallel ForEach With ConcurrentBag
            var stopwatch_ParallelForEachLoopWithConcurrentBag = new Stopwatch();
            stopwatch_ParallelForEachLoopWithConcurrentBag.Start();

            DateTime StartDateTime_ParallelForEachLoopWithConcurrentBag = DateTime.Now;
            Console.WriteLine("Execution Started For ParallelForLoopEach With ConcurrentBag Creating  {0} Users: {1}", TotalLimit, StartDateTime_ParallelForEachLoopWithConcurrentBag);

            //Invoke the SimpleForEachLoop Here
            var TotalCreatedUser_ByParallelForEachLoopWithConcurrentBag = ParallelForEachWithConcurrentBag.Invoke();
            Console.WriteLine("Count of UserList Added by ParallelForLoopForEach With ConcurrentBag: {0}", TotalCreatedUser_ByParallelForEachLoopWithConcurrentBag.Count);

            DateTime EndDateTime_ParallelForEachLoopWithConcurrentBag = DateTime.Now;
            Console.WriteLine("Execution Ended For ParallelForEachLoop With ConcurrentBag Creating  {0} Users: {1}", TotalLimit, EndDateTime_ParallelForEachLoopWithConcurrentBag);
            stopwatch_ParallelForEachLoopWithConcurrentBag.Stop();

            Console.WriteLine("Time Elapsed In Stop Watch by Parallel For Each ConcurrentBag With Lock: {0}", stopwatch_ParallelForEachLoopWithConcurrentBag.ElapsedMilliseconds);

            ElapsedTimeData.Add("Parallel ForEach Loop With ConcurrentBag", stopwatch_ParallelForEachLoopWithConcurrentBag.ElapsedMilliseconds);
            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
            #endregion

            #region Code For Print Elapsed Time For All Approaches
            PrintElapsedTimeData(ElapsedTimeData);
            #endregion

            Console.WriteLine("=================================================================================================================");
            Console.WriteLine("=================================================================================================================");
        }

        /// <summary>
        /// Print Elapsed Time Data
        /// </summary>
        public static void PrintElapsedTimeData(Dictionary<string, long> ElapsedTimeData)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (KeyValuePair<string, long> i in ElapsedTimeData.OrderBy(key => key.Value))
            {
                Console.WriteLine(string.Format("For Task - [{0}] : Time Taken [{1}] In Milliseconds", i.Key, i.Value));
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
