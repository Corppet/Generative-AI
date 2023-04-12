using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // The player's movement speed
    public float jumpForce = 10f; // The force of the player's jump
    private bool isGrounded; // Whether or not the player is touching the ground

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the player based on the input
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement = Vector3.ClampMagnitude(movement, 1f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Check if the player is on the ground
        if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log("Grounded: " + isGrounded);

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
