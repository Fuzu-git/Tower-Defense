using UnityEngine;

public class PlayManager : MonoBehaviour
{
    private bool _gameEnded = false;
    void Update()
    {
        if (_gameEnded)
        {
            return;
        }
        
        if (PlayerManager.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        _gameEnded = true;
        QuitGame();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
