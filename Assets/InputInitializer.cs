using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputInitializer : MonoBehaviour
{
    PlayerInput pi;

    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCycleLeft()
    {

    }
}
