class PythonType : FileType
{
    public PythonType(string name, string extension, string template) : base(name, extension, template)
    {

    }
    public override string FormatFileName()
    {
        string nameString = $"{_name}.{_extension}";

        return ToSnakeCase(nameString);
    }
}
