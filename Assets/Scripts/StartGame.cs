using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("start");
        gameObject.GetComponent<Button>().onClick.AddListener(ToMainScene);
    }
    void ToMainScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("down");
    }
}
