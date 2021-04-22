using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public int weight = 1;
    public int radius = 4;
    public CameraTargetSet cameraTargetSet;
    void OnEnable()
    {
        if (cameraTargetSet != null)
        {
            cameraTargetSet.Add(this);
        }
        else
        {
            Debug.LogWarning("No Camera Target Set Found");
        }
    }

    void OnDisable()
    {
        if (cameraTargetSet != null)
        {
            cameraTargetSet.Remove(this);
        }
    }

}
