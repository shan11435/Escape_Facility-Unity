using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
        //gets the audioclip component from unity
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {   
        //if isTransitiong is true do nothing, otherwise continue with the remaining lines of code 
        if(isTransitioning == true){ return;}

        //other.gameobject,tag will be the object being collided with 
        switch (other.gameObject.tag)
        {
            //if the object's tag name that's being collided is named friendly
            case "Friendly":
                Debug.Log("Welcome to my SpaceX themed game");
                Debug.Log("Use spacebar to launch your rocket");
                Debug.Log("Use A to rotate left");
                Debug.Log("Use D to rotate right");
                break;
            //if the object's tag name that's being collided is named finish
            case "Finish":
            //calls the method
                StartSuccessSequence();
                break;
            //every other object that doesn't have either tags listed in the switch case
            default:
                //calls the method
                StartCrashSequence();
                break;
        }
    }

    //if the player lands on the landing pad, after x seconds it will call the method load next level
    void StartSuccessSequence()
    {
        //todo- add SFX upon landing pad
        isTransitioning = true;
        //stops all sound effects
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        //todo- add particle effect upon landing pad
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", LevelLoadDelay);
    }

    //if the player hits anything other than the tags listed above, after 1 second it will call the method reload level
    void StartCrashSequence()
    {
        //todo- add SFX upon crash
        isTransitioning = true;
        //stops all sound effects
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //todo- add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);
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

    void ReloadLevel()
    {
        //goes back to the level the player is currently in
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
