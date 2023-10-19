namespace eventBus
{
    public class Program
    {
        private static RetrievalEventBus _eventBus = (RetrievalEventBus)RetrievalEventBus.Default;

        public static void Main(string[] args)
        {
            Console.WriteLine(_eventBus.ToString());
        }
    }
}