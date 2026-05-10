using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class inputTypes : MonoBehaviour
{
    [Header("Controller Inpute")]
    [SerializeField] private InputActionProperty controllerButton;

    [Header("Status Displays")]
    [SerializeField] private TextMeshProUGUI controllerStatusText;
    [SerializeField] private TextMeshProUGUI rayStatusText;
    [SerializeField] private TextMeshProUGUI pokeStatusText;
    [SerializeField] private TextMeshProUGUI gazeStatusText;

    private int controllerCounter = 0;

    private void OnEnable()
    {
        controllerButton.action.Enable();
        controllerButton.action.performed += OnControllerButtonPressed;
    }

    private void OnDisable()
    {
        controllerButton.action.performed -= OnControllerButtonPressed;
    }

    private void OnControllerButtonPressed(InputAction.CallbackContext context)
    {
        controllerCounter++;
        controllerStatusText.text = "Click-Counter: " + controllerCounter;
    }

    public void OnRayButtonClicked()  => RandomColor(rayStatusText);
    public void OnPokeButtonClicked() => RandomColor(pokeStatusText);
    public void OnGazeButtonClicked() => RandomColor(gazeStatusText);


    private void RandomColor(TextMeshProUGUI textElement)
    {
        textElement.color = new Color(Random.value, Random.value, Random.value);
    }
}
