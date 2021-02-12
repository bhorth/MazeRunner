using UnityEngine;
using UnityEngine.UI;


//classed used for players movement and animation
public class PlayerMovement : MonoBehaviour
{
    //define references
    public CharacterController controller;
    public Transform cam;
    public Animator anim;

    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Update()
    {
        //allow player movement if the game has not finished and the character controller is still enabled
        if (controller.enabled)
        {
            //get input values
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            AnimatePlayer(horizontal, vertical);

            //get direction vector from input values
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //check if player is moving
            if (direction.magnitude >= 0.1f)
            {
                //find which direction the player is pointing at and add the rotation of the camera to move player direction as well
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                //new angle used to smooth the rotation of the player
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //new direction changes player direction based on rotation of the camera
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
        //if the character controller is not enabled stop the animation 
        else
        {
            anim.SetFloat("Blend", 0, 0, Time.deltaTime);
        }
    }

    //function used for setting the animation speed of the character
    void AnimatePlayer(float h, float v)
    {

        float magnitude = new Vector2(h, v).sqrMagnitude;

        anim.SetFloat("Blend", magnitude, 0.1f, Time.deltaTime);
    }
}