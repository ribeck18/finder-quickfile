class CSharpType : FileType
{
    public CSharpType(string name, string extension, string template) : base(name, extension, template) { }

    public override string FormatFileName()
    {
        string nameString = ToPascalCase(_name);
        string fileName = $"{nameString}.{_extension}";

        return fileName;
    }
}
