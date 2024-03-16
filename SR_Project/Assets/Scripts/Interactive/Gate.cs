using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private PanelButton[] required_buttons; // buttons that all must be activated for gate to open

    private void Update()
    {
        foreach (var button in required_buttons)
        {
            if (!button.Activated)
            {
                return;
            }
        }

        Destroy(gameObject); // If there are no unactivated required buttons then gate should be opened (or destroyed)
    }
}
