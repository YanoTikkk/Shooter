using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponsIndex = new List<Weapon>();
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    private Rigidbody rigidbodyPlayer;
    private bool isGrounded;
    
    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump(jumpSpeed);
    }
    
    private void FixedUpdate()
    {
        Move(speedMove);
        
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < weaponsIndex.Count; i++)
            {
                weaponsIndex[i].GetComponent<Weapon>().Shoot();
            }
        }
    }

    private void Move(float speed)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical") * speed;
        rigidbodyPlayer.AddRelativeForce(0f,0f,v,ForceMode.Acceleration);
        rigidbodyPlayer.AddRelativeTorque(0f,h,0f,ForceMode.Acceleration);
    }

    private void Jump(float speed)
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigidbodyPlayer.AddForce(0f,speed,0f,ForceMode.Acceleration);
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
