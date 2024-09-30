using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets = new List<Target>();
    public Target CurrentTarget { get; private set; }
    Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }

        targets.Add(target);
        target.OnDestroyed.AddListener(RemoveTarget);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }

        targets.Remove(target);
        RemoveTarget(target);
    }
    public void Cancel()
    {
        if (CurrentTarget == null)  
            return;

        CurrentTarget = null;
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) 
            return false;

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach (Target target in targets)
        {
            Vector2 viewPos = mainCamera.WorldToViewportPoint(target.transform.position);

            if (!target.GetComponentInChildren<Renderer>().isVisible)
                continue;

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);
            if (toCenter.sqrMagnitude < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = toCenter.sqrMagnitude;
            }
        }

        if (closestTarget == null) 
            return false;

        CurrentTarget = closestTarget;

        return true;
    }
    void RemoveTarget(Target target)
    {
        if (CurrentTarget == target)
            CurrentTarget = null;
        targets.Remove(target);
        target.OnDestroyed.RemoveListener(RemoveTarget);
    }
}
