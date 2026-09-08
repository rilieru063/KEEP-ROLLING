using UnityEngine;
using UnityEngine.InputSystem;

public class Operation : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
            Move(0.1f, 0.0f);

        if (Keyboard.current.sKey.isPressed)
            Move(-0.1f, 0.0f);

        if (Keyboard.current.aKey.isPressed)
            Move(0.0f, 0.1f);

        if (Keyboard.current.dKey.isPressed)
            Move(0.0f, -0.1f);
    }

    void Move(float px, float pz)
    {
        transform.Rotate(px, 0, pz);
    }
}
