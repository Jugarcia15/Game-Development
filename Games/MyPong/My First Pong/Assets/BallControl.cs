using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //variables
    private Rigidbody2D rb2d;

    //need the ball to go a random direction at the beginning of the game.
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        //if randomized number is less than 1, force is applied to the ball to go right/positive direction.
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        } else // otherwise, force applied is to the left/negative.
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //initialize our rigidbody variable, and call our goball function. Invoke will allow to wiat 2 seconds before ball starts moving.
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    //Function to reset the ball after scoring/win condition is met.
    void ResetBall()
    {
        //Stops the ball
        rb2d.velocity = new Vector2(0,0);
        //reset ball position to the center
        transform.position = Vector2.zero;
    }

    // We need a function to restart the game when a restart button is pushed.
    void RestartGame()
    {
        ResetBall();
        Invoke ("GoBall", 1);
    }

    //Now we need a function that adjust the velocity based on the speed of the ball and the paddle.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

}
