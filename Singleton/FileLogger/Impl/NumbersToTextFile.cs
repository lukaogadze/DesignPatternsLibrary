using System;
using FileLoggerSample.Impl.Factories;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl
{
    public class NumbersToTextFile : INumbersToTextFile
    {
        private readonly IFileLoggerFactory _fileLoggerFactory;
        public NumbersToTextFile(IFileLoggerFactory fileLoggerFactory)
        {
            _fileLoggerFactory = fileLoggerFactory;
        }

        public void WriteNumbersToFile()
        {
            Console.WriteLine("Begin Logging to File");
            var generator = new NumberGenerator();
            IFileLogger myLogger = null;
            foreach (long integer in generator.Integers())
            {
                Console.Write(".");
                myLogger = _fileLoggerFactory.Create();
                myLogger.WriteLineToFile("Getting next number...");
                myLogger.WriteLineToFile("Logged Number: " + integer);

                // this is inefficient...
                if (_fileLoggerFactory is InstanceFileLoggerFactory)
                {
                    myLogger.CloseFile();
                }

                if (integer >= _maxIntegerToWrite)
                {
                    break;
                }
            }
            myLogger.CloseFile();
            Console.WriteLine();
        }

        private int _maxIntegerToWrite = 100;
        public int MaxIntegerToWrite
        {
            set { _maxIntegerToWrite = value; }
        }
    }
}