using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float timePassed = 0;

    // Update is called once per frame
    void Update()
    {
        //Add to the timePassed variable, the number of seconds since the last frame
        timePassed += Time.deltaTime;
        //A debug message to see the way the time increases
        Debug.Log(timePassed);
    }
}
