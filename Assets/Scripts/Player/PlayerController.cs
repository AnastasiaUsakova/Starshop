using System;
using GameData;
using Logic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IShopCustomer
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float moveSpeed = 1f;
    [Space]
    [SerializeField] private PlayerStyleSetupHelper styleSetupHelper;

    private bool _isMoving;
    private Vector2 _movementInput;

    private static readonly int IsPlayerMoving = Animator.StringToHash("isMoving");

    private bool IsMoving {
        set
        {
            _isMoving = value;
            animator.SetBool(IsPlayerMoving, _isMoving);
        }
    }

    private void Start()
    {
        var gameData = GameDataPersist.Instance.GameData;
        var savedPosition = gameData.PlayerPosition;
        if (savedPosition != Vector2.zero)
        {
            playerRigidBody.transform.position = savedPosition;
        }
        styleSetupHelper.Initialize(gameData.EquippedItemsList);
    }

    private void OnApplicationQuit()
    {
        GameDataPersist.Instance.GameData.PlayerPosition = playerRigidBody.transform.position;
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

    public void ItemBoughtCallback(ResourceItemType itemType, Sprite icon)
    {
        styleSetupHelper.EquipElement(itemType, icon);
    }
}
