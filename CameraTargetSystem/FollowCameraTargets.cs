using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineTargetGroup))]
public class FollowCameraTargets : MonoBehaviour
{
    public CameraTargetSet targets;
    public Transform defaultTarget;
    private CinemachineTargetGroup targetGroup;
    private List<CameraTarget> previousTargetList = new List<CameraTarget>();
    private readonly CinemachineTargetGroup.Target[] EMPTY_TARGET_LIST = new CinemachineTargetGroup.Target[0];
    // Start is called before the first frame update
    void Start()
    {
        targetGroup = GetComponent<CinemachineTargetGroup>();
        targetGroup.AddMember(defaultTarget, 1, 4);
    }
    // TODO: make this more performant
    void Update()
    {
        if (targets.items.Count > 0)
        {
            if (targetGroup.FindMember(defaultTarget) != -1)
            {
                targetGroup.RemoveMember(defaultTarget);
            }
            UpdateTargetGroup();
        }
        else
        {
            ResetTargetGroup();
            if (targetGroup.FindMember(defaultTarget) == -1)
            {
                targetGroup.AddMember(defaultTarget, 1, 4);
            }
        }

        previousTargetList = new List<CameraTarget>(targets.items);
    }

    private void ResetTargetGroup()
    {
        targetGroup.m_Targets = EMPTY_TARGET_LIST;
    }

    private void UpdateTargetGroup()
    {
        ResetTargetGroup();
        foreach (CameraTarget target in targets.items)
        {
            if (target.enabled)
            {
                targetGroup.AddMember(target.transform, target.weight, target.radius);
            }
        }
    }

}
