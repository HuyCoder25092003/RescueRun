using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsDialog : BaseDialog
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
    public void OnBack()
    {
        DialogManager.instance.HideDialog(dialogIndex);
        if (ViewManager.instance.cur_view is IngameView)
            DialogManager.instance.ShowDialog(DialogIndex.PauseDialog);
    }
}

