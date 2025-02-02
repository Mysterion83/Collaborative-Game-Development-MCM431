using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLinkSystem : MonoBehaviour
{
    [SerializeField]
    ObjectLinkSystem LinkedObject;
    [SerializeField]
    bool IsPresentObject;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (LinkedObject == null)
        {
            Destroy(gameObject);
        }
        if (!IsPresentObject && LinkedObject.transform.localPosition != transform.localPosition)
        {
            Vector3 LocalPos = transform.localPosition;
            LinkedObject.transform.localPosition = LocalPos;
        }
    }
}
