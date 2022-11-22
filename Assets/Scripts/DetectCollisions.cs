using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if is a ball and hit the enemy reduce his life
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ReduceOrDestroyEnemy(other);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        
    }
    //reduce life enemy
    void ReduceOrDestroyEnemy(Collider other)
    {
        if (gameObject.CompareTag("Bullet"))
        {
            other.gameObject.GetComponent<Enemy>().life -=
            gameObject.GetComponent<GetAtack>().b_atack;
            if (other.gameObject.GetComponent<Enemy>().life < 1)
            {
                Destroy(other.gameObject);
            }
         
        }
        Destroy(gameObject);
    }
    //detect when the enemy collides  with a weapon and active his atack
    void OnCollisionEnter(Collision other)
    {

     
        if (gameObject.CompareTag("Enemy") && 
            (other.gameObject.CompareTag("Weapon")| other.gameObject.CompareTag("Shield")))
        {
            gameObject.GetComponent<Enemy>().atacking = true;
            gameObject.GetComponent<Enemy>().currentEWeapon = other.gameObject;
        }

    }
    


}
