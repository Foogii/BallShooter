using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public int numberOfBalls = 1;
    public static int currNumBall = numberOfBalls;

    private float fireRate = 0.1f;

    public GameObject ballPrefab;

    public GameObject shopMenu;

    BallBehaviour ballScript;

    GameObject gmObj;
    GameManager gm;

    LineRenderer lineRenderer;

    void Start()
    {
        if(PlayerPrefs.GetInt("Round") <= 1)
            numberOfBalls = 1;

        gmObj = GameObject.Find("GameManager");
        gm = (GameManager) gmObj.GetComponent<GameManager>();

        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (GameManager.roundEnd == false && gm.isGameOver == false)
        {
            currNumBall = numberOfBalls;
            Vector2 mouse_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(mouse_Position.x - transform.position.x, mouse_Position.y - transform.position.y);

            if (mouse_Position.y > transform.position.y + 0.25)
                transform.up = direction;

                lineRenderer.SetPosition(0, mouse_Position);
                lineRenderer.SetPosition(1, mouse_Position);

            if (Input.GetMouseButtonUp(0) && mouse_Position.y > transform.position.y && !shopMenu.activeInHierarchy)
            {
                Time.timeScale = 1;
                GameManager.roundEnd = true;

                lineRenderer.SetPosition(0, new Vector2(-20, -20));
                lineRenderer.SetPosition(1, new Vector2(-20, -20));

                StartCoroutine(burstFire());

            }
        }
    }

    public IEnumerator burstFire()
    {
        Vector3 direction = transform.up * 100;
        direction.Normalize();

        for(int i = 0; i < numberOfBalls; i++)
        {
            var ball = Instantiate(ballPrefab, transform.up - new Vector3(0f, 18f, 0f), Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(direction);
            currNumBall--;

            if(currNumBall < 0)
            {
                currNumBall = 0;
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
