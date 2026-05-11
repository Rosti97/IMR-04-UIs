using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;

public class canvasTypes : MonoBehaviour
{

    [Header("Ray Interactor")]
    [SerializeField] private XRRayInteractor rayInteractor; 

    [Header("Spatial UI")]
    [SerializeField] private TextMeshProUGUI nameplateText;

    [Header("Watch UI")]
    [SerializeField] private TextMeshProUGUI watchText;

    [Header("Vignette")]
    [SerializeField] private GameObject vignette;
    [SerializeField] private float vignetteDuration = 2f;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference toggleVignetteAction;


    // dirty way just to show the things :D 
    // In a real project, you would propably make a script "Animals" and add a bool "isDangerous"
    // and reference it through that 
    // but for this demo, we just check the name of the hovered object and make bools here
    private bool isBeeHovered = false;
    private bool isStinging = false;


    private void OnEnable()
    {
        Debug.Log("SceneManager OnEnable - rayInteractor: " + rayInteractor);
        rayInteractor.hoverEntered.AddListener(OnHoverEnter);
        rayInteractor.hoverExited.AddListener(OnHoverExit);

        toggleVignetteAction.action.Enable();
        toggleVignetteAction.action.performed += OnTriggerVignette;
    }

    private void OnDisable()
    {
        rayInteractor.hoverEntered.RemoveListener(OnHoverEnter);
        rayInteractor.hoverExited.RemoveListener(OnHoverExit);
        toggleVignetteAction.action.performed -= OnTriggerVignette;
    }


    // Hover Events
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // get name from hovered object
        string animalName = args.interactableObject.transform.gameObject.name;

        nameplateText.text = animalName;

        isBeeHovered = animalName == "Bee"; 

        watchText.text = isBeeHovered ? "Danger: HIGH" : "Danger: LOW";
        watchText.color = isBeeHovered ? Color.red : Color.green;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        isBeeHovered = false;

        nameplateText.text = "";
        watchText.text = "Danger: N/A";
        watchText.color = Color.white;
    }


    // Trigger Events
    private void OnTriggerVignette(InputAction.CallbackContext context)
    {
        if (isBeeHovered && !isStinging)
        {
            StartCoroutine(TriggerVignette());
        }
    }

    // A simple coroutine to show the vignette for a short duration when triggered
    // coroutine is a great way to handle timed events without blocking the main thread
    // to start a coroutine you call StartCoroutine and pass in a IEnumerator method 
    // that defines everything you want to do
    private System.Collections.IEnumerator TriggerVignette()
    {
        isStinging = true;
        vignette.SetActive(true);
        yield return new WaitForSeconds(vignetteDuration);
        vignette.SetActive(false);
        isStinging = false;
    }
}

