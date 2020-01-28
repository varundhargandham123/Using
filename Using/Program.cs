using System;

namespace IDisposableDemo
{
    class IDisposableDemo : IDisposable
    {
        private string name;
        private bool disposename = false;

        public IDisposableDemo(string name)
        {
            this.name = name;
            this.disposename = true;
        }
        public void display()
        {
            Console.WriteLine(this.name);
        }
        public void Dispose()
        {
            if (disposename)
            {
                name = string.Empty;
                Console.WriteLine("disposed");

            }
            disposename = false;
        }
        ~IDisposableDemo() {
            Console.WriteLine("disp");
        }
    }
    class DisposableDemo
    {
        public static void Main(string[] args)
        {
            using (IDisposableDemo obj = new IDisposableDemo("varun"))
            {
                Console.WriteLine("hi");   
            }
            Console.WriteLine("before    {0:N0}", GC.GetTotalMemory(false));
            GC.Collect(0);
            Console.WriteLine("after      {0:N0}", GC.GetTotalMemory(true));
        }
    }
}