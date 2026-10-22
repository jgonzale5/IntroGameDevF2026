using UnityEngine;
//Include the input system library
using UnityEngine.InputSystem;

public class PlayerAnimationManager2D : MonoBehaviour
{
    //A reference to the animator in this object 
    public Animator animator;

    //The input manager is gonna call this function whenever we press the movement keys
    public void SetHorizontalAxis(InputAction.CallbackContext value)
    {
        //Set the HorizontalMovement parameter of the animator to have the value passed
        animator.SetFloat("HorizontalMovement", value.ReadValue<float>());

        //Will set the scale in X to negative if the player is pressing the left key
        this.transform.localScale = new Vector3(
            Mathf.Abs(this.transform.localScale.x) * Mathf.Sign(value.ReadValue<float>()),
            this.transform.localScale.y,
            this.transform.localScale.z);
    }

    //Tell the animator to set the punch trigger on
    public void SetPunch()
    {
        animator.SetTrigger("Punch");
    }
}
