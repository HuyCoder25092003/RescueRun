using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBiding : MonoBehaviour
{
    public Animator animator;
    int Anim_K_forwardSpeed;
    int Anim_K_Jump;
    float cur_forward_speed;
    const string forwardSpeed = "forwardSpeed"; 
    const string jump = "jump";
    public float ForwardSpeed
    {
        set
        {
            cur_forward_speed = value;
        }
    }
    public bool Jump
    {
        set
        {
            if (value)
                animator.CrossFadeInFixedTime(Anim_K_Jump, 0.2f, 0, Time.deltaTime);
        }
    }
    void Start()
    {
        Anim_K_forwardSpeed = Animator.StringToHash(forwardSpeed);
        Anim_K_Jump = Animator.StringToHash(jump);
    }
    void Update()
    {
        animator.SetFloat(Anim_K_forwardSpeed, cur_forward_speed, 0.2f, Time.deltaTime);
    }
}
