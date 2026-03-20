class BuildFile
{
    private FileRequest _filerequest;

    public BuildFile(FileRequest fileRequest)
    {
        _filerequest = fileRequest;
    }

    public BuildFile()
    {
        //This will build the file. It should get data from the _filerequest object as a dict. Then it should use that dict to decide on a file type and then build that filetype object and return it.

    }
}
