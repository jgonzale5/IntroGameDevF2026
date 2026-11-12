using UnityEngine;
//Add this library to use coroutines
using System.Collections;
//Access to UI elements
using UnityEngine.UI;

public class PurpleZone : MonoBehaviour
{
    //the material the player will turn when they touch it
    public Material purpleMaterial;
    //The duration of time the player will be that material
    public float materialTimeDuration = 5.0f;
    //Keeps track of whether the coroutine is being executed
    private bool currentlyExecutingCoroutine = false;
    //A reference to the slider UI object that tells the player how long they have
    // left to turn green
    public Slider timeRemainingIndicator;

    private void Start()
    {
        //Hide the indicator if the coroutine is not executing
        timeRemainingIndicator.gameObject.SetActive(false);
    }

    //When the player enters this, they'll turn purple
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        if (currentlyExecutingCoroutine != true)
        {
            //other.GetComponent<Renderer>().material = purpleMaterial;
            //StartCoroutine(PurpleTime(materialTimeDuration,
            //    other.GetComponent<Renderer>()));
            StartCoroutine(PurpleTimeDynamic(materialTimeDuration,
                other.GetComponent<Renderer>()));
        }
    }

    //Changes the material of the specified renderer, then changes it back
    //after a purpleTimer amount of seconds
    private IEnumerator PurpleTime(float purpleTimer, Renderer renderer)
    {
        // Indicate that the coroutine is currently executing
        currentlyExecutingCoroutine = true;
        Debug.Log("Purple Time");
        //float timer = purpleTimer;
        //Get the original material in the renderer and cache it for later
        Material originalMaterial = renderer.material;
        //"Wait until the frame ends, and continue in the next one"
        yield return null;
        //Set the material of the object to be the one specified
        renderer.material = purpleMaterial;
        //Wait an amount of seconds equal to purpleTimer
        yield return new WaitForSeconds(purpleTimer);
        //Set the material back to its original value
        renderer.material = originalMaterial;
        Debug.Log("You're green again");
        //Indicate that the coroutine is done
        currentlyExecutingCoroutine = false;
    }

    private IEnumerator PurpleTimeDynamic(float purpleTimer, Renderer renderer)
    {
        // Indicate that the coroutine is currently executing
        currentlyExecutingCoroutine = true;
        Debug.Log("Purple Time");

        //vvv
        //Enable the indicator
        timeRemainingIndicator.gameObject.SetActive(true);
        //A variable to keep track of the time remaining
        float timeRemaining = purpleTimer;
        //^^^

        //Get the original material in the renderer and cache it for later
        Material originalMaterial = renderer.material;
        //"Wait until the frame ends, and continue in the next one"
        yield return null;
        //Set the material of the object to be the one specified
        renderer.material = purpleMaterial;

        //vvv
        //A while loop is an if-statement that keeps repeating itself
        while (timeRemaining > 0)
        {
            //Set the slider to the current normalized value between 0 and purpleTimer
            timeRemainingIndicator.normalizedValue = timeRemaining / purpleTimer;
            //
            timeRemaining -= Time.deltaTime;

            //If you're using a while loop in a coroutine, make sure to at least have
            // one of these, so it will move to the next frame
            yield return null;
        }
        //turn the indicator off again
        timeRemainingIndicator.gameObject.SetActive(false);
        //^^^

        //Set the material back to its original value
        renderer.material = originalMaterial;
        Debug.Log("You're green again");
        //Indicate that the coroutine is done
        currentlyExecutingCoroutine = false;
    }
}
