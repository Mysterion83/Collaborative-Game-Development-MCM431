using UnityEngine;
using UnityEngine.Rendering;

public class LevelTeleportSystem : MonoBehaviour
{
    [SerializeField]
    GameObject LevelOneObject;
    [SerializeField]
    GameObject LevelTwoObject;

    [SerializeField]
    LevelEnum levelEnum;

    [SerializeField]
    float TeleportDelay = 1f;
    [SerializeField]
    float CurrentTeleportTimer;

    [SerializeField]
    float CooldownTime = 3f;
    [SerializeField]
    float CurrentCooldownTimer;

    [SerializeField]
    bool IsTeleporting = false;

    [SerializeField]
    Volume volume;

    private bool IsFadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTeleportTimer = TeleportDelay;
        CurrentCooldownTimer = 0;
        volume.weight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTeleporting)
        {
            CurrentTeleportTimer -= Time.deltaTime;
            volume.weight = Mathf.Clamp01(1f - (CurrentTeleportTimer / TeleportDelay));

            if (CurrentTeleportTimer <= 0)
            {
                Teleport();
                CurrentCooldownTimer = CooldownTime;
                IsTeleporting = false;
                IsFadingOut = true;
            }
        }
        else if (IsFadingOut)
        {
            volume.weight -= Time.deltaTime / CooldownTime;
            if (volume.weight <= 0f) 
            {
                IsFadingOut = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            IsTeleporting = true;
            CurrentTeleportTimer = TeleportDelay;
        }
    }

    void Teleport()
    {
        Vector3 LocalPosition = gameObject.transform.localPosition;
        if (levelEnum == LevelEnum.LevelOne)
        {
            levelEnum = LevelEnum.LevelTwo;
            gameObject.transform.parent = LevelTwoObject.transform;
        }
        else
        {
            levelEnum = LevelEnum.LevelOne;
            gameObject.transform.parent = LevelOneObject.transform;
        }
        transform.localPosition = LocalPosition;
    }
}
