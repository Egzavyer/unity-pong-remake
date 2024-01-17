using UnityEngine;
using TMPro;

public class ScorePlayer2 : MonoBehaviour
{

    //Reference to the Player2's Score UI component
    public TMP_Text ScoreText2;

    void Update()
    {
        //Update the Player2's score UI
        ScoreText2.text = GameManager.scorePlayer2.ToString();

    }
}