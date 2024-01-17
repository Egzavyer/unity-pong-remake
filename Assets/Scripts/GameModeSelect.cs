using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelect : MonoBehaviour
{
    public void StartGame2P()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame1P()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
