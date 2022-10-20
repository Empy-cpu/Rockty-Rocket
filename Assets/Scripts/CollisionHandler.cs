using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float waitTime=3f;
    void OnCollisionEnter(Collision other)
    {
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
        GetComponent<Movement>().enabled=false;
        ReloadLevel();
    }

    void winSequence()
    {
        GetComponent<Movement>().enabled=false;
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
