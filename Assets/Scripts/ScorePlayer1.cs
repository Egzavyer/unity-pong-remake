using UnityEngine;
using TMPro;

public class ScorePlayer1 : MonoBehaviour
{

    //Reference to the Player1's Score UI component
    public TMP_Text ScoreText1;

    void Update()
    {
        //Update the Player1's score UI
        ScoreText1.text = GameManager.scorePlayer1.ToString();
    }
}
