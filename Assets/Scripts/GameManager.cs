using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public bool gameHasEnded = false;

    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //FindObjectOfType(typeof(TextMesh)).stopScoring = true;
            Debug.Log("The EndGame Function was called");
            Invoke("Restart", 2f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
