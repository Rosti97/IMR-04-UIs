using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canvas : MonoBehaviour
{
    [Header("Inputs")]
    public Button myButton;
    public TMP_Dropdown myDropdown;
    public TMP_InputField myInputField;
    public Slider mySlider;

    [Header("Output")]
    public TMP_Text outputText;


    void Start()
    {
        // set up listeners for UI events
        // to see which events can be triggered on each component, check the inspector
        myButton.onClick.AddListener(OnButtonClicked);
        myDropdown.onValueChanged.AddListener(OnDropdownChanged);
        myInputField.onValueChanged.AddListener(OnInputChanged);
        myInputField.onEndEdit.AddListener(OnInputSubmitted);
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

    void OnInputChanged(string value)
    {
        outputText.text = $"Typing: {value}";
    }

    void OnInputSubmitted(string value)
    {
        outputText.text = $"Submitted: {value}";
    }

    void OnSliderChanged(float value)
    {
        outputText.text = $"Slider: {value}";
    }

}
