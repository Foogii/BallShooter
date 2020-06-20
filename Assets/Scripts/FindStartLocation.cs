using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindStartLocation : MonoBehaviour
{
    [SerializeField]
    GameObject cameraPos;

    [SerializeField]
    GameObject leftWallPosition;
    [SerializeField]
    GameObject rightWallPosition;
    [SerializeField]
    GameObject leftCornerPosition;
    [SerializeField]
    GameObject rightCornerPosition;

    [SerializeField]
    GameObject[] spawners;

    float getAspect;

    // Start is called before the first frame update
    void Awake()
    {
        getAspect = (float)Screen.width / (float)Screen.height;

        if (getAspect == (9f / 16f))
        {
            leftWallPosition.transform.position = new Vector2(cameraPos.transform.position.x - (Camera.main.orthographicSize / 2) - 2, leftWallPosition.transform.position.y);
            rightWallPosition.transform.position = new Vector2(cameraPos.transform.position.x + (Camera.main.orthographicSize / 2) + 2, leftWallPosition.transform.position.y);

            leftCornerPosition.transform.position = new Vector2(leftWallPosition.transform.position.x + 0.7f, leftCornerPosition.transform.position.y);
            rightCornerPosition.transform.position = new Vector2(rightWallPosition.transform.position.x - 0.6f, rightCornerPosition.transform.position.y);

            for (int i = 0; i < spawners.Length; i++)
            {
                if (i - 1 >= 0)
                    spawners[i].transform.position = new Vector2(spawners[i - 1].transform.position.x + 5, spawners[i].transform.position.y);
                else
                    spawners[i].transform.position = new Vector2(leftWallPosition.transform.position.x + 3, spawners[i].transform.position.y);
            }
        }
        else if (getAspect == (9f / 19f))
        {
            leftWallPosition.transform.position = new Vector2(cameraPos.transform.position.x - (Camera.main.orthographicSize / 2), leftWallPosition.transform.position.y);
            rightWallPosition.transform.position = new Vector2(cameraPos.transform.position.x + (Camera.main.orthographicSize / 2), leftWallPosition.transform.position.y);

            leftCornerPosition.transform.position = new Vector2(leftWallPosition.transform.position.x + 0.7f, leftCornerPosition.transform.position.y);
            rightCornerPosition.transform.position = new Vector2(rightWallPosition.transform.position.x - 0.6f, rightCornerPosition.transform.position.y);

            for (int i = 0; i < spawners.Length; i++)
            {
                if (i - 1 >= 0)
                    spawners[i].transform.position = new Vector2(spawners[i - 1].transform.position.x + 4.5f, spawners[i].transform.position.y);
                else
                    spawners[i].transform.position = new Vector2(leftWallPosition.transform.position.x + 3f, spawners[i].transform.position.y);
            }
        }

    }

}
