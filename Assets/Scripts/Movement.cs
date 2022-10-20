using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] AudioClip mainEngine;
   [SerializeField]public float thrust=1000f;
   [SerializeField]public float rotate=10f;

    AudioSource audioSource;
    Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>();
       audioSource=GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(mainEngine);
        }
        else 
        {
           audioSource.Stop();
        }
       
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(rotate);
        }

        else if(Input.GetKey(KeyCode.A))
        {
           ApplyRotation(-rotate);
        }
    }

    void ApplyRotation(float rotateThrust)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
       
    }
}
