using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] AudioClip mainEngine;
   [SerializeField] ParticleSystem PThrust;
  
   [SerializeField]public float thrust=1000f;
   [SerializeField]public float rotate=10f;

    AudioSource audioSource;
    Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody>();
       audioSource=GetComponent<AudioSource>();
       Debug.Log("cheng");
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
            
           startThrusting();
        }
        else 
        {
           stopThrusting();
        }
       
    }
    void startThrusting()
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

    void stopThrusting()
    {
        audioSource.Stop();
        PThrust.Stop();

    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
    }

    private void RotateRight()
    {
        ApplyRotation(rotate);
    }
    private void RotateLeft()
    {
        ApplyRotation(-rotate);
    }

    void ApplyRotation(float rotateThrust)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime);
       
    }
}
