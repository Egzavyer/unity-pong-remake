using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //The ball's rigidbody
    private Rigidbody2D rb;

    // The direction in which the ball is going
    private Vector2 direction;

    //The speed at which the ball is moving in the X-Axis
    public float movementSpeed = 1000f;

    //Randomly generated float for the angle 
    private float randnum;

    //Reference to the GameManager object
    public GameManager gameManager;

    //Boolean expression to determine if score has already been updated
    private bool updateScore = true;

    //Counter for the amound of times the ball collides with a paddle
    public float hitCounter = 0f;

    void Start()
    {
        //Get a random starting value for the Y direction (angle)
        randnum = Random.Range(500.0f, -500.0f);

        //If Player1 got the last point
        if (GameManager.lastPoint == 1f)
        {
            //Ball goes towards Player1 at the beginning of the round
            movementSpeed = -movementSpeed;
            //Init a new direction vector
            direction = new Vector2(movementSpeed, randnum);
        }
        //If Player2 got the last point
        if (GameManager.lastPoint == 2f)
        {
            //Ball goes towards Player1 at the beginning of the round
            direction = new Vector2(movementSpeed, randnum);
        }
    }

    void FixedUpdate()
    {
        //=======================================================================================================
        //Handle ball movement


        //Get the Rigidbody2D of the ball
        rb = GetComponent<Rigidbody2D>();
        //Prevent the ball from rotating
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Update the movement of the ball at a fixed rate (independent of fps)
        rb.velocity = direction * Time.deltaTime;


        //=======================================================================================================
        //Handles ball's gradual acceleration


        //If the ball has hit both paddles at least once
        if (hitCounter == 2)
        {
            //Add or subtract 250 to the movement speed of the ball depending on the direction
            if (movementSpeed > 0)
            {
                movementSpeed += 250f;
            }
            if (movementSpeed < 0)
            {
                movementSpeed -= 250f;
            }
            hitCounter = 0f;
        }


        //=======================================================================================================
        //Handles keeping score


        //If the ball goes past Player2
        if (transform.position.x >= 30f)
        {
            //If the score hasn't yet been updated this round
            if (updateScore)
            {
                updateScore = false;
                //Disable the ball
                GetComponent<SpriteRenderer>().enabled = false;
                //Give Player1 a point
                GameManager.scorePlayer1 += 1;
                //Set the last point to Player1
                GameManager.lastPoint = 1f;
                //Call the GameManager's EndRound() function to end the round
                FindObjectOfType<GameManager>().EndRound();
            }
        }
        //If the ball goes past Player1
        if (transform.position.x <= -30f)
        {
            //If the score hasn't yet been updated this round
            if (updateScore)
            {
                updateScore = false;
                //Disable the ball
                GetComponent<SpriteRenderer>().enabled = false;
                //Give Player2 a point
                GameManager.scorePlayer2 += 1;
                //Set the last point to Player2
                GameManager.lastPoint = 2f;
                //Call the GameManager's EndRound() function to end the round
                FindObjectOfType<GameManager>().EndRound();
            }
        }


        //=======================================================================================================
    }

    //=======================================================================================================
    //Handles the Ball's behaviour when it has a collision


    void OnCollisionEnter2D(Collision2D collision)
    {
        //If ball hits a player
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            //Set the angle to a new random one
            randnum = Random.Range(500.0f, -500.0f);
            //Set the movement speed to the other direction
            movementSpeed = -movementSpeed;
            //Init a new Vector2 with the new values
            direction = new Vector2(movementSpeed, randnum);
            //Increment Counter
            hitCounter += 1f;
        }
        //If ball hits a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Reverse the angle
            direction = new Vector2(movementSpeed, -randnum);
        }
    }


    //=======================================================================================================

}
