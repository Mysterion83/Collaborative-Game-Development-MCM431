using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class LibraryStairs : MonoBehaviour
{
    [SerializeField] private InteractableSwitch interactableSwitch;
    private Animator animator;

    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;

    void Start()
    {
        startPosition = transform.position.y;
        animator.SetFloat("TrLowerStairs", endPosition);
        animator.SetFloat("TrRaiseStairs", startPosition);
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (interactableSwitch.State == true)
        {
            Debug.Log("Switch On");
            //transform.position = endPosition;
            //animator.SetTrigger("TrLowerStairs");
        }
        else if (interactableSwitch.State == false)
        {
            Debug.Log("Switch Off");
            //transform.position = startPosition;
            //animator.SetTrigger("TrRaiseStairs");
        }
    }
}
