using UnityEngine;

public class Physics2DMovement : MonoBehaviour
{
    //A reference to the rigidbody of this object
    public Rigidbody reggiebody;
    //The variable telling this script how much force to apply to the object
    public float jumpForce = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3.up = (0, 1, 0)
        // It's what's called a "unit vector". This means that its magnitude is 1
        // When you multiply a unit vector by a number, the resulting magnitude
        // is the number
        reggiebody.AddForce(Vector3.up * jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
