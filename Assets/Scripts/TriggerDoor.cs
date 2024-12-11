using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : DetectionZone
{

    public string doorOpenAnimatorParamName = "isOpen";

    public Animator animator;

    [SerializeField] private BoxCollider2D boxCollider;

    void Update()
    {
        
        if (detectedObjects.Count > 0){
            boxCollider.enabled = true;
            animator.SetBool(doorOpenAnimatorParamName, true);
        }

        else{
            boxCollider.enabled = false;
            animator.SetBool(doorOpenAnimatorParamName, false);
        }

    }

}
