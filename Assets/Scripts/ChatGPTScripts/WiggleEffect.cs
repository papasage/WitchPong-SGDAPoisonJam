using UnityEngine;

public class WiggleEffect : MonoBehaviour
{
    //this is a script that was written by ChatGPT on May 3rd, 2023
    //prompted by Ian Guglielmi-White

    [SerializeField] private float wiggleAmplitude = 0.1f;
    [SerializeField] private float wiggleFrequency = 2f;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        float time = Time.time;

        // Calculate position offset
        float positionOffsetX = wiggleAmplitude * Mathf.Sin(time * wiggleFrequency);
        float positionOffsetY = wiggleAmplitude * Mathf.Cos(time * wiggleFrequency);

        // Calculate rotation offset
        float rotationOffset = wiggleAmplitude * Mathf.Sin(time * wiggleFrequency * 2f);

        // Apply offsets to position and rotation
        Vector3 position = startPosition;
        position.x += positionOffsetX;
        position.y += positionOffsetY;
        Quaternion rotation = startRotation * Quaternion.Euler(0f, 0f, rotationOffset);
        transform.SetPositionAndRotation(position, rotation);
    }
}
