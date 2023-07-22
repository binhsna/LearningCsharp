using System;

namespace MyNameSpace
{
    // class, struct, enum, interface ... namespace
    public partial class Class1
    {
        public static void XinChao()
        {
            Console.WriteLine("Xin chao tu Class 1");
        }
    }
    namespace Abc
    {
        public class Class1
        {
            public static void XinChao()
            {
                Console.WriteLine("Xin chao tu Abc/Class 1");
            }
        }
    }
}