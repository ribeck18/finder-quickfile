class Controller
{
    // private UserInterface _UI;
    private FileRequest _fileRequest;
    private BuildFile _buildFile;
    private Tui _tui;

    public Controller(UserInterface ui, FileRequest fileRequest, BuildFile buildFile, Tui tui)
    {
        // _UI = ui;
        _tui = tui;
        _fileRequest = fileRequest;
        _buildFile = buildFile;
    }

    public void StartUI()
    {
        // _UI.RunUI();
        _tui.RunTui();
    }
    public void FileRequest(){
      _fileRequest.
    }

    public void BuildFile(){
        _buildFile.CreateFile() 
    }
}
