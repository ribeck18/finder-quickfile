class CSharpType : FileType
{
    Dictionary<string, string> _templateDict = new Dictionary<string, string>{
        {"helloWorld", @"
using System;

namespace ProjectName
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}
"},
    };
    string[] _keyList = ["helloWorld"];
    public CSharpType(string name, string extension, string template) : base(name, extension, template) { }

    public override string FormatFileName()
    {
        string fileName = $"{ToPascalCase(_name)}.{_extension}";

        return fileName;
    }

    public override string[] GetKeyList()
    {
        return _keyList;
    }
}
