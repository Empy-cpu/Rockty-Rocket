using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float waitTime=3f;
    [SerializeField] AudioClip Landing;
    [SerializeField] AudioClip Crash;
    [SerializeField] ParticleSystem PCrash;
    AudioSource audioSource;

    bool isTransitioning;
    bool CollisionDisabled=false;

    void Start()
    {
       audioSource=GetComponent<AudioSource>();
    }

    void Update()
    {
        DebugKeys();
    }

    void DebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            nextLevel();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            CollisionDisabled=!CollisionDisabled;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning||CollisionDisabled){return;}

        switch(other.gameObject.tag)
        {
            case "friendly":
            Debug.Log("boink");
            break;

            case "obstacle":
            Debug.Log("You blew up");
            startCrashSequence();
            
            break;

            case "Finish":
            Debug.Log("hurray! next level"); 
            winSequence();
           
            break;

            default:
           
            break;
        }
    }
    void startCrashSequence()
    {
        isTransitioning=true;
        audioSource.PlayOneShot(Crash);
        PCrash.Play();
        GetComponent<Movement>().enabled=false;
        Invoke("ReloadLevel",waitTime);  
       
    }

    void winSequence()
    {
        isTransitioning=true;
        audioSource.PlayOneShot(Landing);
        Invoke("nextLevel",waitTime);
        GetComponent<Movement>().enabled=false;
       
    }

    void ReloadLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void nextLevel()
    {
        int currentIndex=SceneManager.GetActiveScene().buildIndex;
        int nextScene=currentIndex+1;
        if(nextScene==SceneManager.sceneCountInBuildSettings)
        {
            nextScene=0;
        }
        SceneManager.LoadScene(nextScene);
    }
    
}
