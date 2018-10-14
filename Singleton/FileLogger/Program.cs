using System;
using System.Diagnostics;
using System.IO;
using FileLoggerSample.Impl;
using FileLoggerSample.Interfaces;
using Microsoft.Practices.Unity;

namespace FileLoggerSample
{
    internal class Program
    {
        private const bool _useParallel = true;
        private static UnityDependencyResolver _dependencyResolver;
        private static INumbersToTextFile _numbersToTextFile;

        private static void RegisterTypes()
        {
            _dependencyResolver = new UnityDependencyResolver();
            _dependencyResolver.EnsureDependenciesRegistered();
            if (_useParallel)
            {
                _dependencyResolver.Container.RegisterType<INumbersToTextFile, NumbersToTextFileAsync>();
            }
            else
            {
                _dependencyResolver.Container.RegisterType(typeof (INumbersToTextFile), typeof (NumbersToTextFile));
            }
        }

        private static void Main(string[] args)
        {
            RegisterTypes();
            File.Delete( @"c:\dev\scratch\logs\logfile.txt");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _numbersToTextFile = _dependencyResolver.Container.Resolve<INumbersToTextFile>();
            _numbersToTextFile.MaxIntegerToWrite = 100;
            _numbersToTextFile.WriteNumbersToFile();

            stopwatch.Stop();
            Console.WriteLine("Time Elapsed: {0}", stopwatch.Elapsed);

            Console.ReadLine();
        }
    }
}