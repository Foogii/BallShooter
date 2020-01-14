using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool roundEnd = false;
    public bool isGameOver = false;
    public int numOfBoxes;
    public int numOfBallIncrease;

    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;

    public Transform corner1;
    public Transform corner2;

    public LayerMask whatIsBox;
    public LayerMask whatIsBallIncrease;
    public LayerMask whatIsBall;
    public LayerMask whatIsSpawner;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        roundEnd = false;

        if (PlayerPrefs.GetInt("Round") > 1)
        {
            currentRound.round = PlayerPrefs.GetInt("Round");
            numOfBoxes = PlayerPrefs.GetInt("numOfBoxes");
            numOfBallIncrease = PlayerPrefs.GetInt("numOfBallIncrease");
            PlayerController.numberOfBalls = PlayerPrefs.GetInt("NumOfBalls");

            for (int i = 0; i < numOfBoxes; i++)
            {
                Vector2 boxPosition = new Vector2(PlayerPrefs.GetFloat("boxX" + i.ToString()), PlayerPrefs.GetFloat("boxY" + i.ToString()));
                GameObject box = (GameObject)Instantiate(boxPrefab, boxPosition, Quaternion.identity);
                box.GetComponent<BoxObject>().health = PlayerPrefs.GetInt("boxHP" + i.ToString());
            }

            for (int i = 0; i < numOfBallIncrease; i++)
            {
                Vector2 ballIncreasePos = new Vector2(PlayerPrefs.GetFloat("ballX" + i.ToString()), PlayerPrefs.GetFloat("ballY" + i.ToString()));
                GameObject ballIncrease = (GameObject)Instantiate(ballIncreasePrefab, ballIncreasePos, Quaternion.identity);
            }

        }
        else
        {
            roundEnd = true;
            roundDone();
            roundEnd = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] balls = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBall);

        if (roundEnd == true && isGameOver == false)
        {
            if (balls.Length == 0)
            {
                roundDone();

                if (BoxObject.spawnersChecked == 7)
                {
                    currentRound.round++;
                    PlayerPrefs.SetInt("Round", currentRound.round);
                    roundEnd = false;
                    BoxObject.spawnersChecked = 0;
                }
            }
        }
    }

    void gameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);

            PlayerPrefs.DeleteKey("NumOfBalls");

            for (int i = 0; i > numOfBoxes; i++)
            {
                PlayerPrefs.DeleteKey("boxX" + i.ToString());
                PlayerPrefs.DeleteKey("boxY" + i.ToString());
            }

            PlayerPrefs.DeleteKey("Round");
            PlayerPrefs.DeleteKey("numOfBoxes");

            currentRound.round = PlayerPrefs.GetInt("Round");
        }
    }

    public void roundDone()
    {
        if (roundEnd == true && isGameOver == false)
        {
            Collider2D[] spawners = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsSpawner);
            for (int i = 0; i < spawners.Length; i++)
                spawners[i].GetComponent<Spawner>().spawner();

            Collider2D[] boxes = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBox);
            Collider2D[] ballIncrease = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBallIncrease);

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].GetComponent<BoxObject>().moveDown();

                PlayerPrefs.SetFloat("boxX" + i.ToString(), boxes[i].transform.position.x);
                PlayerPrefs.SetFloat("boxY" + i.ToString(), boxes[i].transform.position.y);
                PlayerPrefs.SetInt("boxHP" + i.ToString(), boxes[i].gameObject.GetComponent<BoxObject>().health);
            }

            for (int i = 0; i < ballIncrease.Length; i++)
            {
                ballIncrease[i].GetComponent<Ball_Increase>().moveDown();
                PlayerPrefs.SetFloat("ballX" + i.ToString(), ballIncrease[i].transform.position.x);
                PlayerPrefs.SetFloat("ballY" + i.ToString(), ballIncrease[i].transform.position.y);
            }

            for (int i = 0; i < boxes.Length; i++)
                if (boxes[i].transform.position.y <= -2.3)
                {
                    gameOver();
                }

            for (int i = 0; i < ballIncrease.Length; i++)
                if (ballIncrease[i].transform.position.y <= -2.3)
                {
                    Destroy(ballIncrease[i].gameObject);
                }

            PlayerPrefs.SetInt("numOfBoxes", boxes.Length);
            PlayerPrefs.SetInt("numOfBallIncrease", ballIncrease.Length);
            PlayerPrefs.SetInt("NumOfBalls", PlayerController.numberOfBalls);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
