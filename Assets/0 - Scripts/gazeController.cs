using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gazeController : MonoBehaviour
{

    [Header("Gaze")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask gazeLayer;
    [SerializeField] private float gazeDistance = 5f;
    [SerializeField] private float dwellTime = 1.5f;
    [SerializeField] private float feedbackDuration = 0.5f;

    [Header("Reticle")]
    [SerializeField] private GameObject reticle;
    [SerializeField] private RectTransform recticleTransform;
    [SerializeField] private Image reticleFill;


    private Button activatedButton;
    private float gazeTimer;
    private bool isFeedbackActive = false;



    void Update()
    {
        if (isFeedbackActive)
        {
            return;
        }


        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (!Physics.Raycast(ray, out RaycastHit hit, gazeDistance, gazeLayer))
        {
            ResetGazeReticle(); 
            return;
        }

        reticle?.gameObject.SetActive(true);
        recticleTransform.position = hit.point;

        Button button = hit.collider.GetComponent<Button>();

        if (button != null)
        {

            if (button != activatedButton)
            {
                activatedButton = button;
                gazeTimer = 0f;
            }

            gazeTimer += Time.deltaTime;
            reticleFill.fillAmount = gazeTimer / dwellTime;

            if (gazeTimer >= dwellTime)
            {
                StartCoroutine(ConfirmSelection());
            }
        }
        else
        {
            reticleFill.fillAmount = 0f;
            activatedButton = null;
            gazeTimer = 0f;
        }
    }

    private void ResetGazeReticle()
    {
        reticle?.gameObject.SetActive(false);
        reticleFill.fillAmount = 0f;
        activatedButton = null;
        gazeTimer = 0f;
    }

    private System.Collections.IEnumerator ConfirmSelection()
    {
        isFeedbackActive = true;

        reticleFill.fillAmount = 1f;

        activatedButton?.onClick.Invoke();

        yield return new WaitForSeconds(feedbackDuration);

        ResetGazeReticle();
        isFeedbackActive = false;
    }
}
