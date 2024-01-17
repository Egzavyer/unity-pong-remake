using UnityEngine;

public class Player2AIMovement : MonoBehaviour
{
    public float movementSpeed = 15f;
    private BallMovement ballMovement;
    private int randnum;
    private float timer;

    void Start()
    {
        GameObject ballObject = GameObject.Find("Ball");
        if (ballObject != null)
        {
            ballMovement = ballObject.GetComponent<BallMovement>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ballMovement.movementSpeed > 0)
        {
            randnum = Random.Range(0, 100);
            if (randnum % 9 == 0)
            {
                while (timer <= 60f)
                {
                    timer += 1 * Time.deltaTime;
                    movementSpeed = 0f;
                }
            }
            else
            {
                if (timer >= 60f)
                {
                    timer = 0f;
                }
                movementSpeed = 15f;
            }

            if (ballMovement.transform.position.y > transform.position.y)
            {
                if (transform.position.y <= 26)
                {
                    transform.position = transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
                }
            }
            if (ballMovement.transform.position.y < transform.position.y)
            {
                if (transform.position.y >= -26)
                {
                    transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
                }
            }
        }
        if (ballMovement.hitCounter == 2)
        {
            movementSpeed += 2f;
        }

    }
}
