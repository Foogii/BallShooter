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
    public int numOfCoins;
    public int numOfECoins;

    public int clearUses;

    public int coinsNum;
    public int eCoinsNum = 0;

    public int score;
    public int highscore;

    public GameObject boxPrefab;
    public GameObject ballIncreasePrefab;
    public GameObject coinPrefab;
    public GameObject ECoinPrefab;

    public Transform corner1;
    public Transform corner2;
    public Transform corner3;

    public LayerMask whatIsBox;
    public LayerMask whatIsBallIncrease;
    public LayerMask whatIsBall;
    public LayerMask whatIsSpawner;
    public LayerMask whatIsCoin;
    public LayerMask whatIsECoin;

    public GameObject gameOverPanel;
    public GameObject DangerZone;

    float timeUntilSpeedup = 7f;
    float timeUntilDownwardForce = 12f;

    public bool gameContinued = true;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Round"))
        {
            currentRound.round = 0;
            PlayerPrefs.SetInt("Round", currentRound.round);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameContinued = true;
        roundEnd = false;
        eCoinsNum = PlayerPrefs.GetInt("eCoins");
        highscore = PlayerPrefs.GetInt("HighScore");
        if (PlayerPrefs.GetInt("Round") > 1)
        {
            numOfBoxes = PlayerPrefs.GetInt("numOfBoxes");
            numOfBallIncrease = PlayerPrefs.GetInt("numOfBallIncrease");
            PlayerController.numberOfBalls = PlayerPrefs.GetInt("NumOfBalls");
            score = PlayerPrefs.GetInt("Score");
            coinsNum = PlayerPrefs.GetInt("Coins");

            numOfCoins = PlayerPrefs.GetInt("numOfCoins");
            numOfECoins = PlayerPrefs.GetInt("numOfECoins");
            clearUses = PlayerPrefs.GetInt("Clears");

            for (int i = 0; i < numOfBoxes; i++) //Sets the position for each box that was saved
            {
                Vector2 boxPosition = new Vector2(PlayerPrefs.GetFloat("boxX" + i.ToString()), PlayerPrefs.GetFloat("boxY" + i.ToString()));
                GameObject box = (GameObject)Instantiate(boxPrefab, boxPosition, Quaternion.identity);
                box.GetComponent<BoxObject>().health = PlayerPrefs.GetInt("boxHP" + i.ToString());
            }

            for (int i = 0; i < numOfBallIncrease; i++) //Sets the position for each ball increasing object that was saved
            {
                Vector2 ballIncreasePos = new Vector2(PlayerPrefs.GetFloat("ballX" + i.ToString()), PlayerPrefs.GetFloat("ballY" + i.ToString()));
                GameObject ballIncrease = (GameObject)Instantiate(ballIncreasePrefab, ballIncreasePos, Quaternion.identity);
            }

            for (int i = 0; i < numOfCoins; i++) //Sets the position for each coin object that was saved
            {
                Vector2 CoinPos = new Vector2(PlayerPrefs.GetFloat("coinX" + i.ToString()), PlayerPrefs.GetFloat("coinY" + i.ToString()));
                GameObject Coin = (GameObject)Instantiate(coinPrefab, CoinPos, Quaternion.identity);
            }

            for (int i = 0; i < numOfECoins; i++) //Sets the position for each E-Coin object that was saved
            {
                Vector2 CoinPos = new Vector2(PlayerPrefs.GetFloat("eCoinX" + i.ToString()), PlayerPrefs.GetFloat("eCoinY" + i.ToString()));
                GameObject Coin = (GameObject)Instantiate(ECoinPrefab, CoinPos, Quaternion.identity);
            }

        }
        else
        {
            clearUses = 3;
            PlayerPrefs.SetInt("Clears", clearUses);
            roundEnd = true;
            roundDone();
            roundEnd = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] balls = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBall);

        PlayerPrefs.SetInt("Coins", coinsNum);
        PlayerPrefs.SetInt("eCoins", eCoinsNum);

        PlayerPrefs.SetInt("Score", score);

        if (score >= highscore)
            highscore = score;

        PlayerPrefs.SetInt("HighScore", highscore);

        toggleDangerZone();
        
        if (roundEnd == true && isGameOver == false)
        {
            if (balls.Length == 0 && PlayerController.currNumBall <= 1)
            {
                timeUntilSpeedup = 7f;
                timeUntilDownwardForce = 6f;
                roundDone();

                if (BoxObject.spawnersChecked == 7)
                {
                    roundEnd = false;
                    BoxObject.spawnersChecked = 0;
                }
            }
        }

        if(balls.Length > 0)
        {
            if (timeUntilSpeedup <= 0)
            {
                Time.timeScale += 1;
                timeUntilSpeedup = 7f;
            }
            else
            {
                timeUntilSpeedup -= Time.deltaTime;
            }

            if(timeUntilDownwardForce <= 0)
            {
                for(int i = 0; i < balls.Length; i++)
                {
                    balls[i].transform.rotation = new Quaternion(balls[i].transform.rotation.x, balls[i].transform.rotation.y, balls[i].transform.rotation.z + 1, transform.rotation.w);
                    balls[i].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50);
                }
                timeUntilDownwardForce = 6f;
            }
            else
            {
                timeUntilDownwardForce -= Time.deltaTime;
            }
        }
    }

    void gameOver()
    {
        gameOverPanel.SetActive(true);
        gameContinued = false;

        if (isGameOver == true)
        {
            PlayerPrefs.DeleteKey("NumOfBalls");

            for (int i = 0; i > numOfBoxes; i++)
            {
                PlayerPrefs.DeleteKey("boxX" + i.ToString());
                PlayerPrefs.DeleteKey("boxY" + i.ToString());
            }

            PlayerPrefs.DeleteKey("Round");
            PlayerPrefs.DeleteKey("numOfBoxes");
            PlayerPrefs.DeleteKey("Coins");
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Clears");

            PlayerPrefs.DeleteKey("BallDropRate");
            PlayerPrefs.DeleteKey("CoinDropRate");
            PlayerPrefs.DeleteKey("eCoinDropRate");
            PlayerPrefs.DeleteKey("BallDamage");
            PlayerPrefs.DeleteKey("ScoreMultiplier");
            PlayerPrefs.DeleteKey("bouncyIsPurchased");
        }
    }

    public void roundDone() //Notes that the round has ended, and saves the locations of every block, ball, and coin
    {
        if (roundEnd == true && isGameOver == false)
        {
            Collider2D[] spawners = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsSpawner);
            for (int i = 0; i < spawners.Length; i++)
                spawners[i].GetComponent<Spawner>().spawner();

            Collider2D[] boxes = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBox);
            Collider2D[] ballIncrease = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsBallIncrease);
            Collider2D[] coins = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsCoin);
            Collider2D[] eCoins = Physics2D.OverlapAreaAll(corner1.position, corner2.position, whatIsECoin);

            for (int i = 0; i < boxes.Length; i++) //Saves the blocks
            {
                boxes[i].GetComponent<BoxObject>().moveDown();

                PlayerPrefs.SetFloat("boxX" + i.ToString(), boxes[i].transform.position.x);
                PlayerPrefs.SetFloat("boxY" + i.ToString(), boxes[i].transform.position.y);
                PlayerPrefs.SetInt("boxHP" + i.ToString(), boxes[i].gameObject.GetComponent<BoxObject>().health);
            }

            for (int i = 0; i < ballIncrease.Length; i++) //Saves the ball increasers 
            {
                ballIncrease[i].GetComponent<Ball_Increase>().moveDown();
                PlayerPrefs.SetFloat("ballX" + i.ToString(), ballIncrease[i].transform.position.x);
                PlayerPrefs.SetFloat("ballY" + i.ToString(), ballIncrease[i].transform.position.y);
            }

            for (int i = 0; i < coins.Length; i++) //Saves the coins
            {
                coins[i].GetComponent<Ball_Increase>().moveDown();
                PlayerPrefs.SetFloat("coinX" + i.ToString(), coins[i].transform.position.x);
                PlayerPrefs.SetFloat("coinY" + i.ToString(), coins[i].transform.position.y);
            }

            for (int i = 0; i < eCoins.Length; i++) //Saves the E-Coins
            {
                eCoins[i].GetComponent<Ball_Increase>().moveDown();
                PlayerPrefs.SetFloat("eCoinX" + i.ToString(), eCoins[i].transform.position.x);
                PlayerPrefs.SetFloat("eCoinY" + i.ToString(), eCoins[i].transform.position.y);
            }


            for (int i = 0; i < boxes.Length; i++)
                if (boxes[i].transform.position.y <= -15)
                {
                    gameOver();
                }

            for (int i = 0; i < ballIncrease.Length; i++)
                if (ballIncrease[i].transform.position.y <= -19)
                {
                    Destroy(ballIncrease[i].gameObject);
                }

            for (int i = 0; i < coins.Length; i++)
                if (coins[i].transform.position.y <= -19)
                {
                    Destroy(coins[i].gameObject);
                }

            for (int i = 0; i < eCoins.Length; i++)
                if (eCoins[i].transform.position.y <= -19)
                {
                    Destroy(eCoins[i].gameObject);
                }

            PlayerPrefs.SetInt("numOfCoins", coins.Length);
            PlayerPrefs.SetInt("numOfECoins", eCoins.Length);
            PlayerPrefs.SetInt("numOfBoxes", boxes.Length);
            PlayerPrefs.SetInt("numOfBallIncrease", ballIncrease.Length);
            PlayerPrefs.SetInt("NumOfBalls", PlayerController.numberOfBalls);

            currentRound.round++;
            PlayerPrefs.SetInt("Round", currentRound.round);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Game");
        isGameOver = true;
        gameOver();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        if (!gameContinued)
        {
            isGameOver = true;
            gameOver();
        }
    }

    public void destroyBottomWave() //The Danger Zone
    {
        Collider2D[] boxes = Physics2D.OverlapAreaAll(corner3.position, corner2.position, whatIsBox);

        if (clearUses > 0 && boxes.Length > 0)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                Destroy(boxes[i].gameObject);
                Debug.Log(boxes[i]);
            }
            clearUses--;
            PlayerPrefs.SetInt("Clears", clearUses);
        }
    }

    public void toggleDangerZone() //Toggles the DangerZones animation
    {
        Collider2D[] boxes = Physics2D.OverlapAreaAll(corner3.position, corner2.position, whatIsBox);
        if (boxes.Length > 0)
        {
            DangerZone.SetActive(true);
        }
        else
        {
            DangerZone.SetActive(false);
        }
    }

}
