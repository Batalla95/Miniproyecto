using UnityEngine;


public class AnimatorController : MonoBehaviour
{
    Animator playerAnimator;

    [Header("Animator variables")]
    public string speedVariable = "Speed";
    public string isGroundVariable = "IsGrounded";

    private float horizontal;
    private float vertical;
    private float speed;

    public void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        UpdateSpeed();
    }

    public void UpdateSpeed()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        vertical = Input.GetAxisRaw("vertical");

        speed = Mathf.Abs(horizontal + vertical);

        playerAnimator.SetFloat(speedVariable, speed);
    }

    public void UpdateGround(bool IsGrounded)
    {
        playerAnimator.SetBool(isGroundVariable, IsGrounded);
    }


}
