using UnityEngine;
using TMPro;

public class ScorePlayer2 : MonoBehaviour
{

    public TMP_Text ScoreText2;

    // Update is called once per frame
    void Update()
    {
        ScoreText2.text = GameManager.scorePlayer2.ToString();

    }
}