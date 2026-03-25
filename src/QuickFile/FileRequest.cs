class FileRequest
{
    //Attributes
    private string _name;
    private string _extension;
    private Dictionary<string, Dictionary<int, string>> _templateOptions;
    private int _templateChoice;
    private string _path;

    public FileRequest(string name, string extension, int templateChoice, string path)
    {
        _name = name;
        _extension = extension;
        _templateChoice = templateChoice;
        _path = path;
        _templateOptions = new Dictionary<string, Dictionary<int, string>>
        {
            {
                "md",
                new Dictionary<int, string> {{1, "# MARKDOWN HEADER"}}
            },
            {
                "txt",
                new Dictionary<int, string> {{1, "Text File"}}
            },
            {
                "py",
                new Dictionary<int, string> {{1, "print('Hello World')"}}
            },
            {
                "cs",
                new Dictionary<int, string> {{1, "Console.WriteLine('Hello World')"}}
            }
        };
    }

    //methods
    public string GetTemplate()
    {
        string selectedTemplate = _templateOptions[_extension][_templateChoice];
        return selectedTemplate;
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
        fileDict.Add("template", GetTemplate());
        fileDict.Add("path", _path);

        return fileDict;
    }
}
