using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        //other.gameobject,tag will be the object being collided with 
        switch (other.gameObject.tag)
        {
            //if the object's tag name that's being collided is named friendly
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            //if the object's tag name that's being collided is named finish
            case "Finish":
                LoadNextLevel();
                break;
            //every other object that doesn't have either tags listed in the switch case
            default:
                ReloadLevel();
                break;
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

    void ReloadLevel()
    {
        //goes back to the level the player is currently in
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
