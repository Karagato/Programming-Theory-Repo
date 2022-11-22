using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    //base properties 
    [SerializeField]
    private float m_life;
    [SerializeField]
    private int m_atack;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private int m_scope;
    [SerializeField]
    private int m_rate;

    public float life 
    {
        get { return m_life; } 
        set { m_life = value; } 
    }

    public int atack 
    {
        get { return m_atack; }
        set { m_atack = value; } 
    }

    public float speed 
    {
        get { return m_speed; } 
        set { m_speed = value; }
    }

    public int scope
    {
        get { return m_scope; } 
        set { m_scope = value; } 
    }

    public int rate 
    {
        get { return m_rate; } 
        set { m_rate = value; } 
    }

    public virtual void Shoot(GameObject bullet, GameObject sight)
    {
        Instantiate(bullet, sight.transform.position, bullet.transform.rotation);
    }
  
}
