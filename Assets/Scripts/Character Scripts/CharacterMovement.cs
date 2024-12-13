using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;

    private int currentInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        int input = Mathf.RoundToInt(x);

        if (currentInput != currentInput + input)
        {
            currentInput += input;

            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        Debug.Log("Move Position: " + currentInput);
    }
}
