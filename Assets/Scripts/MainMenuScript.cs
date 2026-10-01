using UnityEngine;
//The library for transitioning between scenes and such
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //This public function will be called by the button to change to the scene with the specified name
    public void LoadScene(string sceneName)
    {
        //Tell the built-in Scene Manager to load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
