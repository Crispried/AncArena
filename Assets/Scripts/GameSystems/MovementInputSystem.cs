using Assets.Scripts.DataStructures;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameSystems
{
    public class MovementInputSystem : MonoBehaviour
    {
        public static VirtualJoystick joystick;

        private static Direction inputDirection;

        void Awake()
        {
            joystick = GameObject.FindGameObjectWithTag("VirtualJoystick").
                                    GetComponent<VirtualJoystick>();
        }

        public static Direction GetInputDirection()
        {
            // for computers WASD control
            inputDirection = new Direction()
            {
                X = Input.GetAxisRaw("Horizontal"),
                Z = Input.GetAxisRaw("Vertical")
            };

            // for virtual joystick
            if (joystick.InputDirection != Vector3.zero)
            {
                inputDirection.X = joystick.InputDirection.x;
                inputDirection.Z = joystick.InputDirection.z;
            }
            return inputDirection;
        }
    }
}
