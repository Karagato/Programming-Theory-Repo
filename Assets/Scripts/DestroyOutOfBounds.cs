using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField]
    private int boundZ;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfOutOfBounds();

    }

    void DestroyIfOutOfBounds()
    {
        if(transform.position.z > boundZ | transform.position.z < -boundZ)
        { 
            Destroy(gameObject);
            if(transform.position.z < -boundZ)
            {
                gameManager.isGameActive= false;
                Debug.Log("Game Over");
            }
        }
    }
}
