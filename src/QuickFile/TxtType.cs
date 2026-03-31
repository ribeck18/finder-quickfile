class TxtType : FileType
{
    Dictionary<string, string> _templateDict = new Dictionary<string, string>{
        {"helloWorld", "Hello World"},
        {"requirments", @"# Requirements
# Format: package-name==version
# Use '==' to pin exact versions (recommended for production)
# Use '>=' to allow newer versions
# Example:
# requests==2.31.0
# numpy>=1.24.0

# Core Dependencies


# Development Dependencies


# Testing Dependencies

"}
    };
    private string[] _keyList = ["helloWorld"];

    public TxtType(string name, string extension, string template) : base(name, extension, template) { }


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
