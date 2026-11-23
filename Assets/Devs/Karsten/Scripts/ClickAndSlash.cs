    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using EzySlice;
    
    public class ClickAndSlash : MonoBehaviour
    {
    [SerializeField] private Transform trail;
    [SerializeField] private Material SliceMaterial;
    [SerializeField] private LayerMask sliceLayer;

    private Camera Cam;
    private TrailRenderer trailRenderer;
    private Vector2 startPos;
    private List<GameObject> hitObjects = new List<GameObject>();
    void Start()
        {
            Cam = Camera.main;
            trailRenderer = trail.GetComponent<TrailRenderer>();
    }


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

