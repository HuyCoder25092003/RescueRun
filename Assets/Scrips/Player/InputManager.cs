using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class InputManager : BYSingletonMono<InputManager>
{
    public static Vector3 moveDir;
#if UNITY_EDITOR || USING_PC_VERSION
    public void OnMove_System(CallbackContext ctx)
    {
        var value = ctx.ReadValue<Vector2>();
        moveDir = new Vector3(value.x, 0, value.y);
    }
#else
    public void OnMove(Vector3 mov)
    {
       moveDir = mov;
    }
#endif
}
