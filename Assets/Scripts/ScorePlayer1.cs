using UnityEngine;
using TMPro;

public class ScorePlayer1 : MonoBehaviour
{

    public TMP_Text ScoreText1;

    // Update is called once per frame
    void Update()
    {
        ScoreText1.text = GameManager.scorePlayer1.ToString();
    }
}
