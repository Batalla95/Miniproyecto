using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rB;
    public Vector3 InputKey;
    float MyFloat;
    
    
    void Update()
    {
        InputKey = new Vector3(Input.GetAxis("horizontal"), 0, Input.GetAxis("vertical"));
    }

    private void FixedUpdate()
    {
        rB.MovePosition((Vector3)transform.position + InputKey * 10 * Time.deltaTime);

        float Angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
        float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref MyFloat, 0.1f);

        transform.rotation=Quaternion.Euler(0, Angle,0);
    }
}
