class BuildFile
{
    private FileRequest _filerequest;

    public BuildFile(FileRequest fileRequest)
    {
        _filerequest = fileRequest;
    }

    public FileType CreateFile()
    {
        Dictionary<string, string> fileDict = _filerequest.GetFileDict();
        string extension = fileDict["extension"];
        //add several if statements here to check what file extension is in the dic. then build a file using the correct file type.

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
