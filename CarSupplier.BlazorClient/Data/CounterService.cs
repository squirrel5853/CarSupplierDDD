namespace CarSupplier.BlazorClient.Data
{
    public class CounterService
    {
        private int Counter = 0;

        public void Increment()
        {
            Counter++;
        }

        public int GetCurrentCount()
        {
            return Counter;
        }
    }
}
