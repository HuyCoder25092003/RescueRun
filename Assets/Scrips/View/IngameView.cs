using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameView : BaseView
{
    public Joystick joyStick;
    [SerializeField]IngameUI ingameUI;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        ingameUI = GameObject.Find("UIControl").GetComponent<IngameUI>();
        ingameUI.Joystick = joyStick;
    }
    public void OnPause()
    {
        DialogManager.instance.ShowDialog(DialogIndex.PauseDialog);
    }
}
