using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialog : BaseDialog
{
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
    public void OnContinue()
    {
        DialogManager.instance.HideDialog(DialogIndex.PauseDialog);
    }
    public void OnQuit()
    {
        DialogManager.instance.HideDialog(dialogIndex);
        LoadSceneManager.instance.LoadSceneByIndex(1, () =>
        {
            ViewManager.instance.SwitchView(ViewIndex.HomeView);
        });
    }
    public void OnSettings()
    {
        DialogManager.instance.HideDialog(dialogIndex);
        DialogManager.instance.ShowDialog(DialogIndex.SettingsDialog);
    }
    public void OnRestart()
    {
        DialogManager.instance.HideDialog(dialogIndex);
        LoadSceneManager.instance.LoadSceneByName(GameManager.instance.cur_cf_mission.SceneName, () =>
        {
            ViewManager.instance.SwitchView(ViewIndex.IngameView);
        });
    }
}
