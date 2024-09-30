using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngameUI : MonoBehaviour
{
    [SerializeField]
    Joystick joystick;
    public UnityEvent<Vector3> onMoveEvent;
    Vector3 mov;
    public Joystick Joystick { get => joystick; set => joystick = value; }
    void Update()
    {
        if (joystick != null)
        {
            mov = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            onMoveEvent?.Invoke(mov);
        }
    }
}
