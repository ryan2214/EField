using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public static CameraController instance;
    public Transform followTransform;
    // coop with the obj followed with script inside its class
    // public void OnMouseDown(){
    //     CameraController.instance.followTransform = transform;   
    // }
    //
    public Transform cameraTransform;

    public float movementSpeed;
    public float movementTime;
    private Vector3 newPos;
    public float rotationAmount;
    public Vector3 zoomAmount;
    private Quaternion newRotation;
    private Vector3 newZoom;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;
    private Vector3 rotateStartPosition;
    private Vector3 rotateCurrentPosition;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        newPos = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;    
    }

    // Update is called once per frame
    void Update()
    {   
        if(followTransform != null){
            transform.position = followTransform.position;
        }else{
            //HandleMouseInput();
            HandleMovementInput();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            followTransform = null;
        }
    }

    void HandleMouseInput(){
        if(Input.mouseScrollDelta.y!=0){
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
        
        if(Input.GetMouseButtonDown(0)){
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry)){
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if(Input.GetMouseButton(0)){
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry)){
                dragCurrentPosition = ray.GetPoint(entry);

                newPos = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }

        if(Input.GetMouseButtonDown(1)){
            rotateStartPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(1)){
            rotateCurrentPosition = Input.mousePosition;
            Vector3 diff = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-diff.x/5f));
        }
    }

    void HandleMovementInput(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput!=0){
            newPos += (transform.right * movementSpeed * horizontalInput);
        }
        if(verticalInput!=0){
            newPos += (transform.forward * movementSpeed * verticalInput);
        }
        if(Input.GetKey(KeyCode.Q)){
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if(Input.GetKey(KeyCode.E)){
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if(Input.GetKey(KeyCode.R)){
            newZoom += zoomAmount/50f;
        }
        if(Input.GetKey(KeyCode.F)){
            newZoom -= zoomAmount/50f;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
