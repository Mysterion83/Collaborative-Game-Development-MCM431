using UnityEngine;

public class Door_Lever_Script : MonoBehaviour
{
    public string Lever_Name;
    public GameObject Library_Door;
    private Library_Door Door_Script;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        Door_Script = GameObject.Find(Door.name).GetComponent<Library_Door>();
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
                    Door_Script.Open();

                }
            }
        }
    }
}
