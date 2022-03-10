namespace ScheduledTask
{
    public class Counter
    {
        public void CounterHours(int time)
        {
            for (var i = 1; i <= time; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
