using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject trackedObject;
    public TextMeshProUGUI healthText;
    private HealthController healthController;

    private void Start()
    {
        if (trackedObject != null)
        {
            // Find the HealthController script on the tracked object
            healthController = trackedObject.GetComponent<HealthController>();
        }
        else
        {
            Debug.LogError("Tracked object is not assigned in HealthUI.");
        }
    }

    private void Update()
    {
        if (healthController != null)
        {
            // Update the displayed health value
            healthText.text = $"Health: {healthController.GetCurrentHealth()} / {healthController.GetMaxHealth()}";
        }
    }
}
