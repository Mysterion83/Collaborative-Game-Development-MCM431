using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CommandConsole : MonoBehaviour
{
    public static CommandConsole Instance { get { return _instance; } }
    private static CommandConsole _instance;


    private bool _consoleEnabled;

    [SerializeField]
    public GameObject ConsoleUI;

    [SerializeField]
    public TMP_InputField _userInput;

    [SerializeField]
    public TextMeshProUGUI _consoleText;

    [SerializeField]
    private string[] StartingArgs;

    [SerializeField]
    private bool _startWithArgs;

    public static DebugCommand HELP;

    public static DebugCommand<float, float, float, int> TELEPORT;
    public static DebugCommand<int> MAXFPS;
    public static DebugCommand<float> TIMESCALE;


    public static DebugCommand<int> I_ADDITEM;
    public static DebugCommand<int> I_REMOVEITEM;

    public static DebugCommand LVL_DESTROY;
    public static DebugCommand<int> LVL_LOADSCENE;
    public static DebugCommand LVL_RELOADSCENE;

    public static DebugCommand<float> C_FOV;
    public static DebugCommand<float> C_MINDISTANCE;
    public static DebugCommand<float> C_MAXDISTANCE;

    public static DebugCommand<int> CL_DEBUG;

    public List<object> CommandList;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        HELP = new DebugCommand("help", "Displays all available commands", "help", () =>
        {
            string helpText = "Available Commands: \n";
            foreach (object command in CommandList)
            {
                DebugCommandBase commandBase = command as DebugCommandBase;
                helpText += commandBase.CommandID + " - " + commandBase.CommandDescription + " - " + commandBase.CommandFormat +  "\n";
            }
            _consoleText.text += helpText;
        });
        LVL_DESTROY = new DebugCommand("lvl_destroy", "Destroys the console", "destroy", () =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Ray DestructionRay = new Ray(camera.transform.position, camera.transform.forward);
            if (!Physics.Raycast(DestructionRay, out RaycastHit hit, 5f)) //Raycast Check to see if the ray hit something
            {
                return;
            }
            Destroy(hit.collider.gameObject);
        });
        TELEPORT = new DebugCommand<float, float, float, int>("teleport", "Teleports the player to a location", "teleport <x> <y> <z> <teleport type>", (x, y, z, i) =>
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (i == 0)
            {
                player.transform.position = new Vector3(x, y, z);
            }
            else
            {
                player.transform.localPosition = new Vector3(x, y, z);
            }
        });
        MAXFPS = new DebugCommand<int>("maxfps", "Sets the maximum frame rate", "maxfps <FPS Amount>", (x) =>
        {
            Application.targetFrameRate = x;
        });
        TIMESCALE = new DebugCommand<float>("timescale", "Sets the time scale of the game", "timescale <Timescale Amount>", (x) =>
        {
            Time.timeScale = x;
        });
        I_ADDITEM = new DebugCommand<int>("i_additem", "Adds an item to the player's inventory", "i_additem <item id>", (x) =>
        {
            Debug.LogError("I_ADDITEM command not implemented");
        });
        I_REMOVEITEM = new DebugCommand<int>("i_removeitem", "Removes an item from the player's inventory", "i_removeitem <item id>", (x) =>
        {
            Debug.LogError("I_REMOVEITEM command not implemented");
        });
        LVL_LOADSCENE = new DebugCommand<int>("lvl_loadscene", "Loads a scene", "lvl_loadscene <scene id>", (x) =>
        {
            SceneManager.LoadScene(x);
        });
        LVL_RELOADSCENE = new DebugCommand("lvl_reloadscene", "Reloads the current scene", "lvl_reloadscene", () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        C_FOV = new DebugCommand<float>("c_fov", "Sets the field of view of the camera", "c_fov <FOV Value>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().fieldOfView = x;
        });
        C_MINDISTANCE = new DebugCommand<float>("c_mindistance", "Sets the minimum distance of the camera", "c_mindistance <Distance>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().nearClipPlane = x;
        });
        C_MAXDISTANCE = new DebugCommand<float>("c_maxdistance", "Sets the maximum distance of the camera", "c_maxdistance <Distance>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().farClipPlane = x;
        });
        CL_DEBUG = new DebugCommand<int>("cl_debug", "Toogles the debug Menu", "cl_debug <Enabled>", (x) =>
        {
            DebugMenu.Instance.IsDebugActive = (x == 1);
        });

        CommandList = new List<object>()
        {
            HELP,
            TELEPORT,
            MAXFPS,
            TIMESCALE,
            I_ADDITEM,
            I_REMOVEITEM,
            LVL_DESTROY,
            LVL_LOADSCENE,
            LVL_RELOADSCENE,
            C_FOV,
            C_MINDISTANCE,
            C_MAXDISTANCE,
            CL_DEBUG
        };

        if (_startWithArgs)
        {
            foreach (string arg in StartingArgs)
            {
                HandleInput(arg);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            _consoleEnabled = !_consoleEnabled;
            ConsoleUI.SetActive(_consoleEnabled);
            Cursor.lockState = _consoleEnabled ? CursorLockMode.None : CursorLockMode.Locked;

            if (_consoleEnabled)
            {
                _userInput.Select();
                _userInput.ActivateInputField(); 

                _userInput.text = _userInput.text.Replace("`", "");
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && _consoleEnabled)
        {
            HandleInput(_userInput.text);
            _userInput.text = "";
        }

        if (!_consoleEnabled) return;

        if (!_userInput.isFocused)
        {
            _userInput.Select();
            _userInput.ActivateInputField();
        }
        _userInput.text = _userInput.text.Replace("`", "");

    }
    private void HandleInput(string input)
    {
        string[] properties = input.Split(' ');
        for (int i = 0; i < CommandList.Count; i++)
        {
            DebugCommandBase commandBase = CommandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.CommandID))
            {
                if (CommandList[i] as DebugCommand != null)
                {
                    (CommandList[i] as DebugCommand).Invoke();
                }
                else if (CommandList[i] as DebugCommand<string> != null)
                {
                    (CommandList[i] as DebugCommand<string>).Invoke(properties[1]);
                }
                else if (CommandList[i] as DebugCommand<int> != null)
                {
                    (CommandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
                else if (CommandList[i] as DebugCommand<float> != null)
                {
                    (CommandList[i] as DebugCommand<float>).Invoke(float.Parse(properties[1]));
                }
                else if (CommandList[i] as DebugCommand<float,float,float,int> != null)
                {
                    (CommandList[i] as DebugCommand<float, float, float, int>).Invoke(float.Parse(properties[1]), float.Parse(properties[2]), float.Parse(properties[3]), int.Parse(properties[4]));
                }
            }
        }
    }
}
