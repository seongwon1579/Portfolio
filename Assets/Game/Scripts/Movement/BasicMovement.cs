using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicMovement : MonoBehaviour, IMovable, IGrativity
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private bool isGravity = true;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        ApplyGravity();
    }

    public void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (moveDir.magnitude > 0)
        {
            animator.SetBool("IsMove", true);
            Vector3 forwardCam = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
            Vector3 rightCam = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);

            moveDir.Normalize();

            Vector3 moveForce = forwardCam * moveDir.z + rightCam * moveDir.x;

            transform.forward = forwardCam;
            characterController.Move(moveForce * Time.deltaTime * moveSpeed);

            Quaternion forwardDir = Quaternion.LookRotation(moveForce);
            transform.rotation = Quaternion.Slerp(transform.rotation, forwardDir.normalized, 0.025f);
        }
        else
            animator.SetBool("IsMove", false);
    }

    public void ApplyGravity()
    {
        if (isGravity && !characterController.isGrounded)
        {
            characterController.Move(Vector3.up * Physics.gravity.y);
        }
    }
}
