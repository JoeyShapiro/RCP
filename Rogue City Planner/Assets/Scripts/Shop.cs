using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public GameObject prefabCard;
    public RectTransform ParentPanel;
    BuildManager buildManager;

    public void SelectStandardTurret() {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        Draw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Draw() {
        Debug.Log("Drawing");
        for(int i = 0; i < PlayerStats.Draw; i++) {
            GameObject goButton = (GameObject) Instantiate(prefabCard);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }

    public void ButtonClicked(int buttonNo) {
        Debug.Log("Button Clicked" + buttonNo);
    }
}
