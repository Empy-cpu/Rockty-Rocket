using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "friendly":
            Debug.Log("boink");
            break;

            case "obstacle":
            Debug.Log("You blew up");
            Invoke("startCrashSequence",3f);
           
            break;

            case "Finish":
            Debug.Log("hurray! next level");
            nextLevel();
            break;

            default:
           
            break;
        }
    }
    void startCrashSequence()
    {
        GetComponent<Movement>().enabled=false;
        ReloadLevel();
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
        SceneManager.LoadScene(currentIndex);
    }
    
}
