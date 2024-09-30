using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDetected : MonoBehaviour
{
    [SerializeField] Transform currentTarget;
    [SerializeField] float timeCount;
    [SerializeField] float timeRun;
    Transform trans;
    [SerializeField] float speed;
    bool hitPlayer;
    void Start()
    {
        trans = transform;
        if(currentTarget == null)
            StartCoroutine(WaitFindPlayer());
    }
    IEnumerator WaitFindPlayer()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        while (true)
        {
            yield return wait;
            currentTarget = GameObject.Find("Player").transform;
            if (currentTarget != null)
                break;
        }
    }
    void Update()
    {
        if (ViewManager.instance.cur_view is not IngameView)
            return;
        if (currentTarget == null)
            return;
        if (timeCount >= timeRun)
        {
            Vector3 direction = (currentTarget.position - trans.position).normalized;

            trans.Translate(speed * Time.deltaTime * direction);
        }
        else
            timeCount += Time.deltaTime;
    }
    void OnParticleCollision(GameObject other)
    {
        if (hitPlayer)
            return;
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            DialogManager.instance.ShowDialog(DialogIndex.FailDialog);
            hitPlayer = true;
        }
    }
}
