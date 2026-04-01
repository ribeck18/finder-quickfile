using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Themes.Fluent;
using Avalonia.Styling; //Alignements
using Avalonia.Media; //Brushes and colors
using Avalonia.Controls; //Buttons etc.

public class App : Application
{

    public override void Initialize()
    {
        Styles.Add(new FluentTheme());
        //Text Styles
        Styles.Add(new Style(x => x.OfType<TextBlock>())
        {
            Setters = {
            new Setter(TextBlock.FontFamilyProperty, new FontFamily("SF Pro Display, Helvetica Neue, Arial")),
            new Setter(TextBlock.FontSizeProperty, 13.0),
            new Setter(TextBlock.ForegroundProperty, new SolidColorBrush(Color.Parse("#1C1C1E"))),
            }
        });
        //Button Styles
        Styles.Add(new Style(x => x.OfType<Button>())
        {
            Setters ={
            new Setter(Button.CornerRadiusProperty, new CornerRadius(6)),
            new Setter(Button.PaddingProperty, new Thickness(14,6)),
            new Setter(Button.BackgroundProperty, new SolidColorBrush((Color.Parse("#007AFF")))),
            new Setter(Button.ForegroundProperty, Brushes.White),
            new Setter(Button.BorderThicknessProperty, new Thickness(0))
            }
        });
    }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            string[] args = desktop.Args ?? Array.Empty<string>();
            Controller controller = new Controller(args);
            controller.RunUI();
            desktop.MainWindow = controller.GetWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}

