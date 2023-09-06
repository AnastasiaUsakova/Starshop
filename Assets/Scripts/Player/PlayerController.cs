using System;
using Logic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IShopCustomer
{
    private Vector2 _movementInput;

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private float moveSpeed = 1f;

    private static readonly int IsPlayerMoving = Animator.StringToHash("isMoving");

    private bool _isMoving;

    public bool IsMoving {
        set
        {
            _isMoving = value;
            animator.SetBool(IsPlayerMoving, _isMoving);
        }
    }

    private void FixedUpdate()
    {
        if (!_movementInput.Equals(Vector2.zero))
        {
            playerRigidBody.MovePosition(playerRigidBody.position + _movementInput.normalized * moveSpeed * Time.fixedDeltaTime );

            playerSprite.flipX = _movementInput.x < 0 || (!(_movementInput.x > 0) && playerSprite.flipX);
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }

    public void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    public void BuyItem(ResourceItemType itemType)
    {
        
    }
}
