using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    private GameManager gameMg;
    private Health healthScript;
    public Transform cam;
    public Transform groundCheck;
    private Animator animPlayer;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;
    public bool jumpUpgrade;
    public bool cannonUpgrade;
    public bool hackingUpgrade;
    float turnSmoothVelocity;

    Vector3 velocity;
    bool isGrounded;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        animPlayer = GetComponent<Animator>();
        healthScript = GetComponent<Health>();
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        if (!gameMg.gameOver)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if (!(Input.GetAxisRaw("Horizontal") == 0) || !(Input.GetAxisRaw("Vertical") == 0))
            {
                animPlayer.SetBool("Run_bool", true);
            }
            else
            {
                animPlayer.SetBool("Run_bool", false);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animPlayer.SetTrigger("Jump_trig");
            }

            if (velocity.y > 0)
            {
                animPlayer.SetBool("Fall_bool", true);
            }
            else if (velocity.y < 0 && isGrounded)
            {
                animPlayer.SetBool("Fall_bool", false);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (jumpUpgrade)
            {
                jumpHeight = 5f;
            }
        }

        if (gameMg.gameOver)
        {
            animPlayer.SetTrigger("Death_trig");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "UpgradeOne")
        {
            jumpUpgrade = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "UpgradeTwo")
        {
            cannonUpgrade = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "UpgradeThree")
        {
            hackingUpgrade = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "HealthPickup")
        {
            float healing = Random.Range(5, 10);
            healthScript.Heal(healing);
            Destroy(col.gameObject);
        }
    }
}
