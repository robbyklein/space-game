using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Manager", menuName = "ScriptableObjects/Managers/InputManager")]
public class InputManager : ScriptableObject {
    public Input Input { get; private set; }

    public event Action OnPlayingFire;
    public event Action OnPlayingFireCanceled;

    public Vector2 MovementInput { get; private set; } = Vector2.zero;
    public Vector2 TurnInput { get; private set; } = Vector2.zero;

    void OnEnable() {
        // Create new input actions instance
        Input ??= new Input();

        // Subscribe to events
        Input.Playing.Movement.performed += HandlePlayingMovement;
        Input.Playing.Movement.canceled += HandlePlayingMovementCanceled;

        Input.Playing.Fire.performed += HandlePlayingFire;
        Input.Playing.Fire.canceled += HandlePlayingFireCanceled;

        Input.Playing.Turn.performed += HandlePlayingTurn;
        Input.Playing.Turn.canceled += HandlePlayingTurn;

        // Enable the world action map
        Input.Playing.Enable();
    }

    void OnDisable() {
        Input.Playing.Movement.performed -= HandlePlayingMovement;
        Input.Playing.Movement.canceled -= HandlePlayingMovementCanceled;

        Input.Playing.Fire.performed -= HandlePlayingFire;
        Input.Playing.Fire.canceled -= HandlePlayingFireCanceled;

        Input.Playing.Turn.performed -= HandlePlayingTurn;
        Input.Playing.Turn.canceled -= HandlePlayingTurn;

    }

    void HandlePlayingMovement(InputAction.CallbackContext obj) {
        MovementInput = obj.ReadValue<Vector2>();
    }

    void HandlePlayingMovementCanceled(InputAction.CallbackContext obj) {
        MovementInput = Vector2.zero;
    }

    void HandlePlayingFire(InputAction.CallbackContext obj) {
        OnPlayingFire?.Invoke();
    }

    void HandlePlayingFireCanceled(InputAction.CallbackContext obj) {
        OnPlayingFireCanceled?.Invoke();
    }

    void HandlePlayingTurn(InputAction.CallbackContext obj) {
        Vector2 turnInput = obj.ReadValue<Vector2>();
        TurnInput = turnInput;

        Debug.Log("Setting turn input to" + turnInput);
    }
}
