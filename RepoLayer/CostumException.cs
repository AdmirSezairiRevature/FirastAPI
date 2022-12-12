namespace RepoLayer
{
    public class CostumException : Exception
    {
        public CostumException(){

        }
        public string message { get; set; } = "Custom exception was fired.";
    }
}