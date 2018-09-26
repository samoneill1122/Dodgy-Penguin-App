using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {
	// Creating a Rigidbody2D object
	private Rigidbody2D rb2d;
	public float speed;
    bool isPressed;
    bool rightPressed;
    bool leftPressed;
    public float jumpHeight = 15f;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
        isPressed = false;
        rightPressed = false;
        leftPressed = false;
    }

    // Has to be 'Fixed' because we're messing with physics
    void FixedUpdate()
	{
        if (rightPressed == true)
        {
            RightArrow();
        }
        if(leftPressed == true)
        {
            LeftArrow();
        }
	}

    public void LeftPressed()
    {
        leftPressed = true;
    }

    public void LeftNotPressed()
    {
        leftPressed = false;
    }

    public void RightPressed()
    {
        rightPressed = true;
    }

    public void RightNotPressed()
    {
        rightPressed = false;
    }

    public void LeftArrow()
    {
            Vector2 movementLeft = new Vector2(-1, 0);
            rb2d.AddForce(movementLeft * speed, ForceMode2D.Force);
    }

    public void RightArrow()
    {
            Vector2 movementRight = new Vector2(1, 0);
            rb2d.AddForce(movementRight * speed, ForceMode2D.Force);
    }

    public void Jump()
    {
        if(gameObject.GetComponent<Transform>().position.y <= -1.72)
        {
            rb2d.velocity = new Vector2(0f, jumpHeight);
        }
    }

}
