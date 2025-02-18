using TMPro;
using UnityEngine;

public class DocumentDisplayManager : MonoBehaviour
{
    public static DocumentDisplayManager Instance { get { return _instance; } }
    private static DocumentDisplayManager _instance;
    
    [SerializeField]
    private TextMeshProUGUI _documentText;

    [SerializeField]
    private GameObject _bookObject;

    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void DisplayDocument(string inputText)
    {
        _bookObject.SetActive(true);
        _documentText.text = inputText;
    }
    public void Update() 
    {
        if (_bookObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            _bookObject.SetActive(false);
        }
    }

    /// <summary>
    /// I spend ages trying to make this when unity text UIs have a built in overflow to another text UI ;-;
    /// Enjoy the most useless code i have ever made in this project
    /// </summary>
    //public string[] SplitText(string Text, int CharactersPerPage)
    //{
    //    //return null;
    //    string[] output = new string[2];
    //    int currentCharacter = 0;
    //    if (Text.Length <= CharactersPerPage)
    //    {
    //        output[0] = Text;
    //        return output;
    //    }

    //    int splitAt = CharactersPerPage;
    //    int upperbound = 10000;
    //    while (currentCharacter < Text.Length && upperbound > 0) 
    //    {
    //        if (currentCharacter >= splitAt && Text[currentCharacter] == ' ')
    //        {
    //            output[1] = Text.Substring(currentCharacter);
    //            return output;
    //        }
    //        else 
    //        {
    //            output[0] += Text[currentCharacter];
    //        }
    //        currentCharacter++;
    //        upperbound--;
    //    }
    //    Debug.LogError("Document Display Manager: Split text while loop upper bound reached");
    //    return null;
    //}
}
