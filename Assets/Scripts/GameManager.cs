using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Boolean to check if the game ended
    bool GameHasEnded = false;

    //Keeps track of Player1's score
    public static float scorePlayer1 = 0f;

    //Keeps track of Player2's score
    public static float scorePlayer2 = 0f;

    //Keeps track of who scored the last point
    public static float lastPoint = 1f;

    //Delay before starting another round
    public float restartDelay = 0.5f;

    //Reference to screen that shows when Player1 wins
    public GameObject player1WinUI;

    //Reference to screen that shows when Player2 wins
    public GameObject player2WinUI;

    //Reference to the Ball
    public GameObject Ball;

    public void Update()
    {

        //=======================================================================================================
        //Handles win conditions

        //If Player1 has 5 points
        if (scorePlayer1 == 5f)
        {
            //Show the Player1 win screen
            player1WinUI.SetActive(true);
            //Disable the ball
            Ball.SetActive(false);

        }
        //If Player2 has 5 points
        if (scorePlayer2 == 5f)
        {
            //Show the Player2 win screen
            player2WinUI.SetActive(true);
            //Disable the ball
            Ball.SetActive(false);
        }

        //=======================================================================================================
        //Handles restarting the game


        //If the player presses space
        if (Input.GetKey(KeyCode.Space))
        {
            //Reset the scores and restart the game
            scorePlayer1 = 0f;
            scorePlayer2 = 0f;
            lastPoint = 1f;
            Restart();
        }
    }


    //=======================================================================================================
    //Handles ending the round
    public void EndRound()
    {
        //End the game
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            //Restart the game after a delay
            Invoke(nameof(Restart), restartDelay);
        }
    }

    void Restart()
    {
        //Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //=======================================================================================================
}
