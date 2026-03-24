class Tui
{
    string _name;
    string _extension;
    int _templateChoice;

    private void SetName(string name)
    {
        _name = name;
    }

    private void SetExtension(string extension)
    {
        _extension = extension;
    }

    private void SetTemplateChoice(int templateChoice)
    {
        _templateChoice = templateChoice;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetExtension()
    {
        return _extension;
    }

    public int GetTemplateChoice()
    {
        return _templateChoice;
    }

    public void RunTui()
    {
        Console.WriteLine("Please enter file name");
        Console.Write(">");
        SetName(Console.ReadLine());

        Console.WriteLine("Please enter a file extension");
        Console.Write(">");
        SetExtension(Console.ReadLine());

        Console.WriteLine("Please choose a template.");
        Console.Write(">");
        SetTemplateChoice(int.Parse(Console.ReadLine()));
    }
}
