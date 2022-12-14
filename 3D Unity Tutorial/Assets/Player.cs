using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private RuntimeData _runtimeData;
    
    [SerializeField] private float _mouseSensitivity = 10f;

    [SerializeField] private float _moveSpeed = 3f;

    [SerializeField] private Camera _cam;

    [SerializeField] private GameObject _tomato;

    [SerializeField] private float _throwStrength = 500;

    private bool _canThrow = false;
    private float _currentTilt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        Aim();
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
        {
            Movement();
            ThrowTomato();
        }
    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        
        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);
        
        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);

        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);
    }

    void Movement()
    {
        Vector3 sidewaysVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysVector + forwardVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);
    }

    void ThrowTomato()
    {
        if (Input.GetMouseButtonDown(1) && _canThrow){
            GameObject currTomato = Instantiate(_tomato, transform.position, Quaternion.identity);
            currTomato.GetComponent<Rigidbody>().AddForce((transform.forward + _cam.transform.forward + new Vector3(0,.3f,0)) * _throwStrength);
        }
    }

    public void GiveTomato()
    {
        _canThrow = true;
    }
}
