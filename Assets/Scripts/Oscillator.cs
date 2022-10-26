using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField]Vector3 movementVector;
     [SerializeField]Vector3 RotateValues;
    float movementFactor;
    [SerializeField]float period=2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint=transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
         if(period<=Mathf.Epsilon){return;}
        float cycles=Time.time/period; //continually crowing with time
        const float tau=Mathf.PI*2; //const value of 6.28
        float rawSinWave=Mathf.Sin(cycles*tau); //go from -1 to 1
        
        
        movementFactor=(rawSinWave+1f)/2f; //recalculated to go from from 0 to 1
      
       
        Vector3 offset=movementVector*movementFactor;
        transform.position=startingPoint+offset;

        transform.Rotate(RotateValues);
    }
}
