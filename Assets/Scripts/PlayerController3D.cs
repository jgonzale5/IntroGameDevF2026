using UnityEngine;
//Add the Input System library
using UnityEngine.InputSystem;

public class PlayerController3D : MonoBehaviour
{
    //A reference to the character controller on this object
    public CharacterController controller;
    //The speed of the player
    public float speed = 1.0f;

    //This will store what input the player is pressing. We're only moving in X and Z with WASD
    private Vector3 playerInputBuffer;
    //Keeps track of the player input for rotation
    public float rotationInputBuffer = 0.0f;
    //The speed at which the character rotates
    public float rotationSpeed = 45.0f;


    // Update is called once per frame
    void Update()
    {
        //This will rotate the player character object
        //                 V Is the same as saying (0, 1, 0)
        //                               V This just tells the player the direction they're rotating
        //                                                   V How fast the player rotates
        //                                                                   V Standarize it with time
        transform.Rotate(Vector3.up * rotationInputBuffer * rotationSpeed * Time.deltaTime);

        Vector3 motion = 
            transform.forward //This is the vector coming from the player facing forward 
            * playerInputBuffer.z //We take the z value from the input buffer and multiply it by the forward vector
            + transform.right //his is the vector coming from the player's right
            * playerInputBuffer.x; //We take the x value from the input buffer and multiply it by the right vector

        motion = motion.normalized; //We do this to prevent the addition of vector to affect the speed of the player

        //When multiplying a vector by a scalar (single value), it's a distributive operation
        // A*(1,2,3) = (1A, 2A, 3A)
        //Move will move the object this CharacterController is attached to.
        //               V The vector indicating the player movement direction
        //                                   V The speed per second
        //                                           V The time since the last frame, used to make the speed match seconds instead of frames
        controller.Move(motion * speed * Time.deltaTime);
    }
    //These two functions receive the input from the player input and update the player input buffer accordingly
    public void SetHorizontalAxis(InputAction.CallbackContext value)
    {
        playerInputBuffer.x = value.ReadValue<float>();
    }
    public void SetVerticalAxis(InputAction.CallbackContext value)
    {
        playerInputBuffer.z = value.ReadValue<float>();
    }
    public void SetRotationAxis(InputAction.CallbackContext value)
    {
        rotationInputBuffer = value.ReadValue<float>();
    }
}
