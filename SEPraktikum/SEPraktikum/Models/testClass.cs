using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    class testClass
    {
        private delegate void Del(string text);

        public testClass()
        {
            Del handler = DelegateMethod;

            handler("Hello World");
        }

        public void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }
    }        
}
