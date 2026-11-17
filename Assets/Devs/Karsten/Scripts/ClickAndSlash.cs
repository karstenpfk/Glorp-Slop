using UnityEngine;
using UnityEngine.InputSystem;

public class ClickAndSlash : MonoBehaviour
{
    [SerializeField] private Transform trail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Start");
            trail.position = ray.GetPoint(1f);
            trail.GetComponent<TrailRenderer>().Clear();
        }
        else if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("bezig");
            trail.position = ray.GetPoint(1f);
            Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }

        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Debug.Log("klaar");

        }

    }
}

