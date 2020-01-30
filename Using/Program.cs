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
        }/// <summary>
        /// This method is used to display the name
        /// </summary>
        public void display()
        {
            Console.WriteLine(this.name);
        }/// <summary>
        /// This method is used to dispose by checking the disposename
        /// </summary>
        public void Dispose()
        {
            if (disposename)
            {
                name = string.Empty;
                Console.WriteLine("disposed");

            }
            disposename = false;
        }/// <summary>
        /// This is the destructor 
        /// </summary>
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