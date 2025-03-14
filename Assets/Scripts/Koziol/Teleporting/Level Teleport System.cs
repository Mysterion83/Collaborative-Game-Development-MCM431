using UnityEngine;
using UnityEngine.Rendering;

public class LevelTeleportSystem : MonoBehaviour
{
    [SerializeField]
    public bool IsAllowedToTeleport = true;

    [SerializeField]
    [Tooltip("The First Level Empty Object in the Scene")]
    private GameObject _levelOneObject;

    [SerializeField]
    [Tooltip("The Second Level Empty Object in the Scene")]
    private GameObject _levelTwoObject;


    [SerializeField]
    public LevelEnum CurrentLevel;

    [SerializeField]
    [Tooltip("The time it takes for the player to teleport while having the teleport screen effects play")]
    private float _TeleportDelay = 1f;

    [SerializeField]
    private float _currentTeleportTimer;

    [SerializeField]
    [Tooltip("The time it takes for the player to be allowed to teleport again while having the teleport screen effects play")]
    private float _cooldownTime = 3f;

    [SerializeField]
    private bool _isTeleporting = false;

    [SerializeField]
    [Tooltip("The Volume used for the teleport effects")]
    private Volume _volume;


    [SerializeField]
    KeyCode TeleportKey = KeyCode.T;

    private bool _isOnCooldown = false;

    private void Start()
    {
        _levelOneObject = GameObject.FindGameObjectWithTag("LevelOne");
        _levelTwoObject = GameObject.FindGameObjectWithTag("LevelTwo");

        _currentTeleportTimer = _TeleportDelay;

        _volume = GetComponent<Volume>();
        _volume.weight = 0f;

        gameObject.transform.parent = _levelOneObject.transform;
    }

    private void Update()
    {
        if (_isTeleporting)
        {
            PlayTeleportEffect();
        }
        else if (_isOnCooldown)
        {
            PlayCooldownEffect();
        }
        else if (Input.GetKeyDown(TeleportKey) && IsAllowedToTeleport)
        {
            _isTeleporting = true;
            _currentTeleportTimer = _TeleportDelay;
        }
    }
    private void FixedUpdate()
    {
        if (_currentTeleportTimer <= 0 && _isTeleporting)
        {
            Teleport();
        }
    }
    private void PlayTeleportEffect()
    {
        _currentTeleportTimer -= Time.deltaTime;
        _volume.weight = Mathf.Clamp01(1f - (_currentTeleportTimer / _TeleportDelay));
    }
    private void PlayCooldownEffect()
    {
        _volume.weight -= Time.deltaTime / _cooldownTime;
        if (_volume.weight <= 0f)
        {
            _isOnCooldown = false;
        }
    }
    private void Teleport()
    {
        Vector3 localPosition = gameObject.transform.localPosition;
        if (CurrentLevel == LevelEnum.LevelOne)
        {
            CurrentLevel = LevelEnum.LevelTwo;
            gameObject.transform.parent = _levelTwoObject.transform;
        }
        else
        {
            CurrentLevel = LevelEnum.LevelOne;
            gameObject.transform.parent = _levelOneObject.transform;
        }
        transform.localPosition = localPosition;

        _isTeleporting = false;
        _isOnCooldown = true;
    }
}