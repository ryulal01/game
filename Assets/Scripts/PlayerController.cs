using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float forwardSpeed = 6f;
    [SerializeField] private float sideSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private int maxJumps = 2;

    private Rigidbody rb;
    private int jumpsLeft;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // чтобы игрок не заваливался
        jumpsLeft = maxJumps;
    }

    private void Update()
    {
        MoveForward();
        MoveSideways();
        HandleJump();
    }

    private void MoveForward()
    {
        // постоянное движение вперёд
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    private void MoveSideways()
    {
        // движение влево/вправо по старой системе ввода
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 sideMove = Vector3.right * horizontal * sideSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + sideMove);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            // сбрасываем вертикальную скорость перед прыжком
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // если столкновение с поверхностью снизу — обновляем прыжки
        if (collision.contacts.Length > 0 &&
            collision.contacts[0].normal.y > 0.5f)
        {
            jumpsLeft = maxJumps;
        }
    }

    public void IncreaseSpeed(float amount)
    {
        forwardSpeed += amount;
    }
}


