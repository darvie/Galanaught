using UnityEngine;
using UnityEngine.Events;

public class InputManager : SingletonMonoBehavior<InputManager>
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnFire;


    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            input += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            input += Vector2.down;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            input += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            input += Vector2.right;
        }

        OnMove?.Invoke(input);
    }
}
