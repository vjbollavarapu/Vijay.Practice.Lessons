using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijay.Practice.CSharpAdvanced
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }

        public MyCustomAttribute(string description)
        {
            Description = description;
        }
    }

    [MyCustom("This is a sample class")]
    public class MyAttributeTestClass
    {
        [MyCustom("This is a sample method")]
        public void Method()
        {
            Console.WriteLine("Inside My method");
        }
    }
}
