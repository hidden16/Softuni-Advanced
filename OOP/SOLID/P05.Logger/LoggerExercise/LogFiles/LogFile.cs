
namespace LoggerExercise.LogFiles
{
    using System.Text;
    using System.Linq;
    public class LogFile : ILogFile
    {
        private StringBuilder sb;
        public LogFile()
        {
            sb = new StringBuilder();
        }
        public int Size()
        {
            var sum = sb.ToString().Where(char.IsLetter).Sum(x => x);
            return sum;
        }

        public void Write(string message)
        {
            sb.Append(message);
        }
    }
}
