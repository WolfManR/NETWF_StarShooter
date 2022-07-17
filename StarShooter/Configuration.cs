namespace StarShooter;

public static class Configuration
{
    public const int WindowWidth = 800;
    public const int WindowHeight = 600;

    public static class Assets
    {
        public const string Star = nameof(Assets) + "/" + "star.png";
        public const string Ship = nameof(Assets) + "/" + "ship.png";
        public const string Heal = nameof(Assets) + "/" + "Heal.png";
        public const string MainMenuBackground = nameof(Assets) + "/" + "BackGround1.jpg";
        public const string SceneBackground1 = nameof(Assets) + "/" + "BackGround2.jpg";
        public const string Asteroid1 = nameof(Assets) + "/" + "Asteroid1.png";
        public const string Asteroid2 = nameof(Assets) + "/" + "Asteroid2.png";
        public const string Asteroid3 = nameof(Assets) + "/" + "Asteroid3.png";
    }
}