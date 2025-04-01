using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class LibraryStairs : MonoBehaviour
{
    [SerializeField] private InteractableSwitch interactableSwitch;
    [SerializeField] public Animator animator;

    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;

    void Start()
    {
        startPosition = transform.position.y;
        animator.SetFloat("TrLowerStairs", endPosition);
        animator.SetFloat("TrRaiseStairs", startPosition);
        animator = GetComponent<Animator>();
    }

    //void FixedUpdate()
    //{
    //    if (interactableSwitch.State == true)
    //    {
    //        //transform.position = endPosition;
    //        animator.SetTrigger("TrLowerStairs");
    //        //Debug.Log("Stairs Lowering");
    //    }
    //    else if (interactableSwitch.State == false)
    //    {
    //        //Debug.Log("Switch Off");
    //        //transform.position = startPosition;
    //        animator.SetTrigger("TrRaiseStairs");
    //    }
    //}
    public void Stairsdown() 
    {
        //animator.SetTrigger("TrLowerStairs");
        //Debug.Log("Stairs Lowering 2");
        if (interactableSwitch.State == true)
        {
            //transform.position = endPosition;
            animator.SetTrigger("TrLowerStairs");
            Debug.Log("Stairs Lowering");
        }
        else if (interactableSwitch.State == false)
        {
            Debug.Log("Switch Off");
            //transform.position = startPosition;
            animator.SetTrigger("TrRaiseStairs");
        }
    }
}
