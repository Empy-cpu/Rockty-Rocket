using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float thrust=1000f;
     public float rotate=10f;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            
        }

       
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
           ApplyRotation(rotate);
        }

        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotate);
        }
    }

    void ApplyRotation(float rotateThrust)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
        rb.freezeRotation=false;
    }
}
