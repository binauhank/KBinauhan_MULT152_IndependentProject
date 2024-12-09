using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    private GameManager gameMg;
    private Health healthScript;
    private SwitchWeapons weaponScript;

    public Transform cam;
    public Transform groundCheck;
    public Transform shootPosition;
    private Animator animPlayer;
    private BoxCollider punchCollider;
    public Rigidbody projectilePrefab;

    private AudioSource asPlayer;
    public AudioClip jumpSound;
    public AudioClip punchHitSound;
    public AudioClip shootSound;
    public AudioClip pickupSound;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public float projSpeed = 30f;
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
        weaponScript = GetComponentInChildren<SwitchWeapons>();
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        asPlayer = GetComponent<AudioSource>();
        punchCollider = GetComponentInChildren<BoxCollider>();
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

            if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
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
                asPlayer.PlayOneShot(jumpSound, 0.5f);
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

            if (weaponScript.canPunch && Input.GetButtonDown("Fire1"))
            {
                MeleeAttack();
            }

            if (weaponScript.canShoot && Input.GetButtonDown("Fire1"))
            {
                RangedAttack();
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
            asPlayer.PlayOneShot(pickupSound, 0.4f);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "UpgradeTwo")
        {
            cannonUpgrade = true;
            asPlayer.PlayOneShot(pickupSound, 0.4f);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "UpgradeThree")
        {
            hackingUpgrade = true;
            asPlayer.PlayOneShot(pickupSound, 0.4f);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "HealthPickup")
        {
            float healing = 3f;
            healthScript.Heal(healing);
            asPlayer.PlayOneShot(pickupSound, 0.4f);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss")
        {
            col.GetComponent<Health>().TakeDamage(1f);
            asPlayer.PlayOneShot(punchHitSound, 0.15f);
        }
    }

    void MeleeAttack()
    {
        if (!animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            animPlayer.SetTrigger("Punch_trig");
        }
    }

    void RangedAttack()
    {
        if (!animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Player Shoot"))
        {
            animPlayer.SetTrigger("Shoot_trig");
        }
    }

    void EnableAttack()
    {
        punchCollider.enabled = true;
    }

    void DisableAttack()
    {
        punchCollider.enabled = false;
    }

    void ShootProjectile()
    {
        var projectile = Instantiate(projectilePrefab, shootPosition.position, shootPosition.rotation);
        projectile.velocity = transform.forward * projSpeed;
        asPlayer.PlayOneShot(shootSound, 0.15f);
    }
}
