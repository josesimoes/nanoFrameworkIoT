using System;

namespace TranformSpanList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello file creation");
            TransformGenericToClass.TransformTofile(@"c:\tmp\nanoFrameworkIoT\Span\Span.cs", "byte", @"C:\tmp\TranformSpanList\SpanByte.cs");
            TransformGenericToClass.TransformTofile(@"c:\tmp\nanoFrameworkIoT\Span\ReadOnlySpan.cs", "byte", @"C:\tmp\TranformSpanList\ReadOnlySpanByte.cs");
            TransformGenericToClass.TransformTofile(@"c:\tmp\nanoFrameworkIoT\List\List.cs", "byte", @"C:\tmp\TranformSpanList\ListByte.cs");
        }
    }
}
