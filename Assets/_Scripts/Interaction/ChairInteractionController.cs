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
        InspectableObject.OnObjectSpawn += UpdateIsSeated;
    }



    private void OnDestroy()
    {
        PlayerMovementController.OnLockPlayerMovementPerformed -= OnCharacterMovementReleased;
        InspectableObject.OnObjectSpawn -= UpdateIsSeated;
    }

    private void UpdateIsSeated()
    {
        OnInteractWithChair?.Invoke(true);
    }

    private void OnCharacterMovementReleased(bool obj)
    {
        if (isSeated)
        {
            PlayerMovementController.MovementPlayerToPosition(stardChairPlayerTargetPosition.transform.position, standAnimationSpeed, false,
            () =>
               {
                   OnInteractWithChair?.Invoke(false);
                   isSeated = false;
                   gameObject.layer = 6;
                   Physics.IgnoreLayerCollision(6, 2, false);
               });
        }
    }

    public override void Interact()
    {
        if (!isSeated)
        {

            Physics.IgnoreLayerCollision(6, 2, true);
            gameObject.layer = 2;
            PlayerMovementController.OnLockPlayerMovementPerformed(true);
            PlayerMovementController.MovementPlayerToPosition(sitChairPlayerTargetPosition.transform.position, sitAnimationSpeed, false, () =>
            {
                OnInteractWithChair?.Invoke(true);
                isSeated = true;
            });

        }
    }

    public override void StartInteraction()
    {
    }

    public override void EndInteraction()
    {
    }
}
