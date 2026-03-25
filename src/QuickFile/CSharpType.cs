class CSharpType : FileType
{
    public CSharpType(string name, string extension, string template) : base(name, extension, template) { }

    public override string FormatFileName()
    {
        string fileName = $"{ToPascalCase(_name)}.{_extension}";

        return fileName;
    }
}
