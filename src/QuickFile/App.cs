using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Themes.Fluent;

public class App : Application
{

    public override void Initialize()
    {
        Styles.Add(new FluentTheme());
    }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            string[] args = desktop.Args ?? Array.Empty<string>();
            Controller controller = new Controller();
            controller.RunUI();
            desktop.MainWindow = controller.GetWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}

