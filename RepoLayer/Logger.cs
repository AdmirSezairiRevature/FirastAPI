namespace RepoLayer {
    public interface ILogger {
        void logStuff(object obj);
    }

    public class Logger : ILogger
    {
        public void logStuff(object obj)
        {
             Console.WriteLine($"{obj} just happened!");
        }
    }
}