using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput;

    [SerializeField] private Rigidbody2D playerRigidBody;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D movementFilter;

    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    
    private void FixedUpdate()
    {
        if (!_movementInput.Equals(Vector2.zero))
        {
            var movedSuccessfully = TryMove(_movementInput);
            if (!movedSuccessfully)
                movedSuccessfully = TryMove(new Vector2(_movementInput.x, 0));
            
            if(!movedSuccessfully)
                TryMove(new Vector2(0, _movementInput.y));
        }
    }

    private bool TryMove(Vector2 direction)
    {
        var collisionsCount = playerRigidBody.Cast(direction, movementFilter,
            _castCollisions, moveSpeed * Time.deltaTime + collisionOffset);

        if (collisionsCount != 0)
            return false;
        
        playerRigidBody.MovePosition(playerRigidBody.position + direction *  moveSpeed * Time.deltaTime );
        return true;
    }

    public void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
