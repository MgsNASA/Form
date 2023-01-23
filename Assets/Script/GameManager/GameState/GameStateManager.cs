public class GameStateManager 
{
    private static GameStateManager _instance;

    public static GameStateManager Instance
    {
        get 
        {
            if (_instance == null)
                _instance = new GameStateManager();
            return _instance;
        }
    }
    private GameStateManager()
    { 
      
    
    }
}