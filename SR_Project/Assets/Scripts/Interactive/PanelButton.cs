using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : MonoBehaviour
{
    private static readonly float button_deactivate_time = 0.5f; // After this time a button will deactivate

    public bool Activated { get; private set; } = false;
    private float activation_timer = 0.0f;

    private Renderer rend;
    private Color default_color;

    [SerializeField] private Color highlight_color = Color.green;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        default_color = rend.material.color;
    }

    private void Update()
    {
        if (!Activated) return;

        if (activation_timer < 0.0f)
        {
            Deactivate();
        }

        activation_timer -= Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Agent")) return; // Only agents can activate buttons
        if (collision.contacts[0].normal.y > -0.5f) return; // y should be -1 which means that agent touched the button from above

        Activate();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Agent")) return;

        Deactivate();
    }

    private void Activate()
    {
        rend.material.color = highlight_color;
        Activated = true;
        activation_timer = button_deactivate_time;
    }

    private void Deactivate()
    {
        rend.material.color = default_color;
        Activated = false;
    }
}
