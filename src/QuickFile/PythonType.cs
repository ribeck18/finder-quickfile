class PythonType : FileType
{
    Dictionary<string, string> _templateDict = new Dictionary<string, string>{
        {"helloWorld", @"hello_world = 'Hello World!'
print(hello_world)
            "}
    };
    string[] _keyList = ["helloWorld"];

    public PythonType(string name, string extension, string template) : base(name, extension, template)
    {

    }
    public override string FormatFileName()
    {
        string nameString = $"{ToSnakeCase(_name)}.{_extension}";

        return nameString;
    }

    public override string[] GetKeyList()
    {
        return _keyList;
    }
}
