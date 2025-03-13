using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;

    [SerializeField]
    private TextMeshProUGUI _interactTooltip;

    [SerializeField]
    private Image _crosshair;
    [SerializeField]
    private Sprite _notHighlightedImage;
    [SerializeField]
    private Sprite _highlightedImage;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public void ChangeInteractText(string Text)
    {
        _interactTooltip.text = Text;
    }
    public void ChangeCrosshair(bool Highlighted)
    {
        if (!Highlighted)
        {
            _crosshair.sprite = _notHighlightedImage;
        }
        else
        {
            _crosshair.sprite = _highlightedImage;
        }
    }

}
