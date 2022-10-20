using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float waitTime=3f;
    [SerializeField] AudioClip Landing;
     [SerializeField] AudioClip Crash;
    AudioSource audioSource;

    bool isTransitioning;

    void Start()
    {
       audioSource=GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning){return;}
        switch(other.gameObject.tag)
        {
            case "friendly":
            Debug.Log("boink");
            break;

            case "obstacle":
            Debug.Log("You blew up");
            Invoke("startCrashSequence",waitTime);  
            break;

            case "Finish":
            Debug.Log("hurray! next level");  
            Invoke("winSequence",waitTime);
            break;

            default:
           
            break;
        }
    }
    void startCrashSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        GetComponent<Movement>().enabled=false;
        audioSource.PlayOneShot(Crash);
        ReloadLevel();
    }

    void winSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        GetComponent<Movement>().enabled=false;
        audioSource.PlayOneShot(Landing);
        nextLevel();
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
