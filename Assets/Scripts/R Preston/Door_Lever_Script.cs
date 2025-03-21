using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;




public class Door_Lever_Script : InteractableSwitch
{
    public string Lever_Name;
    public GameObject Library_Stairs_Object;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Button Accepted");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == Lever_Name)
                {
                    Interact();

                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Library_Stairs_Object.GetComponent<Library_Stairs>().Lever_State = _state;
        }
    }
    public override void Interact()
    {
        base.Interact();
        Library_Stairs_Object.GetComponent<Library_Stairs>().Lever_State = _state;
        Debug.Log(_state);
    }
}
