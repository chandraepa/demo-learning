using DemoLearning.Interface.SOLID.ISP;

namespace DemoLearning.Services.SOLID.ISP
{
    public class LiquidInkjetPrinter : IPrinterTasks
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
    }
}
