using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator_Pause : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    //[Range] gives a slider in unity
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //current position of the object in the world
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    void Oscillate()
    {
        //this block of code is responsible for the objects moving back and forth, up and down, etc.
        //continually growing over time
        float cycles = Time.time / period;
        
        //constant value of 6.283
        const float tau = Mathf.PI * 2;
        //going from -1 to 1
        float rawSinWave = Mathf.Sin(cycles * tau);
        //instead of it going from -1 to 1 if we add 1, it will go from 0 to 2, then once divided by 2, it will go from 0 to 1
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
