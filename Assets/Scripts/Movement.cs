using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] AudioClip mainEngine;
   [SerializeField] ParticleSystem PThrust;
   [SerializeField] ParticleSystem PThrustRight;
   [SerializeField] ParticleSystem PThrustLeft;
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
            
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            
            if(!PThrust.isPlaying)
            {
                PThrust.Play();
            }
           
        }
        else 
        {
           audioSource.Stop();
           PThrust.Stop();
        }
       
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(rotate);
           //PThrustRight.Play();
        }

        else if(Input.GetKey(KeyCode.A))
        {
           ApplyRotation(-rotate);
          // PThrustLeft.Play();
        }
    }

    void ApplyRotation(float rotateThrust)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
       
    }
}
