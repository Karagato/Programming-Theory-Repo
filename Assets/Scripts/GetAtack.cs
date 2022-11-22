using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAtack : MonoBehaviour
{
   [SerializeField]
    private int m_atack;
    public int b_atack
    {
        get { return m_atack; }
        set { m_atack = value; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
