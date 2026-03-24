class FileRequest
{
    //Attributes
    private string _name;
    private string _extension;
    private Dictionary<string, Dictionary<int, string>> _templateOptions;
    private string _templateChoice;
    private string _path;

    public FileRequest()
    {
        // _name = name;
        // _extension = extension;
        _templateOptions = new Dictionary<string, Dictionary<int, string>>
        {
            {
                "MarkDown",
                new Dictionary<int, string> { { 1, "# MARKDOWN HEADER" } }
            },
        };
    }

    //methods
    public void SetTemplate(string extension, int templateChoice)
    {
        _templateChoice = _templateOptions[extension][templateChoice];
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetExtension(string extension)
    {
        _extension = extension;
    }

    public string SetPath(string path)
    {
        _path = path;
        return path;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetExtension()
    {
        return _extension;
    }

    public string GetTemplate()
    {
        return _templateChoice;
    }

    public string GetPath()
    {
        return _path;
    }

    public Dictionary<string, string> GetFileDict()
    {
        Dictionary<string, string> fileDict = new Dictionary<string, string>();
        fileDict.Add("name", _name);
        fileDict.Add("extension", _extension);
        fileDict.Add("template", _templateChoice);

        return fileDict;
    }
}
