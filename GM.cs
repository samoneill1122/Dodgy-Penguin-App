using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public GameObject snowball;
    public GameObject life;
    public GameObject penguin;
    public GameObject walrusLeft;
    public GameObject walrusRight;
    public GameObject LoadingText;

    float nextSpawn;
    float countdown;
    float countdown2 = 10f;
    Vector3 location, locationWalrus;
    float randX, randX1, randX2;
    int randChoice;
    int rand, rand2;
    bool spawnSpeedChanged, spawnSpeedChanged1, spawnSpeedChanged2, spawnSpeedChanged3, spawnSpeedChanged4,
        spawnSpeedChanged5, spawnSpeedChanged6;

    public GameObject heart1, heart2, heart3;
    public static int health;

    GameObject[] destroyAll;

    public Movement playerMovement;
    public GameObject gameScene;

    int highScore;

    public static int walrusCount;

    void Start()
    {
        health = 3;
        countdown = 0f;
        countdown2 = 10f;
        snowball.transform.localScale = new Vector3(4f, 4f, 0f);
        snowball.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
        walrusCount = 0;
        nextSpawn = 2f;
        countdown = 2f;
        spawnSpeedChanged = false;
        spawnSpeedChanged1 = false;
        spawnSpeedChanged2 = false;
        spawnSpeedChanged3 = false;
        spawnSpeedChanged4 = false;
        spawnSpeedChanged5 = false;
        spawnSpeedChanged6 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (penguin.GetComponent<Transform>().eulerAngles != new Vector3(0f, 0f, 0f))
        {
            penguin.GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (SnowballCol.count >= 10)
        {
            snowball.transform.localScale = new Vector3(4.2f, 4.2f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
            if(spawnSpeedChanged == false && countdown < 0)
            {
                nextSpawn = 1.7f;
                countdown = 1.7f;
                spawnSpeedChanged = true;
            }
        }
        if (SnowballCol.count >= 20)
        {
            snowball.transform.localScale = new Vector3(4.2f, 4.2f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 0.9f;
            if (spawnSpeedChanged1 == false && countdown < 0)
            {
                nextSpawn = 1.5f;
                countdown = 1.5f;
                spawnSpeedChanged1 = true;
            }
        }
        if (SnowballCol.count >= 40)
        {
            snowball.transform.localScale = new Vector3(4.4f, 4.4f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            if (spawnSpeedChanged2 == false && countdown < 0)
            {
                nextSpawn = 1.2f;
                countdown = 1.2f;
                spawnSpeedChanged2 = true;
            }
        }
        if (SnowballCol.count >= 50)
        {
            snowball.transform.localScale = new Vector3(4.6f, 4.6f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.1f;
            if (spawnSpeedChanged3 == false && countdown < 0)
            {
                nextSpawn = 1f;
                countdown = 1f;
                spawnSpeedChanged3 = true;
            }
        }
        if (SnowballCol.count >= 60)
        {
            snowball.transform.localScale = new Vector3(4.8f, 4.8f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.2f;
            if (spawnSpeedChanged5 == false && countdown < 0)
            {
                nextSpawn = 0.9f;
                countdown = 0.9f;
                spawnSpeedChanged5 = true;
            }
        }
        if (SnowballCol.count >= 70)
        {
            snowball.transform.localScale = new Vector3(5.0f, 5.0f, 0f);
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.3f;
            if (spawnSpeedChanged5 == false && countdown < 0)
            {
                nextSpawn = 0.8f;
                countdown = 0.8f;
                spawnSpeedChanged5 = true;
            }
        }
        if (SnowballCol.count >= 80)
        {
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.4f;
        }
        if (SnowballCol.count >= 90)
        {
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.6f;
        }
        if (SnowballCol.count >= 100)
        {
            snowball.GetComponent<Rigidbody2D>().gravityScale = 1.8f;
            if (spawnSpeedChanged5 == false && countdown < 0)
            {
                nextSpawn = 0.7f;
                countdown = 0.7f;
                spawnSpeedChanged5 = true;
            }
        }
        if (SnowballCol.count >= 120)
        {
            snowball.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

        countdown -= Time.deltaTime;
        countdown2 -= Time.deltaTime;
        if (countdown <= 0)
        {
            rand = Random.Range(1, 30);
            if (rand != 1 && rand != 2 && rand != 3 && rand != 4)
            {
                SpawnSnowball();
            }
            else if (rand == 1)
            {
                if (SnowballCol.count > 10 && countdown2 <= 0)
                {
                    SpawnLife();
                    countdown2 = 10f;
                }
                else
                {
                    SpawnSnowball();
                }
            }
            else if ((rand == 2 || rand == 3 || rand == 4))
            {
                if (walrusCount == 0)
                {
                    if (SnowballCol.count > 15)
                    {
                        SpawnWalrus();
                        walrusCount++;
                        Debug.Log("Walrus Count is " + walrusCount);
                    }
                    else
                    {
                        SpawnSnowball();
                    }
                }
                else
                {
                    SpawnSnowball();
                }
            }
            countdown = nextSpawn;
        }

        if (health > 3)
        {
            health = 3;
        }
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                destroyAll = GameObject.FindGameObjectsWithTag("Snowball");
                for (int i = 0; i < destroyAll.Length; i++)
                {
                    Destroy(destroyAll[i].gameObject);
                }
                playerMovement.enabled = false;
                penguin.SetActive(false);
                if (Score.originalHighScore < PlayerPrefs.GetInt("HighScore"))
                {
                    Leaderboard.AddNewHighScore(PlayerPrefs.GetString("SaveName", ""), PlayerPrefs.GetInt("HighScore", 0));
                    LoadingText.SetActive(true);
                    SceneManager.LoadScene("GameOver");
                    break;
                }
                else
                {
                    SceneManager.LoadScene("GameOver");
                    break;
                }
        }

    }

    void SpawnSnowball()
    {
        if (SnowballCol.count < 2)
        {
            randX1 = Random.Range(-2.7f, -2f);
            randX2 = Random.Range(2f, 2.7f);
            randChoice = Random.Range(0, 2);
            if (randChoice == 0)
            {
                location = new Vector3(randX1, transform.position.y, 0f);
                Instantiate(snowball, location, Quaternion.identity);
            }
            else if (randChoice == 1)
            {
                location = new Vector3(randX2, transform.position.y, 0f);
                Instantiate(snowball, location, Quaternion.identity);
            }
        }
        else
        {
            randX = Random.Range(-2.7f, 2.7f);
            location = new Vector3(randX, transform.position.y, 0);
            Instantiate(snowball, location, Quaternion.identity);
        }
    }

    void SpawnLife()
    {
        randX = Random.Range(-2.7f, 2.7f);
        location = new Vector3(randX, transform.position.y, 0f);
        Instantiate(life, location, Quaternion.identity);
    }

    void SpawnWalrus()
    {
        if (penguin.transform.position.x <= 0)
        {
            locationWalrus = new Vector3(2.2f, transform.position.y, 0f);
            GameObject walrusInstance = Instantiate(walrusLeft, locationWalrus, Quaternion.identity) as GameObject;
            walrusInstance.name = "LeftWalrus";
        }
        if (penguin.transform.position.x > 0)
        {
            locationWalrus = new Vector3(-2.2f, transform.position.y, 0f);
            GameObject walrusInstance = Instantiate(walrusRight, locationWalrus, Quaternion.identity) as GameObject;
            walrusInstance.name = "RightWalrus";
        }
    }

}


