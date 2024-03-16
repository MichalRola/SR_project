using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private float camera_damp_time = 0.3f; // Camera reaction time for movement
    [SerializeField] private float x_offset = -4.0f;
    [SerializeField] private bool follow_agent_1 = false;

    [SerializeField] private Transform Agent_0;
    [SerializeField] private Transform Agent_1;

    private float desired_x;
    private Vector3 camera_velocity = Vector3.zero;

    void Update() {
        if (follow_agent_1 == false) // Choose agent to follow
            desired_x = Mathf.Max(Mathf.Min(Agent_0.position.x, Agent_1.position.x), 0);
        else // Follow arbitrary agent (probably temporary)
            desired_x = Agent_1.position.x;

        Vector3 desired_position = new(desired_x + x_offset, transform.position.y, transform.position.z);

        Vector3 smoothed_position = Vector3.SmoothDamp(transform.position, desired_position, ref camera_velocity, camera_damp_time);

        transform.position = smoothed_position;
    }
}
