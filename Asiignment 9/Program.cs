using System;

namespace Asiignment_9
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            DirectoryLogic directoryLogic = new DirectoryLogic();
           directoryLogic.ReadfromList(@"C:\MyDir\hk");

        }
    }
}
