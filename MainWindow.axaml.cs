using System;
using Avalonia.Controls;
using Mastonet;

namespace MastodonAvaloniaTest;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var instance = "mastodon.social";
        var authClient = new AuthenticationClient(instance);
        var appRegistration = authClient.CreateApp("C# Mastodon Test", Scope.Read | Scope.Write | Scope.Follow).GetAwaiter().GetResult();

        var url = authClient.OAuthUrl();
        _ = System.Diagnostics.Process.Start("sensible-browser", url);
        Console.Write("Enter access token: ");
        var token = Console.ReadLine();
        Console.WriteLine(@$"Token: {token}");

        var client = new MastodonClient(instance, token ?? string.Empty);
        authClient.ConnectWithCode(token ?? string.Empty);
    }
}