using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    //Movement speed of the player
    public float movementSpeed = 15f;

    //Reference to the BallMovement script
    private BallMovement ballMovement;
    void Start()
    {
        //Find the Ball object and get the BallMovement script
        GameObject ballObject = GameObject.Find("Ball");
        if (ballObject != null)
        {
            ballMovement = ballObject.GetComponent<BallMovement>();
        }
    }

    void Update()
    {
        //=======================================================================================================
        //Handles Player2 movement on keyboard inputs


        //If the up arrow is pressed, move up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //If the player is not at the top of the screen, move up
            if (transform.position.y <= 26)
            {
                transform.position = transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }

        //If the down arrow is pressed, move down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //If the player is not at the bottom of the screen, move down
            if (transform.position.y >= -26)
            {
                transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
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
