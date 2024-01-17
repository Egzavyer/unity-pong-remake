using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("START");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
