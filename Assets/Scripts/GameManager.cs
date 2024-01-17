using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;
    public static float scorePlayer1 = 0f;
    public static float scorePlayer2 = 0f;
    public static float lastPoint = 1f;
    public float restartDelay = 0.5f;
    public GameObject player1WinUI;
    public GameObject player2WinUI;
    public GameObject Ball;

    public void Update()
    {
        if (scorePlayer1 == 5f)
        {
            player1WinUI.SetActive(true);
            Ball.SetActive(false);

        }
        if (scorePlayer2 == 5f)
        {
            player2WinUI.SetActive(true);
            Ball.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            scorePlayer1 = 0f;
            scorePlayer2 = 0f;
            lastPoint = 1f;
            Restart();
        }
    }

    public void EndRound()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Invoke(nameof(Restart), restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
