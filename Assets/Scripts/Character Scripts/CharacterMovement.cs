using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float currentInput;
    private bool canMove = true;

    [SerializeField] private float moveDistance = 1;
    [SerializeField][Range(0.1f, 1f)] private float moveSensitivity = 1f;
    [SerializeField][Range(0.1f, 15f)] private float rotateSensitivity = 1f;

    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        float xValue = Input.GetAxisRaw("Horizontal");

        int input = Mathf.RoundToInt(xValue);

        float endPoint = input * moveDistance;

        if (input != 0 && canMove)
        {
            if (currentInput + endPoint > moveDistance || currentInput + endPoint < -moveDistance) return;

            canMove = false;

            if (currentInput != endPoint)
            {
                currentInput = endPoint;
            }
        }
        else if (input == 0 && canMove == false)
        {
            canMove = true;
        }

        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 targetPosition = new Vector3(currentInput, rb.position.y, rb.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, moveSensitivity);

        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);

        //Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSensitivity * Time.deltaTime);
    }
}
