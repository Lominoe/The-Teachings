using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    InputAction aimAction;

    [SerializeField] Transform aimTarget;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimAction = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = aimTarget.position;
       
        // dude i have no clue how to do aim stuff with the new unity input system
        /*
        Vector2 eulerRotation = aimAction.ReadValue<Vector2>();
        transform.rotation = Quaternion.Euler(eulerRotation.x,eulerRotation.y, 0);
        */
    }
}
