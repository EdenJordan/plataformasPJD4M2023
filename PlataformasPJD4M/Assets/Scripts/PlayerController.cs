using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _gameControls;
    private Vector2 _moveInput;
    private bool _isShooting;


    [SerializeField] private int maxEnergy;
    private int _currentEnergy;
    private int _points;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }
    
    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameControls = new GameControls();

        _currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private void OnAction(InputAction.CallbackContext playerAct)
    {
         if (playerAct.action.name == _gameControls.Gameplay.Shoot.name)
        {
            // Faz o jogador atirar
            
            //GetButtonDown -> Ativa no momento em que o botão é apertado
            //GetButton -> Fica ativo enquanto o botao estiver apertado
            //GetButtonUp -> Ativa no momento em que o botao é solto
            
            //stared -> Ativa no momento em que o botão é apertado
            //canceled -> Ativa no momento que o botao é solto
            
            //performed -> Ativa no momento que o botao é apertado e solto
            if (playerAct.started) _isShooting = true;
            if (playerAct.canceled) _isShooting = false;
        }
        if (playerAct.action.name == _gameControls.Gameplay.Move.name)
        {
            // Faz o jogador se mover
            _moveInput = playerAct.ReadValue<Vector2>();
        }
        
    }

    private void AddEnergy(int amount)
    {
        _currentEnergy = Mathf.Clamp(_currentEnergy + amount, 0, maxEnergy);
    }
    
}
