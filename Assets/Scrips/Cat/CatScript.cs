using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    [SerializeField] GameObject activeArrow;
    public void ActiveArrow()
    {
        activeArrow.SetActive(true);
    }
    public void DisableCat()
    {
        gameObject.SetActive(false);
    }
}
