using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Physics2DMovement : MonoBehaviour
{
    //This value, which will always be within -1 and 1, will tell us the
    // direction of the movement
    public float horizontalMovement = 0;
    //A reference to the player input script on this game object
    public PlayerInput playerInput;
    //This is a reference to the point at the feet of the player 
    // that we'll be casting rays from.
    public Transform jumpPoint;
    //This lets us adjust the length of the raycast
    public float jumpRayLength = 0.15f;

    //Variables
    //A reference to the rigidbody of this object
    public Rigidbody reggiebody;
    //The variable telling this script how much force to apply to the object
    public float jumpForce = 10.0f;
    //
    public float speed = 2.0f;

    private void Update()
    {
        //Calling the function sending it the value of the horizontal movement and 
        // telling it to set Z to 0
        MovementFunction(horizontalMovement, 0);
    }

    private void MovementFunction(float horizontalScalar, float zValue)
    {
        //This lets us change the velocity of the rigidbody, and hence the object
        reggiebody.linearVelocity =
            new Vector3( //Whenever we set the value of a vector, we can either
                         // manipulate its components separately or not. If we can't,
                         // we need to "make a new vector" with the new values

                horizontalScalar * speed, //This means that the velocity of te
                                            // object in X will be equal to something between -speed and speed
                                            // depending on the player input

                reggiebody.linearVelocity.y, //This means that the velocity in y
                                             // does not change.

                zValue); //This is so the object is never moving in z
    }

    //                              V Parameters are values sent into the function
    // Think of it like replacing a value in a mathematical formula
    // R = X + 1 
    // if X = 3 then R = 4
    public void ChangeMovement(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
    }

    //V public vs private: public means that it can be seen and used by classes
    //  outside of this one. In Unity this also has some associations with the editor.
    //  For example, a public variable is seen in the inspector, and a public function
    //  can be called by an event.
    //     V this is the "return type" of the function. Void means it returns nothing.
    //           V This is the name of the function, what we use to "call it"
    //             calling means to execute it/perform it/do it
    //               V These parentheses are for arguments, information set into the function
    public void Jump()
    {
        /*//This is just to draw the ray when gizmos are enabled, for us to see
        //These will not show up in a build. It's for debugging.*/
        Debug.DrawRay(jumpPoint.position, Vector3.down * jumpRayLength, Color.red, 0.1f);

        RaycastHit hit;
        /*
        //If statements will only execute what's in
        // bracket if the condition is true
        //Raycasting lets us shoot a "ray" and see if we hit something
        //                  V the origin of the raycast (where its coming from)
        //                                      V The direction
        //                                                    V The length
        */
        if (Physics.Raycast(jumpPoint.position, Vector3.down, out hit, jumpRayLength)
            //&& hit.transform.gameObject.CompareTag("Floor") This is an "AND" operator version 
            )
        {
            if (hit.transform.gameObject.CompareTag("Floor"))
            {
                /*
                //Vector3.up = (0, 1, 0)
                // It's what's called a "unit vector". This means that its magnitude is 1
                // When you multiply a unit vector by a number, the resulting magnitude
                // is the number*/
                reggiebody.AddForce(Vector3.up * jumpForce);
                Debug.Log("Jumping");

                //When you get here, end the function and return to where
                // it was called
                return;
            }
        }
        Debug.Log("No floor to jump on!");
    }
}
