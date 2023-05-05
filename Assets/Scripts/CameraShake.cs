using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    bool isShaking = false;
    private Vector3 originalPosition;

    //this is just the brakey's tutorial camera shake script. call the coroutine where you need it

    public IEnumerator Shake (float duration, float magnitude)
    {
        originalPosition = new Vector3(0, 0, -10);

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            isShaking = true;

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = transform.localPosition.z;

            transform.localPosition = new Vector3(x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        isShaking = false;

        //Debug.Log("CAMERA RETURN");

        transform.localPosition = originalPosition;
        
    }

}
