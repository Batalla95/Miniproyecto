using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirecction;

    Rigidbody rb;

    Quaternion camRotation;

    Vector3 forward;
    Vector3 right;
    Vector3 rbRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
       
    }

    private void Update()
    {
        MyInput();
        RotationCam();
    }

    private void FixedUpdate()
    {
        MovePLayer();

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("horizontal");
        verticalInput = Input.GetAxisRaw("vertical");
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
}
