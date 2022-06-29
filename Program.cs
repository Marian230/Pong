using Game;

try
{
    Game.Game.Instance.Play();
}
catch (Exception e)
{
    Environment.Exit(0);
}
finally
{
   Drawing.ResetConsole(); 
}

Console.ReadKey();

// TODO: fix input co i can press multiple keys at once
// TODO: make console render faster