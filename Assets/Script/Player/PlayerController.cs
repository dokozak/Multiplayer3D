using Fusion;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;

    private CharacterController characterController;

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
        //    Camera playerCamera = GetComponentInChildren<Camera>();
          //  playerCamera.gameObject.SetActive(true);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasInputAuthority) return;

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += transform.forward;
        if (Input.GetKey(KeyCode.S)) move -= transform.forward;
        if (Input.GetKey(KeyCode.A)) move -= transform.right;
        if (Input.GetKey(KeyCode.D)) move += transform.right;

        move *= speed * Runner.DeltaTime;
        transform.position += move;

       float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Runner.DeltaTime;
       transform.Rotate(0, mouseX, 0);
    }
}