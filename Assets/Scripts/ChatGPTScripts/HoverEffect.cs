using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    //this is a script that was written by ChatGPT on May 3rd, 2023
    //prompted by Ian Guglielmi-White

    [SerializeField] private float horizontalRange = 0.2f;
    [SerializeField] private float verticalRange = 0.1f;
    [SerializeField] private float rotationRange = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        // Calculate horizontal and vertical offset
        float horizontalOffset = horizontalRange * Mathf.Sin(Time.time);
        float verticalOffset = verticalRange * Mathf.Sin(Time.time * 2);

        // Calculate rotation offset
        float rotationOffset = rotationRange * Mathf.Sin(Time.time * rotationSpeed);

        // Apply offsets to position and rotation
        Vector3 position = startPosition;
        position.x += horizontalOffset;
        position.y += verticalOffset;
        Quaternion rotation = startRotation * Quaternion.Euler(0f, 0f, rotationOffset);
        transform.SetPositionAndRotation(position, rotation);
    }
}
