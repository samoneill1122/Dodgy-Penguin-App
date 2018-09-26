using UnityEngine;
using System.Collections;

public class SnowballCol : MonoBehaviour {

	public static int count;
    public float countDown = 0.25f;
    public float countDownReset = 0.25f;
    bool collide = false;
    bool collide1 = false;
    bool collide2 = false;
    bool dealtWith;
    bool gotHit;

    public GameObject penguin;
    Animator anim;

    int playerLayer, walrusLayer, snowballLayer, lifeLayer;

    Collider2D[] myColls;

    void Start()
	{
        penguin = GameObject.Find("Penguin");

        if (gameObject.name == "Penguin")
        {
            count = 0;
        }

        dealtWith = false;

        playerLayer = LayerMask.NameToLayer("Player");
        walrusLayer = LayerMask.NameToLayer("Enemy");
        snowballLayer = LayerMask.NameToLayer("Snowball");
        lifeLayer = LayerMask.NameToLayer("Life");
        Physics2D.IgnoreLayerCollision(playerLayer, walrusLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, snowballLayer, false);
        Physics2D.IgnoreLayerCollision(walrusLayer, snowballLayer);
        Physics2D.IgnoreLayerCollision(walrusLayer, lifeLayer);
        myColls = penguin.GetComponents<Collider2D>();
        gotHit = false;
    }

    void Update()
    {
        if(collide == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                anim.SetInteger("State", 0);
                collide = false;
                countDown = countDownReset;
            }
        }
        if (collide1 == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                anim.SetInteger("GotLife", 0);
                collide1 = false;
                countDown = countDownReset;
            }
        }
        if (collide2 == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                anim.SetInteger("State", 1);
                collide2 = false;
                countDown = countDownReset;
            }
        }
    }

	void OnCollisionEnter2D (Collision2D col)
	{
        anim = penguin.GetComponent<Animator>();
        if (col.gameObject.tag.Equals("Snowball"))
		{
			if(gameObject.name == "Penguin")
			{
                if (penguin.GetComponent<Transform>().position.y < -1.7)
                {
                    penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                }
                Destroy(col.gameObject);
                GM.health--;
                anim.SetInteger("State", 1);
                collide = true;
                Hurt(1f);
            }
			if(gameObject.name == "SnowGround" || gameObject.tag.Equals("Walrus"))
			{
				count++;
                Destroy(col.gameObject);
            }
            if(gameObject.tag.Equals("Walrus"))
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                if (gameObject.name == "LeftWalrus")
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f);
                }
                if (gameObject.name == "RightWalrus")
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
                }
                Destroy(col.gameObject);
            } 
        }
        if (col.gameObject.tag.Equals("Life"))
        {   
            if(gameObject.tag.Equals("Walrus"))
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Destroy(col.gameObject);
            }
            if (gameObject.name == "Penguin")
            {
                GM.health++;
                anim.SetInteger("GotLife", 1);
                collide1 = true;
                if (penguin.GetComponent<Transform>().position.y < -1.7)
                {
                    penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
                penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Destroy(col.gameObject);
            }
            if(gameObject.name == "SnowGround")
            {
                Destroy(col.gameObject);
            }
        }
         if(col.gameObject.tag.Equals("Walrus"))
         {
            if(gameObject.name == "Penguin")
            {
                dealtWith = false;
                Debug.Log("Walrus collided with penguin");
                while (dealtWith == false)
                {
                    foreach (ContactPoint2D point in col.contacts)
                    {
                        Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                        if (point.normal.y < 0.9f)
                        {
                            gotHit = true;
                            anim.SetInteger("State", 1);
                            collide = true;
                            dealtWith = true;
                            Hurt(1f);
                        }
                        else
                        {
                            dealtWith = true;
                        }
                    }
                }
                if(gotHit == true)
                {
                    GM.health--;
                    gotHit = false;
                }
                penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Destroy(col.gameObject);
                GM.walrusCount--;
                Debug.Log("Walrus count is " + GM.walrusCount);

            } 
            if(gameObject.tag.Equals("Sky"))
            {
                Destroy(col.gameObject);
                GM.walrusCount--;
                Debug.Log("Walrus count is " + GM.walrusCount);
            }
            if(gameObject.name == "SnowGround")
            {
                if (col.gameObject.GetComponent<Transform>().position.x > 0)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f);
                }
                if (col.gameObject.GetComponent<Transform>().position.x < 0)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
                }
            }
        } 
        if (col.gameObject.name == "Penguin" && gameObject.name == "SnowGround")
        {
            penguin.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    void Hurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        // Ignore collision with snowballs and walruses
        Physics2D.IgnoreLayerCollision(playerLayer, walrusLayer);
        Physics2D.IgnoreLayerCollision(playerLayer, snowballLayer);
        // Play blinking animation
        anim.SetLayerWeight(1, 1);
        // Wait for invincibility to end
        yield return new WaitForSeconds(hurtTime);
        // Stop invincibility and animation
        Physics2D.IgnoreLayerCollision(playerLayer, walrusLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, snowballLayer, false);
        anim.SetLayerWeight(1, 0);
    }

}


