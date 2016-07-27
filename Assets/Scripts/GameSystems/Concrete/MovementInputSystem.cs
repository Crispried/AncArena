﻿using UnityEngine;
using Assets.Scripts.GameSystems.Abstract;

namespace Assets.Scripts.GameSystems.Concrete
{
    public class MovementInputSystem : MonoBehaviour, IMovementInputSystem
    {
        private VirtualJoystick joystick;

        private Vector3 inputDirection;

        void Awake()
        {
            joystick = GameObject.FindGameObjectWithTag("VirtualJoystick").
                                    GetComponent<VirtualJoystick>();

        }

        public Vector3 GetInputDirection()
        {
            // for computers WASD control
            inputDirection = new Vector3()
            {
                x = Input.GetAxisRaw("Horizontal"),
                z = Input.GetAxisRaw("Vertical")
            };

            // for virtual joystick
            if (joystick.InputDirection != Vector3.zero)
            {
                inputDirection.x = joystick.InputDirection.x;
                inputDirection.z = joystick.InputDirection.z;
            }
            return inputDirection;
        }
    }
}
