using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class simpleCanvas : MonoBehaviour
{

    // importamt:
    // make sure Canvas has a TrackedDeciveGraphicRaycaster component!
    // EventSystem also needa XRUIInputModule component

    // You can remove the GraphicRaycaster component on the canvas
    // and the Standalone Input Module on the EventSystem if you are only using XRUIInputModule

    [Header("Inputs")]
    public Button myButton;
    public Slider mySlider;
    public TMP_Dropdown myDropdown;

    [Header("Output")]
    public TMP_Text outputText;


    void Start()
    {
        // set up listeners for UI events
        // to see which events can be triggered on each component, check the inspector
        myButton.onClick.AddListener(OnButtonClicked);
        myDropdown.onValueChanged.AddListener(OnDropdownChanged);
        mySlider.onValueChanged.AddListener(OnSliderChanged);

    }

    // event handlers for UI events

    void OnButtonClicked()
    {
        outputText.text = "Button was clicked!";
    }

        void OnDropdownChanged(int index)
    {
        outputText.text = $"Dropdown: {myDropdown.options[index].text}";
    }

    void OnSliderChanged(float value)
    {
        outputText.text = $"Slider: {value}";
    }

}
