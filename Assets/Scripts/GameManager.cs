using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool roundEnd = false;
    public bool isGameOver = false;

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
        roundEnd = true;
        roundDone();
        roundEnd = false;
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
                    roundEnd = false;
                    currentRound.round++;
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
                boxes[i].GetComponent<BoxObject>().moveDown();

            for (int i = 0; i < ballIncrease.Length; i++)
                ballIncrease[i].GetComponent<Ball_Increase>().moveDown();

            for (int i = 0; i < boxes.Length; i++)
                if (boxes[i].transform.position.y <= -1)
                {
                    gameOver();
                }

            for (int i = 0; i < ballIncrease.Length; i++)
                if (ballIncrease[i].transform.position.y <= -1)
                {
                    Destroy(gameObject);
                }
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
