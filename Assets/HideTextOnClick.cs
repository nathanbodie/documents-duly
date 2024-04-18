using UnityEngine;
using TMPro;

public class HideTMPText : MonoBehaviour
{
    public TextMeshProUGUI textToHide;

    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ToggleText);
    }

    void ToggleText()
    {
        if(textToHide.enabled == true)
        {
            textToHide.enabled = false;
        }
        
        else {
            textToHide.enabled = true;
        }
    }
}