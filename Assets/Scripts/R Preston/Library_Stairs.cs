using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Library_Stairs : MonoBehaviour
{
    public GameObject Stairs_Switch;
    public float Start_Pos;
    public float End_Pos;
    public bool Called;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Stairs_Switch = GameObject.Find(this.gameObject.name + " Switch");
        //Debug.Log("Stairs_Switch name = " + Stairs_Switch);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Called == true) 
        {
            if (Stairs_Switch.GetComponent<InteractableSwitch>().State == true)
            {
                //Debug.Log("Switch Detected!");
                if (this.transform.position.y != End_Pos)
                {
                    //Debug.Log("Going Down! (Probably)");
                    transform.position -= new Vector3(0, ( ((Mathf.Abs(Start_Pos) / Mathf.Abs( End_Pos)) / 100) * (Time.deltaTime * Speed)), 0);
                    //Debug.Log("Gone Down! (Probably)");
                    Called = true;
                }
            }
            else 
            {
                //Debug.Log("Going Up! (Probably)");
                transform.position += new Vector3(0, (((Mathf.Abs(Start_Pos) / Mathf.Abs(End_Pos)) / 100) * (Time.deltaTime * Speed)), 0);
                //Debug.Log("Gone Up! (Probably)");
                Called = true;
            }
        }
        if (this.transform.position.y >= Start_Pos || this.transform.position.y <= End_Pos) 
        {
            Called = false;
        }
    }
    //Mathf.Abs sets the values to an absolute value to prevent the stairs from going up when called down etc. if the destination point is a negative value. This does mean the stairs tehcnically reach their destination slower than if the End_Pos is a negative value and the End Point isn't, and speeds may vary if the Start_Pos is equal to 1 and End_Pos is equal to -200. Keep this in mind.
    //Also for some reason the "Lever" I set up doesn't change state when interacted with? It had the 'Interactable Switch' Script and I was using the player prefab which should be able to interact with it, but...it didn't work, at least in my testing level. I assume this script works and I have tested it - though exclusively in the 'false' state due to prior limitations.
}
