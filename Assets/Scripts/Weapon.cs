using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BaseCharacter
{
    public GameObject bullet;
    public GameObject sight;



    // Start is called before the first frame update
    void Start()
    {
        SetAtackToBullet();
        for (int i = 0; i < rate; i++) 
            InvokeRepeating("PistolShoot", speed+0.1f*i, speed);
        
       
    }

    void Update()
    {
        life -= .002f;
        if(life < 0)
        {
            Destroy(gameObject);
        }
    }

    private void PistolShoot()
    {
        Shoot(bullet, sight);
    }

    void SetAtackToBullet()
    {
        bullet.GetComponent<GetAtack>().b_atack = atack;
    }


}
