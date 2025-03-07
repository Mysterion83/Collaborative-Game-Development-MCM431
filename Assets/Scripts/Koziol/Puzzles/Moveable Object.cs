using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int StartingPoint;
    [SerializeField]
    public Transform[] TravelPoints;
    [SerializeField]
    bool MoveObject = false;

    int Position;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = TravelPoints[StartingPoint].position;
        Position = StartingPoint + 1;
        MoveObjectToNextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveObject)
        {
            return;
        }
        if (Vector3.Distance(transform.position, TravelPoints[Position].position) < 0.2f)
        {
            ++Position;
            if (Position == TravelPoints.Length)
            {
                Position = 0;
            }
            MoveObject = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, TravelPoints[Position].position, speed * Time.deltaTime);
    }

    void MoveObjectToNextPosition()
    {
        MoveObject = true;
    }
}
