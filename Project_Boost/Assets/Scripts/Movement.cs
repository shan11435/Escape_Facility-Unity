using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    //serialize field allows the numbers to be edited in unity
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody myRigidBody;
   
    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody component
        myRigidBody = GetComponent<Rigidbody>();
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
            myRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        } 
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //-rotation thrust will make the object rotate on the negative side of z axis
            ApplyRotation(-rotationThrust);
        }
    }

    //creates a method that makes the object rotate
    void ApplyRotation(float rotationThisFrame)
    {
        myRigidBody.freezeRotation = true; //freezing rotation so we can manually rotate
        //Vector3,forward makes the object rotate on the z axis
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        
        myRigidBody.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}
