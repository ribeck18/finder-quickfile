class FileType
{
    //Attributes
    private string _name;
    private string _extension;
    private string _content;

    //Constructor
    public FileType(string name, string extension)
    {
        _name = name;
        _extension = extension;
    }

    //methods
    public string GetName()
    {
        return _name;
    }
}
