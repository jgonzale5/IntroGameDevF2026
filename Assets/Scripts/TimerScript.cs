using UnityEngine;
//Add the TextMeshPro library so we can use the functions and components associated with it
using TMPro;

public class TimerScript : MonoBehaviour
{
    //This float will keep track of the amount of seconds passed since the start of the game
    private float timePassed = 0;
    //A reference to the UI element that displays text
    public TextMeshProUGUI timerDisplay;

    private void Start()
    {
        Debug.Log(MainMenuScript.firstSceneLoaded);
    }

    // Update is called once per frame
    void Update()
    {
        //Add to the timePassed variable, the number of seconds since the last frame
        timePassed += Time.deltaTime;

        //                  V This function will take a number and remove all decimals to convert it to an integer
        //                                         V This gets us the remainder of a division.
        //                                           e.g. 3 % 2 = 1, 16 % 7 = 2
        //                                           The result of a modulo operation is always between 0 and the 
        //                                              second number - 1
        int seconds = Mathf.FloorToInt(timePassed) % 60;
        //                                 V We divide the number of seconds we have by 60
        int minutes = Mathf.FloorToInt(timePassed / 60);
        //                                  V Because seconds is the whole part of the number, we can subtract it from the
        //                                    float to get only the fractional part of the number.
        //                                    We multiply it by 100 to move the comma two spaces to the right
        int miliseconds = Mathf.FloorToInt((timePassed - seconds) * 100);

        // We're accessing the "text" property of the component referred to by timerDisplay
        // Then we change the value of the text to be the timePassed
        // However, since "text" is a string property in the script, we need to tell timePassed to use it's "string" form
        // This is done using the .ToString() function.
        //timerDisplay.text = timePassed.ToString();

        //This is similar to what we did above, but using the number of seconds and minutes we calculated
        timerDisplay.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
        
        //A debug message to see the way the time increases
        //Debug.Log(timePassed);
    }
}
