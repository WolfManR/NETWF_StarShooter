using StarShooter.GameEngine;
using StarShooter.Scenes;

namespace StarShooter;

public class SplashScreen : GameScene
{
    public event Action? OnStartGame; 
    public event Action? OnExit; 

    public override void Load()
    {
        var form = GameState.MainForm;
        form.BackgroundImage = Image.FromFile(Configuration.Assets.MainMenuBackground);
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
            OnStartGame?.Invoke();
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
            OnExit?.Invoke();
        };

        Control[] menu = { play, records, exit };
        form.Controls.AddRange(menu);
    }

    public override void Draw()
    {
        Engine.Stop();
    }

    public override void Update()
    {
    }
}