using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;


public struct PlayerInputData : INetworkInput
{
    public Vector2 moveInput;
    public float rotationInput;

}

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (false)
        {
            Camera playerCamera = GetComponentInChildren<Camera>();
            playerCamera.gameObject.SetActive(true);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (HasInputAuthority)
        {
            if (GetInput(out PlayerInputData input))
            {
                Vector3 moveDirection = new Vector3(input.moveInput.x, 0, input.moveInput.y);
                characterController.Move(moveDirection * speed * Runner.DeltaTime);
                transform.Rotate(0, input.rotationInput * rotationSpeed * Runner.DeltaTime,0);

            }
        }
    }
}