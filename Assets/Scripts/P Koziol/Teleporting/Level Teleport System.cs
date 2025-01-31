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
    Volume vol;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTeleportTimer = TeleportDelay;
        CurrentCooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTeleportTimer -= Time.deltaTime;
        if (CurrentTeleportTimer < TeleportDelay)
        {
            vol.weight = (1f / Mathf.Abs(CurrentTeleportTimer) - (1 / TeleportDelay));
        }
        else vol.weight = 0f;

        if (IsTeleporting)
        {
            if (CurrentTeleportTimer <= 0) 
            {
                Teleport();
                CurrentCooldownTimer = CooldownTime;
                IsTeleporting = false;
            }

        }
        else if (CurrentCooldownTimer > 0)
        {
            CurrentCooldownTimer -= Time.deltaTime;
        }
        else
        {
            CurrentTeleportTimer = TeleportDelay;
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                IsTeleporting = true;
            }
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
