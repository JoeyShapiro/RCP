using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int x;
    public int y;
    public Vector3 transformOffset;

    private Transform target;
    private int wavepointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetNextMove();
        target = WorldManager.world[x,y].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (target.position + transformOffset) - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, (target.position + transformOffset)) <= 0.4f) {
            GetNextMove();
        }
    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void GetNextMove() {
        x = (int) Math.Round(transform.position.x / 4);
        y = (int) Math.Round(transform.position.z / 4);

        Node below = null;
        Node above = null;
        Node left = null;
        Node right = null;
        int smell = 0;

        // get neighbors
        if (x+1 < 31)
            below = WorldManager.world[x+1, y].GetComponent<Node>();
        if (x-1 > 0)
            above = WorldManager.world[x-1, y].GetComponent<Node>();
        if (y-1 > 0)
            left = WorldManager.world[x, y-1].GetComponent<Node>();
        if (y+1 < 31)
            right = WorldManager.world[x, y+1].GetComponent<Node>();

        // go to smelliest
        if (below != null && below.smell > smell) {
            target = below.transform;
            smell = below.smell;
        }
        if (above != null && above.smell > smell) {
            target = above.transform;
            smell = above.smell;
        }
        if (left != null && left.smell > smell) {
            target = left.transform;
            smell = left.smell;
        }
        if (right != null && right.smell > smell) {
            target = right.transform;
            smell = right.smell;
        }

        // check if curret heart
    }
}
