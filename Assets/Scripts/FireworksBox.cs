using UnityEngine;

public class FireworksBox : MonoBehaviour
{
    //The object that will be spawned when this box is touched
    public Transform fireworks;

    //When working with 2D, DONT use this one
    //private void OnTriggerEnter(Collider other)
    //{

    //}

    //Use this one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This function spawns objects at a set position and with a set rotation
        //             V the object that will be spawned
        //                                            V The position where it will be spawned
        //                                                    V The rotation it will have on spawn
        Instantiate(fireworks, collision.transform.position, Quaternion.identity);
    }

    //This will trigger every single frame the trigger is being entered
    //(or if this is on a non-trigger object, that it enters a trigger.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
