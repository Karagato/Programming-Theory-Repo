using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class GameManager : MonoBehaviour
{
    

    private float spawnRangeZ = 17.0f;
    private float spawnRangeX = 4.0f;
  
    public GameObject[] enemies;
    public GameObject currentButton;
    [SerializeField]
    public GameObject hideButton;
   

    private int m_currentOption;
    private int enemyCount;
    private int waveNumber = 1;
    
    public int currentOption
    {
        get { return m_currentOption; }
        set { m_currentOption = value; }
    }

    private bool gameActive;

    public bool isGameActive
    {
        get { return gameActive; }
        set { gameActive = value; }
    }

    private bool takeWeapon;

    public bool canTakeWeapon
    {
        get { return takeWeapon; }
        set { takeWeapon = value; }
    }


    public SpriteRenderer spriteRenderer;
 

 
     public List<Sprite> spriteArray;
      void LoadSpritesWhenReady(AsyncOperationHandle<Sprite> handleToCheck)
      {
          if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
          {
              spriteArray.Add(handleToCheck.Result);
          }
      }
    // Start is called before the first frame update
    void Start()
    {

        isGameActive = true;
        canTakeWeapon = true;
        currentOption = 0;
       AsyncOperationHandle<Sprite> spriteHandle =
           Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/pistol.png");
       spriteHandle.Completed += LoadSpritesWhenReady;

      spriteHandle = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/mortar.png");
       spriteHandle.Completed += LoadSpritesWhenReady;

       spriteHandle = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/machinegun.png");
       spriteHandle.Completed += LoadSpritesWhenReady;

       spriteHandle = Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/shield.png");
       spriteHandle.Completed += LoadSpritesWhenReady;
        isGameActive = true;
        SpawnEnemyWave(waveNumber);
       
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameActive)
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                waveNumber++;

                SpawnEnemyWave(waveNumber);
            }
        }
      
    }

 

    Vector3 GenerateRandomPosition()
    {
        float spawnPosX = GetRoundNumber(Random.Range(-spawnRangeX, spawnRangeX));
        Vector3 randomPos = new Vector3(spawnPosX, 1f, spawnRangeZ);

        return randomPos;
    }

    int GenerateRandomNumber(int number)
    {
        return Random.Range(0,number);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemy = GenerateRandomNumber(enemies.Length);
            Instantiate(enemies[enemy],
                GenerateRandomPosition(), enemies[enemy].transform.rotation);
        }
    }

    float GetRoundNumber(float number)
    {
        return Mathf.Round(number) + 0.5f;

    }

  

}
