using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // this is calling the meshrenderer component in unity
    new MeshRenderer renderer;
    //this is calling the rigid body component in unity
    Rigidbody rigidBody;
    //this will allow a user to change the waittime in unity
    [SerializeField] float waitTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //this call the mesh renderer component
        renderer = GetComponent<MeshRenderer>();
        //this call the rigidBody component
        rigidBody = GetComponent<Rigidbody>();

        //this turns the mesh renderer off
        renderer.enabled = false;
        //this turns the useGravity in rigidBody off
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > waitTime){

            renderer.enabled = true;
            rigidBody.useGravity = true;

        }
    }
}
