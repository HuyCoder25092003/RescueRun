using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Targeter targeter;
    public Transform trans;
    float speedMove;
    CharacterController characterController;
    PlayerDataBiding playerDataBiding;
    [SerializeField] float dot_attack;
    [SerializeField] float range_attack;
    private void Awake()
    {
        trans = transform;
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerDataBiding = GetComponent<PlayerDataBiding>();
        speedMove = DataController.instance.GetPlayerInfo().speed;
    }
    void Update()
    {
        Movement();
        if (targeter.CurrentTarget || targeter.SelectTarget())
        {
            TakeCat();
            targeter.CurrentTarget.GetComponent<CatScript>().ActiveArrow();
        }
    }
    void Movement()
    {
        float speed_mul = speedMove > 2 ? 2 : 1;
        Vector3 delta_move = InputManager.moveDir;
        if (delta_move.magnitude > 0 && delta_move != Vector3.zero)
            trans.forward = delta_move;
        float speed_anim = delta_move.magnitude;
        playerDataBiding.ForwardSpeed = speed_anim * speed_mul;
        if (!characterController.isGrounded)
        {
            delta_move.y = -1;
        }
        characterController.Move(delta_move * Time.deltaTime * speedMove);
    }
    void TakeCat()
    {
        float dis = Vector3.Distance(trans.position, targeter.CurrentTarget.transform.position);
        Vector3 dir = targeter.CurrentTarget.transform.position - trans.position;
        float dot = Vector3.Dot(dir.normalized, trans.forward);
        if (dot > dot_attack && dis <= range_attack)
        {
            MissionManager.instance.DetectCat();
            targeter.CurrentTarget.GetComponent<CatScript>().DisableCat();
            Destroy(targeter.CurrentTarget);
        }
    }
}
