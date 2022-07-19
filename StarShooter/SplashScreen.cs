using StarShooter.GameEngine;
using StarShooter.Prefabs;

namespace StarShooter;

public static class SplashScreen
{
    static readonly Image background = Image.FromFile(Configuration.Assets.MainMenuBackground);
    public static void Init(Form form)
    {
        form.BackgroundImage = background;
        form.BackgroundImageLayout = ImageLayout.Stretch;

        Button play = new()
        {
            Text = "Play",
            Width = 100,
            Height = 30
        };
        play.Location = new Point(form.Width - play.Width - 30, form.Height - 200);
        play.Click += (sender, e) =>
        {
            MainGame.Start();
            Log("SplashScreen Button: play - pressed");
        };

        Button records = new()
        {
            Text = "Records",
            Width = 100,
            Height = 30,
            Location = play.Location with { Y = play.Location.Y + play.Height + 10 },
            Enabled = false
        };

        Button exit = new()
        {
            Text = "Exit",
            Width = 100,
            Height = 30,
            Location = records.Location with { Y = records.Location.Y + records.Height + 10 }
        };

        exit.Click += (sender, e) =>
        {
            Log("SplashScreen Button: exit - pressed");
            form.Close();
        };

        Control[] menu = { play, records, exit };
        form.Controls.AddRange(menu);
    }

    private static void Log(string message)
    {
        LogService.Log(message);
    }
}