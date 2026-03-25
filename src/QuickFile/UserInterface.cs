using Avalonia.Controls;

class UserInterface : Window
{
    public UserInterface()
    {
        Title = "Quick File";
        Width = 400;
        Height = 400;

        Content = new TextBlock { Text = "Hello World" };
    }
}
