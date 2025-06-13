using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 _lastMoveDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _lastMoveDirection = Vector2.down;

    }

    private void Update()
    {
        Vector2 direction = _playerController.Direction;

        bool isMoving = direction.sqrMagnitude > 0.01f;

        _animator.SetBool("isMoving", isMoving);



        if (isMoving)
        {
            _lastMoveDirection = direction;
            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);
        }
        else
        {
            _animator.SetFloat("moveX", _lastMoveDirection.x);
            _animator.SetFloat("moveY", _lastMoveDirection.y);
        }




        if (_lastMoveDirection.x > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_lastMoveDirection.x < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }










}
