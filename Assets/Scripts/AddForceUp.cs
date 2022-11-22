using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceUp : MonoBehaviour
{
    [SerializeField]
    private float force_up;
    [SerializeField]
    private float force_frw;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.up * force_up);
      gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * force_frw);
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
