using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] options;
    private TerrainCollider terrainCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        terrainCollider = GetComponent<TerrainCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

        if (gameManager.isGameActive && gameManager.canTakeWeapon)
        {
            Instantiate(options[gameManager.currentOption],
            MousePositionOnTerrain(),
            options[gameManager.currentOption].transform.rotation);
            gameManager.canTakeWeapon = false;
            StartCoroutine(ActiveButton());
            gameManager.hideButton.SetActive(false);
        }
        else
        {
            Debug.Log("Wait a moment to set more weapons");
        }

    }

    public Vector3 MousePositionOnTerrain()
    {
        
        Vector3 worldPosition= new Vector3();
        Ray ray;
       
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (terrainCollider.Raycast(ray, out hitData, 1000))
            {
            worldPosition = new Vector3(GetRoundNumber(hitData.point.x), 0.5f, GetRoundNumber(hitData.point.z));
        }
        Debug.Log(" position" + worldPosition);
        return worldPosition;
        
    }

    float GetRoundNumber(float number)
    {
        return Mathf.Round(number)+0.5f;

    }

    IEnumerator ActiveButton()
    {
        yield return new WaitForSeconds(gameManager.currentOption+3);
        gameManager.hideButton.SetActive(true);
        gameManager.canTakeWeapon = true;
    }
}
