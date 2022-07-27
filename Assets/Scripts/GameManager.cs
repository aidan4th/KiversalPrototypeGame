using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public bool gameHasEnded = false;
    public GameObject car;
    public bool carSpawned = false;

    
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
    public void spawnCar()
    {
        carSpawned = true;
    }
    void Update() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (carSpawned) {
            if ((int)player.GetComponent<PlayerMovement>().lane[player.GetComponent<PlayerMovement>().lanePlace] == (int)player.GetComponent<Rigidbody>().position.x) {
          
                carSpawned = false;
                Instantiate(car, new Vector3(player.GetComponent<PlayerMovement>().lane[player.GetComponent<PlayerMovement>().lanePlace],player.GetComponent<Rigidbody>().position.y, player.GetComponent<Rigidbody>().position.z + 155), new Quaternion(0,0,0,0));
            } 
        }
    }
}
