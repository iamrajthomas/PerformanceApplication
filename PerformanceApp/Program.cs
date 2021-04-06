//  -------------------------------------------------------------------------
//  <copyright file="Program.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Main Entry Point For Perf Application
//  </summary>
//  -------------------------------------------------------------------------

namespace PerformanceApp
{
    using PerformanceApp.Class;
    using System;
    class Program
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        static void Main(string[] args)
        {
            Startup.Init();
            Console.ReadLine();

        }
    }
}
