using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
   
	public float speed = 30;
	
	private Rigidbody2D rigidBody;
	
	private AudioSource sound;
	
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
		//If you want to move in a X,Y position (Vector2 is used for only X axis movement)
		rigidBody.velocity = Vector2.right * speed;
		
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		//Left Paddle or Right Paddle
		if((col.gameObject.name == "Paddle - User") ||(col.gameObject.name == "Paddle - AI"))
		{
			handlePaddleHit(col);
		}
		 
		//Wall top/bottom
		if((col.gameObject.name == "HorzWall - Top") ||(col.gameObject.name == "HorzWall - Bottom"))
		{
			soundManager.instance.PlayOneShot(soundManager.instance.hitPaddleBloop);
		}
		//Left/Right Wall (Goal)
		if((col.gameObject.name == "LeftWall") ||(col.gameObject.name == "RightWall"))
		{
	    soundManager.instance.PlayOneShot(soundManager.instance.goalBloop);
		//TODO Update Score UI
		
		//Move position of the ball
		transform.position = new Vector2(0,0);
		
		}
	}

	void handlePaddleHit(Collision2D col)
	{
		//transform.position - talks about the name of the Class
		//col.transform.position - position on the screen where ever the class collided with
		//col.collider.bounds.size.y is the height of the paddle
		//Width of the paddle is size x
		float y = ballHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);
		//direction of the ball
		Vector2 dir = new Vector2();
		
		if(col.gameObject.name == "Paddle - User"){
			dir = new Vector2(1,y).normalized;
		}
		
		if(col.gameObject.name == "Paddle - AI"){
			dir = new Vector2(-1,y).normalized;
		}
		 
		rigidBody.velocity = dir * speed; 
		
		soundManager.instance.PlayOneShot(soundManager.instance.hitPaddleBloop);
		
	}   

    float ballHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
	{
		//Y direction
		return (ball.y - paddle.y) / paddleHeight;
	}
}
