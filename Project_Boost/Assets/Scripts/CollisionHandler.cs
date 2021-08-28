using UnityEngine;

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
            //if the object's tag name that's being collided is named fuel
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            //if the object's tag name that's being collided is named finish
            case "Finish":
                Debug.Log("You won the game");
                break;
            //every other object that doesn't have either tags listed in the switch case
            default:
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }
}
