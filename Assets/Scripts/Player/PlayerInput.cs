using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _playerMovement.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _playerMovement.TryMoveDown();
    }
}
