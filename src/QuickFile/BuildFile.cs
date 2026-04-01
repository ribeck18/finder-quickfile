class BuildFile
{
    private FileRequest _filerequest;

    public BuildFile(FileRequest fileRequest)
    {
        _filerequest = fileRequest;
    }

    public FileType CreateFile()
    {
        //Uses the FileRequest class to build a derived FileType.
        Dictionary<string, string> fileDict = _filerequest.GetFileDict();
        string extension = fileDict["extension"];

        if (extension == "txt")
        {
            TxtType file = new TxtType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else if (extension == "md")
        {
            MarkdownType file = new MarkdownType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else if (extension == "py")
        {
            PythonType file = new PythonType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
        else
        {
            CSharpType file = new CSharpType(fileDict["name"], extension, fileDict["template"]);
            return file;
        }
    }
}
