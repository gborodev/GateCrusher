using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;

    private int currentInput;
    private bool canMove = true;

    [SerializeField] private float moveDistance = 1;
    [SerializeField] private float moveSpeed = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        float xValue = Input.GetAxisRaw("Horizontal");

        int input = Mathf.RoundToInt(xValue);

        if (input != 0 && canMove)
        {
            if (currentInput + input > moveDistance || currentInput + input < -moveDistance) return;

            canMove = false;

            if (currentInput != currentInput + input)
            {
                currentInput += input;
            }
        }
        else if (input == 0 && canMove == false)
        {
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(currentInput * moveDistance, rb.position.y, rb.position.z);

        rb.velocity = Vector3.Lerp(rb.position, move, moveSpeed * Time.fixedDeltaTime);
    }

    private void MoveCharacter()
    {


        Debug.Log("Move Position: " + currentInput);
    }
}
