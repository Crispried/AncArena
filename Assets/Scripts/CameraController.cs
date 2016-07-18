using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// parameters for RotateByMouse()
        /// </summary>
        public float speedH = 2.0f;
        public float speedV = 2.0f;
        float yaw = 0.0f;
        float pitch = 0.0f;

        public Transform target;          
        public float smoothing = 5f;        
        GameObject character;
        Vector3 offset;                     

        void Awake()
        {
            offset = transform.position - target.position;
            character = GameObject.FindGameObjectWithTag("Character");
            yaw = transform.position.x;
            pitch = transform.position.y;
        }

        void LateUpdate()
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
          //  RotateByMouse();
        }

        void RotateByMouse()
        {
            if (Input.GetMouseButton(1))
            {
                Transform cameraTransform = Camera.main.transform;
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
                cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
        }
    }
}
