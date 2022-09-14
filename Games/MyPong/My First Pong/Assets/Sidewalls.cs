using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidewalls : MonoBehaviour
{
    //Function will detect when something collides with left/right walls. If its the ball, call score method and reset ball.
    private void OnTriggerEnter2D(Collider2D collisionEnd)
    {
        if(collisionEnd.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            collisionEnd.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
