using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;




public class Door_Lever_Script : InteractableSwitch
{
    public string Lever_Name;
    public GameObject Library_Stairs_Object;
    public float Start_Pos;
    public float End_Pos;
    public bool Called;
    public float Speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("Button Accepted");
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.name == Lever_Name)
        //        {
        //            Interact();
        //            Debug.Log("2");

        //        }
        //    }
        //}
        //Debug.Log(_state);
        //Debug.Log("4");
        if ((_state == false && Library_Stairs_Object.transform.position.y <= End_Pos) || _state == true && Library_Stairs_Object.transform.position.y >= Start_Pos)
        {
            Called = true;
        }
        if (Called == true)
        {
            //Debug.Log("Shit was Called? " + Called);
            if (_state == true)
            {
                //Debug.Log("One step beyond, I guess");
                //Debug.Log("Switch Detected!");
                if (Library_Stairs_Object.transform.position.y != End_Pos)
                {
                    //Debug.Log("Should be moving?");
                    //Debug.Log("Going Down! (Probably)");
                    if (((Start_Pos < 0) && (End_Pos < 0)) || ((Start_Pos > 0) && (End_Pos > 0)))
                    {
                        Library_Stairs_Object.transform.position -= new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                    }
                    else if ((Start_Pos > 0) && (End_Pos < 0))
                    {
                        Library_Stairs_Object.transform.position -= new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                    }
                    //Debug.Log("Gone Down! (Probably)");
                }
            }
            if (_state == false)
            {
                //Debug.Log("Going Up! (Probably)");
                if (((Start_Pos < 0) && (End_Pos < 0)) || ((Start_Pos > 0) && (End_Pos > 0)))
                {
                    Library_Stairs_Object.transform.position += new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                }
                else if ((Start_Pos > 0) && (End_Pos < 0))
                {
                    Library_Stairs_Object.transform.position += new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                }
                //Debug.Log("Gone Up! (Probably)");
                Called = true;
            }
        }
        if ((Library_Stairs_Object.transform.position.y >= Start_Pos && _state == false) || (Library_Stairs_Object.transform.position.y <= End_Pos && _state == true))
        {
            //Debug.Log("STOP!!");
            Called = false;
        }
        //if (Called == true)
        //{
        //    Interact();
        //}
    }
    //if (Input.GetKeyDown(KeyCode.E)) 
    //{
    //    Library_Stairs_Object.GetComponent<Library_Stairs>().Lever_State = _state;
    //    Debug.Log("3");
    //    Interact();
    //    Debug.Log("5");
    //}




    public override void Interact()
    {
        base.Interact();

    }
}
