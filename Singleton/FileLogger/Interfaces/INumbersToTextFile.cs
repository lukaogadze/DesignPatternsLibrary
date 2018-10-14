namespace FileLoggerSample.Interfaces
{
    public interface INumbersToTextFile
    {
        void WriteNumbersToFile();
        int MaxIntegerToWrite { set; }
    }
}