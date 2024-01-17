using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float movementSpeed = 15f;
    private BallMovement ballMovement;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ballObject = GameObject.Find("Ball");
        if (ballObject != null)
        {
            ballMovement = ballObject.GetComponent<BallMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 26)
            {
                transform.position = transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y >= -26)
            {
                transform.position = transform.position + new Vector3(0, -movementSpeed * Time.deltaTime, 0);
            }
        }
        if (ballMovement.hitCounter == 2)
        {
            movementSpeed += 2f;
        }

    }
}
