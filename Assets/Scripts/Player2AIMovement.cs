using UnityEngine;

public class Player2AIMovement : MonoBehaviour
{
    //Movement speed of the AI
    public float movementSpeed = 15f;

    //Reference to the BallMovement script
    private BallMovement ballMovement;

    //Random number to determine if the AI should stop moving
    private int randnum;

    //Timer to keep track of how long the AI should stop moving
    private float timer;

    void Start()
    {
        //Find the Ball object and get the BallMovement script
        GameObject ballObject = GameObject.Find("Ball");
        if (ballObject != null)
        {
            ballMovement = ballObject.GetComponent<BallMovement>();
        }
    }

    void FixedUpdate()
    {
        //=======================================================================================================
        //Handles AI movement


        //If the ball is moving towards the AI
        if (ballMovement.movementSpeed > 0)
        {
            //Generate a random number
            randnum = Random.Range(0, 100);
            //If the random number is divisible by 9, stop moving for 60 frames
            if (randnum % 9 == 0)
            {
                while (timer <= 60f)
                {
                    timer += 1 * Time.deltaTime;
                    movementSpeed = 0f;
                }
            }

            //Otherwise, move normally
            else
            {
                if (timer >= 60f)
                {
                    timer = 0f;
                }
                movementSpeed = 15f;
            }

            //If the ball is above the AI, move up
            if (ballMovement.transform.position.y > transform.position.y)
            {
                //If the AI is not at the top of the screen, move up
                if (transform.position.y <= 26)
                {
                    transform.position = transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
                }
            }

            //If the ball is below the AI, move down
            if (ballMovement.transform.position.y < transform.position.y)
            {
                //If the AI is not at the bottom of the screen, move down
                if (transform.position.y >= -26)
                {
                    transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
                }
            }
        }

        //If the ball has hit each paddle at least once, increase the movement speed
        if (ballMovement.hitCounter == 2)
        {
            movementSpeed += 2f;
        }


        //=======================================================================================================
    }
}
