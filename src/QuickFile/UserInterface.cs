using Avalonia.Controls;

class UserInterface : Window
{
    //Notes: make all of the elemenets a field in the class. Then Each one should have a build method (like a setter). Then in the Constructor each build should be called.
    //The purpose of this is so that when save button is pressed it can pull the data from each text box etc.
    //
    //TO DO:
    //Add a button with a save functionality. Probably should build a file request or something like that when the OnClick method runs.

    private TextBox _fileNameEntry = new TextBox();
    private ComboBox _typeSelection = new ComboBox();
    private ComboBox _templateSelection = new ComboBox();

    public UserInterface()
    {
        Title = "Quick File";
        Width = 400;
        Height = 400;


        //Define the text elements
        TextBlock fileName = new TextBlock
        {
            Text = "File Name:",
        };
        TextBlock extension = new TextBlock
        {
            Text = "File Type:",
        };
        TextBlock template = new TextBlock
        {
            Text = "Template:",
        };


        //organize all of the elemenets
        StackPanel stackpanel = new StackPanel();
        stackpanel.Spacing = 10;
        stackpanel.Margin = new Avalonia.Thickness(20);

        stackpanel.Children.Add(fileName);
        stackpanel.Children.Add(BuildFileNameEntry());
        stackpanel.Children.Add(extension);
        stackpanel.Children.Add(BuildTypeSelection());
        stackpanel.Children.Add(template);
        stackpanel.Children.Add(BuildTemplateSelection());

        Content = stackpanel;
    }

    private TextBox BuildFileNameEntry()
    {
        _fileNameEntry.Watermark = "Enter file name...";
        _fileNameEntry.MaxLength = 50;

        return _fileNameEntry;
    }

    private ComboBox BuildTypeSelection()
    {
        _typeSelection.Items.Add("md");
        _typeSelection.Items.Add("txt");
        _typeSelection.Items.Add("py");
        _typeSelection.Items.Add("cs");
        _typeSelection.SelectedIndex = 0;

        return _typeSelection;
    }

    private ComboBox BuildTemplateSelection()
    {
        _templateSelection.Items.Add(1);
        _templateSelection.SelectedIndex = 0;

        return _templateSelection;
    }
}
