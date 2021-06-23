using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NoMoneyColor;

    [Header("Optional")]
    public GameObject turret;
    public Vector3  positionOffset;

    private Renderer rend;
    private Color startColor;
    public int smell = 0;

    BuildManager buildManager;

    void OnMouseEnter() {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = NoMoneyColor;
        }
    }

    void OnMouseExit () {
        rend.material.color = startColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;

        InvokeRepeating("SetSmell", 0f, 0.5f); // maybe make quicker
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    void SetSmell() {
        // x and y of this
        int x = (int) Math.Round(transform.position.x / 4);
        int y = (int) Math.Round(transform.position.z / 4);

        int below = 0;
        int above = 0;
        int left = 0;
        int right = 0;

        // get neighbors
        if (x+1 < 31)
            below = WorldManager.world[x+1, y].GetComponent<Node>().smell;
        if (x-1 > 0)
            above = WorldManager.world[x-1, y].GetComponent<Node>().smell;
        if (y-1 > 0)
            left = WorldManager.world[x, y-1].GetComponent<Node>().smell;
        if (y+1 < 31)
            right = WorldManager.world[x, y+1].GetComponent<Node>().smell;

        // set the smell of this
        smell = Math.Max(above, Math.Max(below, Math.Max(left, right))) - 1;
        if (turret != null && turret.tag == "Heart") // smart
            smell = 64;
    }

    void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        if (turret != null) {
            return;
        }

        // build a turret
        buildManager.BuildTurretOn(this);
    }

    // Update is called once per frame
    void Update()
    {
        //if (turret.GetComponent<Turret>().type == "Heart")
            //smell = 10;
    }

    // helper not sure if in Math but meh
    int MaxNeighbor(int r, int s, int t, int u) { // find 1 equation
        int first = (1/2) * (r + s + Math.Abs(r - s));
        int second = (1/2) * (t + u + Math.Abs(t - u));
        int third = (1/2) * (first + second + Math.Abs(first - second));
        return third;
    }
}
