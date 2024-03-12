using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform Agent_0;
    [SerializeField] private Transform Agent_1;

    private float min_x;

    void Update() {
        min_x = Mathf.Max(Mathf.Min(Agent_0.position.x, Agent_1.position.x), 0);
        transform.position = new Vector3(min_x - 4.0f, transform.position.y, transform.position.z);
    }
}
