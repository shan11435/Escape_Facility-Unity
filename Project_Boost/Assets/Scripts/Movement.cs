using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{ 
    //serialize field allows the numbers to be edited in unity
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem movingParticles;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem leftBooster;
    
    //fetch the rigidbody component 
    Rigidbody myRigidBody;
    //fetch the audiosource component
    AudioSource myAudioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody component
        myRigidBody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void Debug()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        //it's the level the player is currently in
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //go the next level by adding one to the scene index
        int nextSceneIndex = currentSceneIndex + 1;
        //if the player is in the last scene that was created
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            //transport player back to scene index 0
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           StartThrusting();
        } 
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    void StopRotation()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    void StartThrusting()
    {
        myRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        //this line fixed the audio sounding wierd
        if(!myAudioSource.isPlaying)
        {
            //this plays the audio
            //this sound was taken from this link https://freesound.org/s/146770/
            myAudioSource.PlayOneShot(mainEngine);
        }
        if(!movingParticles.isPlaying)
        {
            //this makes the makes the particles come when the rocket moves
            movingParticles.Play();
        }
    }

    void StopThrusting()
    {
        //this stops the audio
        myAudioSource.Stop();

        //this stops the particles if the player stops moving
        movingParticles.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if(!rightBooster.isPlaying)
        {
            //this makes the makes the particles come when the rocket moves
            rightBooster.Play();
        }
    }

    void RotateRight()
    {
        //-rotation thrust will make the object rotate on the negative side of z axis
        ApplyRotation(-rotationThrust);
        if(!leftBooster.isPlaying)
        {
            //this makes the makes the particles come when the rocket moves
            leftBooster.Play();
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
