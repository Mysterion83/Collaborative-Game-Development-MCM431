using UnityEngine;

public class ObjectLinkSystem : MonoBehaviour
{
    [SerializeField]
    private ObjectLinkSystem _linkedObject;

    [SerializeField]
    [Tooltip("If selected, any movement or rotation won't affect the other object")]
    private bool _isPresentObject;

    [SerializeField]
    [Tooltip("The minimum change in position per FixedUpdate tick for the other object's position to be set to the other object.")]
    [Range(0f, 10f)]
    private float _previousPositionDistanceLeeway = 0.0000001f;

    [SerializeField]
    [Tooltip("The minimum change in rotation per FixedUpdate tick for the other object's rotation to be set to the other object.")]
    [Range(0f, 180f)]
    private float _previousAngleLeeway = 0.0000001f;

    
    private Vector3 _previousPosition;
    private Quaternion _previousRotation;


    private void Start()
    {
        _previousPosition = transform.localPosition;
        _previousRotation = transform.localRotation;
    }
    private void FixedUpdate()
    {
        if (!ObjectLinkCheck()) return;
        if (!_isPresentObject && _linkedObject.transform.localPosition != transform.localPosition && Vector3.Distance(transform.localPosition, _previousPosition) > _previousPositionDistanceLeeway)
        {
            _linkedObject.transform.localPosition = transform.localPosition;
        }
        if (!_isPresentObject && _linkedObject.transform.localRotation != transform.localRotation && Quaternion.Angle(transform.localRotation, _previousRotation) > _previousAngleLeeway)
        {
            _linkedObject.transform.localRotation = transform.localRotation;
        }
        _previousPosition = transform.localPosition;
        _previousRotation = transform.localRotation;
    }

    public void ForceTeleport()
    {
        if (!ObjectLinkCheck()) return;
        if (_isPresentObject) _linkedObject.ForceTeleport();
        else
        {
            _linkedObject.transform.localPosition = transform.localPosition;
            _linkedObject.transform.localRotation = transform.localRotation;
        }
    }

    public bool ObjectLinkCheck()
    {
        if (_linkedObject == null)
        {
            Destroy(gameObject);
            return false;
        }
        return true;
    }
}
