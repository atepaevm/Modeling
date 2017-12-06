using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor proc=new Processor();
            proc.currentProcess = new Process(1);
        }
    }
}
