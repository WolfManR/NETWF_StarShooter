﻿using StarShooter.GameEngine;
using StarShooter.Prefabs;

namespace StarShooter;

public static class SplashScreen
{
    static readonly Image background = Image.FromFile(Configuration.Assets.MainMenuBackground);
    public static void Init(Form form)
    {
        form.BackgroundImage = background;
        form.BackgroundImageLayout = ImageLayout.Stretch;

        Button play = new Button
        {
            Text = "Play",
            Width = 100,
            Height = 30
        };
        play.Location = new Point(form.Width - play.Width - 30, form.Height - 200);
        play.Click += (sender, e) =>
        {
            form.Controls.Clear();
            form.BackgroundImage = null;
            form.KeyDown += Form_KeyDown;
            MainGame.Start();
            Log("SplashScreen Button: play - pressed");
        };

        Button records = new Button()
        {
            Text = "Records",
            Width = 100,
            Height = 30
        };
        records.Location = new Point(play.Location.X, play.Location.Y + play.Height + 10);

        Button exit = new Button()
        {
            Text = "Exit",
            Width = 100,
            Height = 30
        };
        exit.Location = new Point(records.Location.X, records.Location.Y + records.Height + 10);
        exit.Click += (sender, e) =>
        {
            Log("SplashScreen Button: exit - pressed");
            form.Close();
        };

        Button[] menu = { play, records, exit };
        form.Controls.AddRange(menu);
    }

    private static void Log(string message)
    {
        LogService.Log(message);
    }

    private static void Form_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.ControlKey:
                MainGame.Attack();
                break;
            case Keys.Up:
                MainGame.MoveUp();
                break;
            case Keys.Down:
                MainGame.MoveDown();
                break;
        }
    }
}