using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NoMoneyColor;

    [Header("Optional")]
    public GameObject turret;
    public Vector3  positionOffset;

    private Renderer rend;
    private Color startColor;
    public int smell;

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
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
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
}
