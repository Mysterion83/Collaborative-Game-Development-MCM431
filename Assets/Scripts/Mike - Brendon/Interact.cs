using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera fpsCamera;
    public float range = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0f, 0f, 0)); // This is assuming your crosshair is in the middle of the screen
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                GameObject rotatingButton = hit.transform.gameObject;
                if (rotatingButton.GetComponent<Rotating_Switches>() != null)
                {
                    rotatingButton.GetComponent<Rotating_Switches>().Rotate();
                }
                else
                {
                    Debug.Log(rotatingButton.name);
                }
            }
        }
    }
}

