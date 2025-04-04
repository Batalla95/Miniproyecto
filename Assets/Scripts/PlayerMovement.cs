using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public float rayHeight;

    public GameObject[] Weapon;
    private int currentWeaponIndex = 0;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump=true;

    public float dashForce;
    public float dashCooldown;
    bool readyToDash = true;
    bool speedControlControl = true;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode dashKey = KeyCode.LeftShift;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirecction;

    Rigidbody rb;

    Quaternion camRotation;

    Vector3 forward;
    Vector3 right;
    Vector3 rbRotation;

    AnimatorController animatorController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animatorController = GetComponent<AnimatorController>();

        SwitchWeapon(0);

        
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position+Vector3.up*rayHeight, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        RotationCam();
        if (speedControlControl)
        {
            SpeedControl();
        }
        
        

        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }

        animatorController.UpdateGround(grounded);
    }

    private void FixedUpdate()
    {
        MovePLayer();

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("horizontal");
        verticalInput = Input.GetAxisRaw("vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKey(dashKey) && readyToDash)
        {
            speedControlControl = false;
            
            readyToDash = false;

            Dash();

           

            Invoke(nameof(ResetDash), dashCooldown);
            Invoke(nameof(ResetSpeedControl), 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1); 
        }
    }

    private void RotationCam()
    {
        camRotation = Camera.main.transform.rotation;
        camRotation.eulerAngles = new Vector3(0f, camRotation.eulerAngles.y, 0);
        rb.rotation = camRotation;

        rbRotation = rb.transform.rotation.eulerAngles;
        
    }


    private void MovePLayer()
    {
        forward = Quaternion.Euler(0f, rbRotation.y, 0f)*Vector3.forward;
        right = Quaternion.Euler(0f, rbRotation.y, 0f) * Vector3.right;
        Vector3 rotation = rb.transform.rotation.eulerAngles;

        moveDirecction = forward * verticalInput + right * horizontalInput;

        rb.AddForce(moveDirecction.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
        
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Dash()
    {
        forward = Quaternion.Euler(0f, rbRotation.y, 0f) * Vector3.forward;
        right = Quaternion.Euler(0f, rbRotation.y, 0f) * Vector3.right;

        moveDirecction = forward * verticalInput + right * horizontalInput;

        
        rb.AddForce(moveDirecction.normalized* dashForce, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        readyToDash = true;
        
    }

    private void ResetSpeedControl()
    {
        speedControlControl = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f));
    }

    private void SwitchWeapon(int index)
    {
        if (index < 0 || index > Weapon.Length)
        {
            return;
        }

        foreach (GameObject weapon in Weapon)
        {
            weapon.SetActive(false);
        }
        Weapon[index].SetActive(true);
        currentWeaponIndex = index;
    }

}
