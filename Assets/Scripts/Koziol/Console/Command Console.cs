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




    public static ConsoleCommand HELP;

    public static ConsoleCommand<float, float, float, int> TELEPORT;
    public static ConsoleCommand<int> MAXFPS;
    public static ConsoleCommand<float> TIMESCALE;


    public static ConsoleCommand<int> I_ADDITEM;
    public static ConsoleCommand<int> I_REMOVEITEM;

    public static ConsoleCommand LVL_DESTROY;
    public static ConsoleCommand<int> LVL_LOADSCENE;
    public static ConsoleCommand LVL_RELOADSCENE;

    public static ConsoleCommand<float> C_FOV;
    public static ConsoleCommand<float> C_MINDISTANCE;
    public static ConsoleCommand<float> C_MAXDISTANCE;

    public static ConsoleCommand<int> CL_DEBUG;

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
        GenerateCommands();
        LoadCommands();

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
    void GenerateCommands()
    {
        HELP = new ConsoleCommand("help", "Displays all available commands", "help", () =>
        {
            string helpText = "Available Commands: \n";
            foreach (object command in CommandList)
            {
                ConsoleCommandBase commandBase = command as ConsoleCommandBase;
                helpText += commandBase.CommandID + " - " + commandBase.CommandDescription + " - " + commandBase.CommandFormat + "\n";
            }
            OutputToConsole(helpText);
        });
        LVL_DESTROY = new ConsoleCommand("lvl_destroy", "Destroys the console", "destroy", () =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Ray DestructionRay = new Ray(camera.transform.position, camera.transform.forward);
            if (!Physics.Raycast(DestructionRay, out RaycastHit hit, 5f)) //Raycast Check to see if the ray hit something
            {
                return;
            }
            Destroy(hit.collider.gameObject);
            OutputToConsole($"Destroyed: {hit.collider.name}");
        });
        TELEPORT = new ConsoleCommand<float, float, float, int>("teleport", "Teleports the player to a location", "teleport <x> <y> <z> <teleport type>", (x, y, z, i) =>
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (i == 0)
            {
                player.transform.position = new Vector3(x, y, z);
                OutputToConsole($"Teleported the player to {x}, {y}, {z} global position");
            }
            else
            {
                player.transform.localPosition = new Vector3(x, y, z);
                OutputToConsole($"Teleported the player to {x}, {y}, {z} local position");
            }
        });
        MAXFPS = new ConsoleCommand<int>("maxfps", "Sets the maximum frame rate", "maxfps <FPS Amount>", (x) =>
        {
            Application.targetFrameRate = x;
            OutputToConsole($"Changed FPS to {x} FPS");
        });
        TIMESCALE = new ConsoleCommand<float>("timescale", "Sets the time scale of the game", "timescale <Timescale Amount>", (x) =>
        {
            Time.timeScale = x;
            OutputToConsole($"Set time scale to {x} seconds per second");
        });
        I_ADDITEM = new ConsoleCommand<int>("i_additem", "Adds an item to the player's inventory", "i_additem <item id>", (x) =>
        {
            Debug.LogError("I_ADDITEM command not implemented");
        });
        I_REMOVEITEM = new ConsoleCommand<int>("i_removeitem", "Removes an item from the player's inventory", "i_removeitem <item id>", (x) =>
        {
            Debug.LogError("I_REMOVEITEM command not implemented");
        });
        LVL_LOADSCENE = new ConsoleCommand<int>("lvl_loadscene", "Loads a scene", "lvl_loadscene <scene id>", (x) =>
        {
            SceneManager.LoadScene(x);
            OutputToConsole($"Loaded Scene {x}");
        });
        LVL_RELOADSCENE = new ConsoleCommand("lvl_reloadscene", "Reloads the current scene", "lvl_reloadscene", () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            OutputToConsole($"Reloaded Scene {SceneManager.GetActiveScene().buildIndex}");
        });
        C_FOV = new ConsoleCommand<float>("c_fov", "Sets the field of view of the camera", "c_fov <FOV Value>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().fieldOfView = x;
            OutputToConsole($"Set FOV to {x} degrees");
        });
        C_MINDISTANCE = new ConsoleCommand<float>("c_mindistance", "Sets the minimum distance of the camera", "c_mindistance <Distance>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().nearClipPlane = x;
            OutputToConsole($"Set camera minimum distance to {x}");
        });
        C_MAXDISTANCE = new ConsoleCommand<float>("c_maxdistance", "Sets the maximum distance of the camera", "c_maxdistance <Distance>", (x) =>
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Camera>().farClipPlane = x;
            OutputToConsole($"Set camera maximum distance to {x}");
        });
        CL_DEBUG = new ConsoleCommand<int>("cl_debug", "Toogles the debug Menu", "cl_debug <Enabled>", (x) =>
        {
            if (x == 1)
            {
                DebugMenu.Instance.IsDebugActive = true;
                OutputToConsole("Enabled Debug Menu");
            }
            else
            {
                DebugMenu.Instance.IsDebugActive = false;
                OutputToConsole("Disabled Debug Menu");
            }
        });
    }
    void LoadCommands()
    {
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
    }
    private void HandleInput(string input)
    {
        string[] properties = input.Split(' ');
        for (int i = 0; i < CommandList.Count; i++)
        {
            ConsoleCommandBase commandBase = CommandList[i] as ConsoleCommandBase;

            if (input.Contains(commandBase.CommandID))
            {
                if (CommandList[i] as ConsoleCommand != null)
                {
                    (CommandList[i] as ConsoleCommand).Invoke();
                }
                else if (CommandList[i] as ConsoleCommand<string> != null)
                {
                    (CommandList[i] as ConsoleCommand<string>).Invoke(properties[1]);
                }
                else if (CommandList[i] as ConsoleCommand<int> != null)
                {
                    (CommandList[i] as ConsoleCommand<int>).Invoke(int.Parse(properties[1]));
                }
                else if (CommandList[i] as ConsoleCommand<float> != null)
                {
                    (CommandList[i] as ConsoleCommand<float>).Invoke(float.Parse(properties[1]));
                }
                else if (CommandList[i] as ConsoleCommand<float,float,float,int> != null)
                {
                    (CommandList[i] as ConsoleCommand<float, float, float, int>).Invoke(float.Parse(properties[1]), float.Parse(properties[2]), float.Parse(properties[3]), int.Parse(properties[4]));
                }
            }
        }
    }
    private void OutputToConsole(string input)
    {
        _consoleText.text += input + "\n";
    }
}
