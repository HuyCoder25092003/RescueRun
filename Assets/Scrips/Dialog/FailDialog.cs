using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailDialog : BaseDialog
{
    [SerializeField] int countRestart;
    [SerializeField] Button btn_ReplayGame;
    public override void OnShowDialog()
    {
        base.OnShowDialog();
        Time.timeScale = 0;
    }
    public override void OnHideDialog()
    {
        base.OnHideDialog();
        Time.timeScale = 1;
    }
    public void OnBack()
    {
        DialogManager.instance.HideDialog(DialogIndex.FailDialog);
        LoadSceneManager.instance.LoadSceneByIndex(1, () =>
        {
            ViewManager.instance.SwitchView(ViewIndex.HomeView);
        });
    }
    public void ReplayGame()
    {
        DialogManager.instance.HideDialog(DialogIndex.FailDialog);
        ViewManager.instance.SwitchView(ViewIndex.EmptyView);
        LoadSceneManager.instance.LoadSceneByName(MissionManager.instance.cf_mission.SceneName, () =>
        {
            ViewManager.instance.SwitchView(ViewIndex.IngameView);
        });
    }
}
