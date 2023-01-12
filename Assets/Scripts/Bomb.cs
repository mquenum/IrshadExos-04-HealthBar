using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    // get input actions asset created directly inside Unity (needs InputSystem package)
    // when we press the left button mouse
    [SerializeField] private InputActionReference _press;
    // get the mouse position on screen
    [SerializeField] private InputActionReference _screenPosition;

    // get current mouse position on screen
    private Vector3 _currentScreenPosition;
    // camera
    private Camera _cam;
    // is the gameObject dragged ?
    private bool _isDragging;
    // readonly property that defines if the gameObject clicked
    private bool _isClicked
    {
        get
        {
            // create ray from camera to the current mouse position on screen
            Ray ray = _cam.ScreenPointToRay(_currentScreenPosition);
            RaycastHit hit;

            // if the ray intersects with anything in the hit
            if (Physics.Raycast(ray, out hit))
            {
                // return true is we clicked on the gameObject on which we added this script
                // else return false
                return hit.transform == transform;
            }
            else
            {
                // if we don't hit anything
                return false;
            }
        }
    }
    // readonly property that converts the current screen position to world position
    private Vector3 _worldPosition
    {
        get
        {
            // distance between the gameObject and the camera (we only want the z)
            float z = _cam.WorldToScreenPoint(transform.position).z;
            // return the converted value with the updated current screen position z 
            return _cam.ScreenToWorldPoint(_currentScreenPosition + new Vector3(0,0,z));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;

        // enable input actions
        _screenPosition.action.Enable();
        _press.action.Enable();
        // what will be launched whenever the input actions happens
        _screenPosition.action.performed += GetPosition;
        // launched when we press the left button
        _press.action.performed += RunDrag;
        // launched when we release the left button
        _press.action.canceled += StopDrag;
    }

    private void GetPosition(InputAction.CallbackContext obj)
    {
        // store the value
        _currentScreenPosition = obj.ReadValue<Vector2>();
    }

    // function to start the coroutine and set that we are dragging the gameObject
    private void RunDrag(InputAction.CallbackContext obj)
    {
        _isDragging = true;
        // if we click on the object...
        if (_isClicked)
        {
            // start the corountine with the Drag function
            StartCoroutine(Drag());
        }
    }

    // function to set that we are not dragging the gameObject anymore
    private void StopDrag(InputAction.CallbackContext obj)
    {
        _isDragging = false;
    }
    // coroutine: spread a task across several frames
    // IEnumerator is a . NET type that is used to fragment large collection or files, or simply to pause an iteration
    // see http://answers.unity.com/answers/1004831/view.html
    private IEnumerator Drag()
    {
        // create offset to have a perfect movement
        Vector3 offset = transform.position - _worldPosition;
        _isDragging = true;

        // while we are dragging
        while (_isDragging)
        {
            // move with an offset to avoid snaping effect
            transform.position = _worldPosition + offset;

            // execution pauses and resumes in the following frame
            yield return null;
        }
    }
}
