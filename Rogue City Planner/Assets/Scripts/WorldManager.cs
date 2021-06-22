using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static int X = 32;
    public static int Y = 32;
    public static GameObject[,] world = new GameObject[X, Y];

    public GameObject nodePrefab;
    public GameObject corePrefab;
    public GameObject spawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                world[i,j] = (GameObject) Instantiate(nodePrefab, new Vector3(i*4, 0, j*4), Quaternion.identity);
            }
        }

        Node heart = world[X/2, Y/2].GetComponent<Node>();
        Node spawn = world[0, 0].GetComponent<Node>();

        heart.turret = (GameObject) Instantiate(corePrefab, heart.GetBuildPosition(), Quaternion.identity);
        heart.smell = 10;
        spawn.turret = (GameObject) Instantiate(spawnPrefab, spawn.GetBuildPosition(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
