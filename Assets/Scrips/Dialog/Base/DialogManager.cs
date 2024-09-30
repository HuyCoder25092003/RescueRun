using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogManager : BYSingletonMono<DialogManager>
{
    public RectTransform anchor_dl;
    private Dictionary<DialogIndex, BaseDialog> dic = new Dictionary<DialogIndex, BaseDialog>();
    private List<BaseDialog> ls_dialog = new List<BaseDialog>();
    public BaseDialog current_dl = null;
    void Start()
    {
        foreach(DialogIndex index in DialogConfig.dialogIndices)
        {
            string name_dialog = index.ToString();
            GameObject dl_obj = Instantiate(Resources.Load("Dialog/" + name_dialog, typeof(GameObject))) as GameObject;
            dl_obj.transform.SetParent(anchor_dl, false);

            BaseDialog dl = dl_obj.GetComponent<BaseDialog>();
            dic.Add(index, dl);
            dl_obj.SetActive(false);
        }
    }
    public void ShowDialog(DialogIndex index,DialogParam param=null,Action callback=null)
    {
        current_dl = dic[index];

        Action cb = () =>
        {
            callback?.Invoke();
        };
        current_dl.gameObject.SetActive(true);
        current_dl.Setup(param);
        current_dl.SendMessage("ShowDialog", (object)cb, SendMessageOptions.RequireReceiver);
        if(!ls_dialog.Contains(current_dl))
        {
            ls_dialog.Add(current_dl);
        }
    }
 

    public void HideDialog(DialogIndex index,  Action callback=null)
    {
        current_dl = dic[index];

        Action cb = () =>
        {
            callback?.Invoke();
            current_dl.gameObject.SetActive(false);
            current_dl = null;

        };
        current_dl.SendMessage("HideDialog", (object)cb, SendMessageOptions.RequireReceiver);
        if (ls_dialog.Contains(current_dl))
        {
            ls_dialog.Remove(current_dl);
        }
    }
    public void HideAllDialog()
    {
        foreach(BaseDialog dl in ls_dialog)
        {
            Action cb = () =>
            {
                dl.gameObject.SetActive(false);

            };
            dl.SendMessage("HideDialog", (object)cb, SendMessageOptions.RequireReceiver);
        }
        ls_dialog.Clear();
        current_dl = null;
    }
   
}
