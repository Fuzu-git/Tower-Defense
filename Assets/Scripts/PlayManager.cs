using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    private bool gameEnded = false;
    void Update()
    {
        if (gameEnded)
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
        gameEnded = true;
    }
}
