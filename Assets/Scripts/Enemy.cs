using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    private bool isAtacking;
    public bool atacking
    {
        get
        {
            return isAtacking;
        }
        set
        {
            isAtacking = value;
        }
    }

    private GameObject e_weapon;
    public GameObject currentEWeapon
    {
        get
        {
            return e_weapon;
        }
        set
        {
            e_weapon = value;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if (isAtacking)
        {
            InvokeRepeating("AtackWeapon", speed, speed);
            isAtacking = false;
        }
    }

    void AtackWeapon()
    {
        if (currentEWeapon.GetComponent<BaseCharacter>().life > 0)
        {
            currentEWeapon.GetComponent<BaseCharacter>().life -= atack;
        } else
        {
            CancelInvoke();
            Destroy(currentEWeapon);
        }
        

        
}

}
