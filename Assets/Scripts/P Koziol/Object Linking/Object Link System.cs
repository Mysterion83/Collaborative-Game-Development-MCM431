using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLinkSystem : MonoBehaviour
{
    [SerializeField]
    ObjectLinkSystem LinkedObject;
    [SerializeField]
    bool IsPresentObject;

    [SerializeField]
    float PreviousPositionDistanceLeeway = 0.0000001f;
    [SerializeField]
    float PreviousAngleLeeway = 0.0000001f;
    [SerializeField]
    Vector3 PreviousPosition;
    [SerializeField]
    Quaternion PreviousRotation;


    // Start is called before the first frame update
    void Start()
    {
        PreviousPosition = transform.localPosition;
        PreviousRotation = transform.localRotation;
    }
    private void FixedUpdate()
    {
        if (LinkedObject == null)
        {
            Destroy(gameObject);
        }
        if (!IsPresentObject && LinkedObject.transform.localPosition != transform.localPosition && Vector3.Distance(transform.localPosition, PreviousPosition) > PreviousPositionDistanceLeeway)
        {
            Vector3 LocalPos = transform.localPosition;
            LinkedObject.transform.localPosition = LocalPos;
        }
        if (!IsPresentObject && LinkedObject.transform.localRotation != transform.localRotation && Quaternion.Angle(transform.localRotation, PreviousRotation) > PreviousAngleLeeway)
        {
            Quaternion LocalRot = transform.localRotation;
            LinkedObject.transform.localRotation = LocalRot;
        }
        PreviousPosition = transform.localPosition;
        PreviousRotation = transform.localRotation;
    }
}
