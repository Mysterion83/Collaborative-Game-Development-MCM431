using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Library_Stairs : MonoBehaviour
{
    [Serialize] public bool Lever_State;
    public GameObject Stairs_Switch;
    public float Start_Pos;
    public float End_Pos;
    public bool Called;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //Stairs_Switch = GameObject.Find(this.gameObject.name + " Switch");
        //Debug.Log("Stairs_Switch name = " + Stairs_Switch);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Cooldown_Timer < 10) 
        //{
        //    Cooldown_Timer += (1 * Time.deltaTime);
        //    Debug.Log("Timer = " + Cooldown_Timer);
        //}
        if ((Lever_State == false && transform.position.y <= End_Pos) || (Lever_State == true && transform.position.y >= Start_Pos)) 
        {
            Called = true;
        }
        if (/*Input.GetKeyDown(KeyCode.G) || */Called == true)
        {
            //Debug.Log("Shit was Called? " + Called);
            if (Lever_State == true)
            {
                //Debug.Log("One step beyond, I guess");
                //Debug.Log("Switch Detected!");
                if (this.transform.position.y != End_Pos)
                {
                    //Debug.Log("Should be moving?");
                    //Debug.Log("Going Down! (Probably)");
                    //transform.position -= new Vector3(0, (((Mathf.Abs(Start_Pos) / Mathf.Abs(End_Pos)) / 100) * (Time.deltaTime * Speed)), 0);
                    if (((Start_Pos < 0) && (End_Pos < 0)) || ((Start_Pos > 0) && (End_Pos > 0))) 
                    {
                        transform.position -= new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                    }
                    else if ((Start_Pos > 0) && (End_Pos < 0))
                    {
                        transform.position -= new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                    }
                    //Debug.Log("Gone Down! (Probably)");
                }
            }
            if (Lever_State == false)
            {
                //Debug.Log("Going Up! (Probably)");
                //transform.position += new Vector3(0, (((Mathf.Abs(Start_Pos) / Mathf.Abs(End_Pos)) / 100) * (Time.deltaTime * Speed)), 0);
                if (((Start_Pos < 0) && (End_Pos < 0)) || ((Start_Pos > 0) && (End_Pos > 0)))
                {
                    transform.position += new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                }
                else if ((Start_Pos > 0) && (End_Pos < 0))
                {
                    transform.position += new Vector3(0, ((((Start_Pos - End_Pos) / Speed) * Time.deltaTime)), 0);
                }
                //Debug.Log("Gone Up! (Probably)");
                Called = true;
            }
        }
        if (((this.transform.position.y >= Start_Pos && Lever_State == false) || (this.transform.position.y <= End_Pos && Lever_State == true))) 
        {
            Called = false;
        }
    }
    //This should work fine - even when using negative values. The speed at which the stairs move might be slower than usual if the Start_Pos is a positive value and the End_Pos is a negative value, but that can be compensated for by adjusting the Speed variable accordingly. DO NOT set Start_Pos to a higher value than End_Pos - this code was built for a set of stairs that move down first!
    //If you want to make an object go up first, ensure the levers' _state is set to 'true' at the beginning, and place it at the End_Pos.
}
