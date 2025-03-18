using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    Animator CreditsAnimator;

    void Start()
    {
        CreditsAnimator = GetComponent<Animator>();
    }

    // Loads main menu once credits animation is over
    void Update()
    {
        if (CreditsAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Debug.Log("Credits animation ended");
            SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
        }
    }

}
