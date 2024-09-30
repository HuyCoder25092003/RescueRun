using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : BYSingletonMono<TouchController>
{
    [SerializeField] int idFingerDrag = -1;
    [SerializeField] int idFingerDrag_fire = -1;
    public bool isTouching = false;
    private bool IsPointerOverUIButtonObject(Vector2 pos)
    {
        if (EventSystem.current != null)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = pos;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            foreach (RaycastResult e in results)
            {
                if (e.gameObject.name == "Button_Setting" || e.gameObject.name == "Button_Run" ||
                   e.gameObject.name == "Icon_Run" || e.gameObject.name == "Text_Speed" || e.gameObject.name == "Text_Buy_Run"
                   || e.gameObject.name == "Button_Stamina" || e.gameObject.name == "Icon_Stamina" || e.gameObject.name == "Text_Stamina"
                   || e.gameObject.name == "Text_Buy_Stamina" || e.gameObject.name == "Button_Income" || e.gameObject.name == "Icon_Income"
                   || e.gameObject.name == "Text_Buy_Income" || e.gameObject.name == "Button_Stage" || e.gameObject.name == "Icon_Stage"
                   || e.gameObject.name == "Text_Stage" || e.gameObject.name == "Button_Battle" || e.gameObject.name == "Icon_Battle"
                   || e.gameObject.name == "Text_Battle" || e.gameObject.name == "Button_Add_Gold" || e.gameObject.name == "Icon_Gold"
                   || e.gameObject.name == "Button_Add_Gem" || e.gameObject.name == "IconGem")
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current != null)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = pos;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            foreach (RaycastResult e in results)
            {
                Debug.Log(e.gameObject.name);
                if (e.gameObject.name == "Button_Setting"|| e.gameObject.name == "Button_Run" ||
                    e.gameObject.name == "Icon_Run" || e.gameObject.name == "Text_Speed" || e.gameObject.name == "Text_Buy_Run"
                    || e.gameObject.name == "Button_Stamina" || e.gameObject.name == "Icon_Stamina" || e.gameObject.name == "Text_Stamina"
                    || e.gameObject.name == "Text_Buy_Stamina" || e.gameObject.name == "Button_Income" || e.gameObject.name == "Icon_Income"
                    || e.gameObject.name == "Text_Buy_Income" || e.gameObject.name == "Button_Stage" || e.gameObject.name == "Icon_Stage" 
                    || e.gameObject.name == "Text_Stage" || e.gameObject.name == "Button_Battle" || e.gameObject.name == "Icon_Battle"
                    || e.gameObject.name == "Text_Battle" || e.gameObject.name == "Button_Add_Gold" || e.gameObject.name == "Icon_Gold" 
                    || e.gameObject.name == "Button_Add_Gem" || e.gameObject.name == "IconGem")
                {
                    return false;
                }
            }
            return results.Count > 0;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
#if UNITY_EDITOR || USING_PC_VERSION
        Vector2 mousePosition = Input.mousePosition;
        if (!IsPointerOverUIButtonObject(mousePosition) && ViewManager.instance.cur_view is HomeView && DialogManager.instance.current_dl == null)
        {
            if (Input.GetMouseButton(0))
                isTouching = true;
            else if(Input.GetMouseButtonDown(0))
                isTouching = true;
            else
                isTouching = false;
        }
        else
            isTouching = false;
#else
        if (Input.touchCount > 0)
        {
            bool ishaskTouchInside = false;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                int pointerID = touch.fingerId;
                if (!IsPointerOverUIButtonObject(touch.position) && ViewManager.instance.cur_view is HomeView && DialogManager.instance.current_dl == null)
                {
                    ishaskTouchInside = true;
                    isTouching = true;
                    if (idFingerDrag != -1)
                    {
                        if (pointerID == idFingerDrag)
                        {
                            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
                            {
                                idFingerDrag = -1;
                                isTouching = false;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            idFingerDrag = pointerID;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                int pointerID = touch.fingerId;
                if (IsPointerOverUIButtonObject(touch.position) && ViewManager.instance.cur_view is HomeView && DialogManager.instance.current_dl == null)
                {
                    ishaskTouchInside = true;
                    isTouching = false;
                    if (idFingerDrag_fire != -1)
                    {
                        if (pointerID == idFingerDrag_fire)
                        {
                            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
                            {
                                idFingerDrag_fire = -1;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            idFingerDrag_fire = pointerID;
                            break;
                        }
                    }
                }
            }
            if (!ishaskTouchInside)
                idFingerDrag = -1;
        }
        else
        {
            idFingerDrag = -1;
            isTouching = false;
        }
#endif 
    }
}