using System;
using System.Threading;

namespace CarSupplier.Hosting
{
    public static class ConsoleReader
    {
        private static Thread inputThread;
        private static AutoResetEvent getInput, gotInput;
        private static int input;

        static ConsoleReader()
        {
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
            inputThread = new Thread(reader);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                input = Console.Read();
                gotInput.Set();
            }
        }

        public static int Read(int timeOutms = Timeout.Infinite)
        {
            getInput.Set();

            bool success = gotInput.WaitOne(timeOutms);

            if (success)
            {
                return input;
            }
            else
            {
                throw new TimeoutException($"No input received within timelimit of {timeOutms}ms");
            }
        }

        public static int Read(CancellationToken cancellationToken, int timeOutms = Timeout.Infinite)
        {
            int initialTimeout = timeOutms;
            int interval = 5000;

            while (timeOutms > 0 && cancellationToken.IsCancellationRequested == false)
            {
                getInput.Set();

                bool success = gotInput.WaitOne(interval);

                if (success)
                {
                    return input;
                }
                else
                {
                    if (initialTimeout != Timeout.Infinite)
                    {
                        timeOutms = timeOutms - interval;
                    }
                }
            }

            throw new TimeoutException($"No input received within timelimit of {initialTimeout}ms");
        }
    }
}
