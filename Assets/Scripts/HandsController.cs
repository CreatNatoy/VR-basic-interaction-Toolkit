using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandsController : MonoBehaviour
{
    [SerializeField] private InputActionReference _gripInputAction;
    [SerializeField] private InputActionReference _triggerInputAction;

    private Animator _handAnimator;
    private static readonly int TriggerHash = Animator.StringToHash("Trigger");
    private static readonly int GripHash = Animator.StringToHash("Grip");

    private void Awake() {
        _handAnimator = GetComponent<Animator>();
    }

    private void OnEnable() {
        _gripInputAction.action.performed += GripPressed;
        _triggerInputAction.action.performed += TriggerPressed;
    }

    private void OnDisable() {
        _gripInputAction.action.performed -= GripPressed;
        _triggerInputAction.action.performed -= TriggerPressed;
    }

    private void TriggerPressed(InputAction.CallbackContext obj) => 
        _handAnimator.SetFloat(TriggerHash, obj.ReadValue<float>());

    private void GripPressed(InputAction.CallbackContext obj) => 
        _handAnimator.SetFloat(GripHash, obj.ReadValue<float>());
}
