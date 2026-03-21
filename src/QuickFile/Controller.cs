class Controller
{
    private UserInterface _UI;
    private FileRequest _fileRequest;
    private BuildFile _buildFile;

    public Controller(UserInterface ui, FileRequest fileRequest, BuildFile buildFile)
    {
        _UI = ui;
        _fileRequest = fileRequest;
        _buildFile = buildFile;
    }

    public void StartUI()
    {
        _UI.RunUI();
    }
}
