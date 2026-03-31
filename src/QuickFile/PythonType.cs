class PythonType : FileType
{
    public PythonType(string name, string extension, string template) : base(name, extension, template)
    {

    }
    public override string FormatFileName()
    {
        string nameString = $"{ToSnakeCase(_name)}.{_extension}";

        return nameString;
    }
}
