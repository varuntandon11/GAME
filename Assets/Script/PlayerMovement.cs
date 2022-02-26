using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public float forwardForce = 1000f;
    public float sideWaysForce = 500f;

    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(0, 0, forwardForce * Time.deltaTime,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(0, 0, -forwardForce * Time.deltaTime,ForceMode.VelocityChange);
        }
        player.AddForce(sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        

        if (this.transform.position.y <= 0)
        {
            this.enabled = false;
            FindObjectOfType<GameManager>().setIsGameEnded(true);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            this.enabled = false;
            FindObjectOfType<GameManager>().setIsGameEnded(true);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
