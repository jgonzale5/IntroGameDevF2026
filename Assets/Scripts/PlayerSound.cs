using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //This is a reference to the source that will play our clips
    public AudioSource audioSource;
    //This is the clip that will play when this object jumps
    public AudioClip jumpSound;
    //This is the clip that will play when this object dies
    public AudioClip deathSound;

    private void Awake()
    {
        //If there is no value assigned to the audioSource, we try to get one from this game object
        if (audioSource == null)
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    //Play the jumping sound
    public void PlayJump()
    {
        //Tell the source to play the jump sound once
        audioSource.PlayOneShot(jumpSound);
    }

    //Play the death sound
    public void PlayDie()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
