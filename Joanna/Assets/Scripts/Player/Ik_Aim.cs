using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ik_Aim : MonoBehaviour
{
    public Transform lookAtObject;
    public Animator anim;
    public float weight;
    public float[] weights;

    private void OnAnimatorIK()
    {
        if(lookAtObject != null)
        {
            anim.SetLookAtWeight(weights[0], weights[1], weights[2], weights[3]);
            anim.SetLookAtPosition(lookAtObject.position);
            
        } 
    }
}
