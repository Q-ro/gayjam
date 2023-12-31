using Scripts.Interaction;
using Scripts.PlayerMovement;
using System;
using UnityEngine;

public class ChairInteractionController : InteractableObjectBase
{
    public static Action<bool> OnInteractWithChair;

    [SerializeField] GameObject sitChairPlayerTargetPosition;
    [SerializeField] GameObject stardChairPlayerTargetPosition;
    [SerializeField] float sitAnimationSpeed = 3.5f;
    [SerializeField] float standAnimationSpeed = 3.5f;

    private bool isSeated = false;

    protected override void Start()
    {
        base.Start();
        IsInteractable = true;
        PlayerMovementController.OnLockPlayerMovementPerformed += OnCharacterMovementReleased;
    }

    private void OnDestroy()
    {
        PlayerMovementController.OnLockPlayerMovementPerformed -= OnCharacterMovementReleased;
    }

    private void OnCharacterMovementReleased(bool obj)
    {
        if (isSeated)
        {
            PlayerMovementController.MovementPlayerToPosition(stardChairPlayerTargetPosition.transform.position, standAnimationSpeed,
            () =>
               {
                   isSeated = false;
                   Physics.IgnoreLayerCollision(6, 3, false);
                   gameObject.layer = 0;
                   OnInteractWithChair?.Invoke(false);
               });
        }
    }

    public override void Interact()
    {
        if (!isSeated)
        {
            isSeated = true;
            Physics.IgnoreLayerCollision(6, 3, true);
            gameObject.layer = 2;
            PlayerMovementController.OnLockPlayerMovementPerformed(true);
            PlayerMovementController.MovementPlayerToPosition(sitChairPlayerTargetPosition.transform.position, sitAnimationSpeed, () => { });
            OnInteractWithChair?.Invoke(true);
        }
    }

    public override void StartInteraction()
    {
    }

    public override void EndInteraction()
    {
    }
}
