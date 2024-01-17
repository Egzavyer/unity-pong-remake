using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelect : MonoBehaviour
{
    //=======================================================================================================
    //Load the scene for 2 players


    public void StartGame2P()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //=======================================================================================================
    //Load the scene for 1 player


    public void StartGame1P()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    //=======================================================================================================
}
