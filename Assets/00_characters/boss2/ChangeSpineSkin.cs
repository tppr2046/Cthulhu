using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class ChangeSpineSkin : MonoBehaviour
{
    SkeletonMecanim skeletonMecanim;


    void Awake()
    {
        skeletonMecanim = GetComponent<SkeletonMecanim>();

    }

    public void ChangeSkin(string SkinName)
    {
        skeletonMecanim.Skeleton.SetSkin(SkinName);
        skeletonMecanim.Skeleton.SetSlotsToSetupPose();
    }
}
