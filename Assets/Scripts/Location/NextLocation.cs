using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLocation : MonoBehaviour
{
    [SerializeField] private Button _nextLocationButton;
    [SerializeField] private TextMeshProUGUI _nextLocationButtonText;

    public bool NextLocationButtonEnabled
    {
        get
        {
            return _nextLocationButton.interactable;
        }

        set
        {
            _nextLocationButton.interactable = value;
        }
    }

    public string NextLocationButtonText
    {
        get
        {
            return _nextLocationButtonText.text;
        }

        set
        {
            _nextLocationButtonText.text = value;
        }
    }
}
