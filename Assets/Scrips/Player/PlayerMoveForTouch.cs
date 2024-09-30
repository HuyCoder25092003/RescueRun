using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveForTouch : MonoBehaviour
{
    CharacterController controller;
    Vector3 dir;
    [SerializeField] float speed, baseSpeed;
    [SerializeField] float maxSpeed;
    PlayerDataBiding playerDataBiding;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerDataBiding = GetComponent<PlayerDataBiding>();
        speed = baseSpeed;
    }

    void Update()
    {
        if (ViewManager.instance.cur_view is HomeView)
        {
            if (TouchController.instance.isTouching)
            {
                DataController.instance.AddGold(2);
                speed += 0.01f;
                if (speed > maxSpeed)
                    speed = maxSpeed;
                playerDataBiding.ForwardSpeed = 1;
            }
            else
            {
                speed = baseSpeed;
                playerDataBiding.ForwardSpeed = 0;
            }
            dir.y = 0;
            dir.z = speed;
            controller.Move(dir * Time.deltaTime);
        }
    }
}
