namespace LoggerExercise.LogFiles
{
    public interface ILogFile
    {
        void Write(string message);
        int Size();
    }
}
