//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Scripts/Inputs/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ddc02eb7-feec-4fed-a23d-08a9bd47a7d9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""73d80d42-895e-4f0c-9937-27afd5794397"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""f6bcf809-e647-45f3-9a22-dc994175f022"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""5651d3ce-d76a-46b9-b68e-f705dff192a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f2447fde-ed8d-4faf-a8dc-58475b4622a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SubmitDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""47943947-abcb-4cb4-8bf5-1c1f8ed3ee73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dialogue1"",
                    ""type"": ""Button"",
                    ""id"": ""af5682bd-5f70-44ce-9470-e2eb89db9a1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dialogue2"",
                    ""type"": ""Button"",
                    ""id"": ""4c32d4b5-1c40-4e6c-9c76-eada125363bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dialogue3"",
                    ""type"": ""Button"",
                    ""id"": ""a3f10154-809d-4b05-8174-92d18a989a80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ac310839-d05d-41f5-b79a-111a1ad969a8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a30ff138-aca2-4496-af3b-e21cc30f8acb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10fd52a3-00fe-4fe0-a2ec-d9cadbcd819b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""14d0c97d-985c-45b9-aa3b-86b29d5ba9b3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10873ec4-88ee-4d51-99a6-5be14399e766"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""14cc9858-7ad4-4c59-b892-6124b4366287"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e5feefb-ff58-46f2-8332-0cae5d4a021a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03fda954-8182-4d0d-8bda-0811237f3fe1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c7f0d66-b018-412d-ade9-629bb43f3118"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SubmitDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9998300c-13a3-416a-943f-84f3460935dd"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogue1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f65b80c-2128-48b4-a4f8-2ca45ad4d1e5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogue2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5892c8eb-3726-4734-90ac-107d92e79a73"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogue3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_PickUp = m_Player.FindAction("PickUp", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_SubmitDialogue = m_Player.FindAction("SubmitDialogue", throwIfNotFound: true);
        m_Player_Dialogue1 = m_Player.FindAction("Dialogue1", throwIfNotFound: true);
        m_Player_Dialogue2 = m_Player.FindAction("Dialogue2", throwIfNotFound: true);
        m_Player_Dialogue3 = m_Player.FindAction("Dialogue3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_PickUp;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_SubmitDialogue;
    private readonly InputAction m_Player_Dialogue1;
    private readonly InputAction m_Player_Dialogue2;
    private readonly InputAction m_Player_Dialogue3;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @PickUp => m_Wrapper.m_Player_PickUp;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @SubmitDialogue => m_Wrapper.m_Player_SubmitDialogue;
        public InputAction @Dialogue1 => m_Wrapper.m_Player_Dialogue1;
        public InputAction @Dialogue2 => m_Wrapper.m_Player_Dialogue2;
        public InputAction @Dialogue3 => m_Wrapper.m_Player_Dialogue3;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @PickUp.started += instance.OnPickUp;
            @PickUp.performed += instance.OnPickUp;
            @PickUp.canceled += instance.OnPickUp;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @SubmitDialogue.started += instance.OnSubmitDialogue;
            @SubmitDialogue.performed += instance.OnSubmitDialogue;
            @SubmitDialogue.canceled += instance.OnSubmitDialogue;
            @Dialogue1.started += instance.OnDialogue1;
            @Dialogue1.performed += instance.OnDialogue1;
            @Dialogue1.canceled += instance.OnDialogue1;
            @Dialogue2.started += instance.OnDialogue2;
            @Dialogue2.performed += instance.OnDialogue2;
            @Dialogue2.canceled += instance.OnDialogue2;
            @Dialogue3.started += instance.OnDialogue3;
            @Dialogue3.performed += instance.OnDialogue3;
            @Dialogue3.canceled += instance.OnDialogue3;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @PickUp.started -= instance.OnPickUp;
            @PickUp.performed -= instance.OnPickUp;
            @PickUp.canceled -= instance.OnPickUp;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @SubmitDialogue.started -= instance.OnSubmitDialogue;
            @SubmitDialogue.performed -= instance.OnSubmitDialogue;
            @SubmitDialogue.canceled -= instance.OnSubmitDialogue;
            @Dialogue1.started -= instance.OnDialogue1;
            @Dialogue1.performed -= instance.OnDialogue1;
            @Dialogue1.canceled -= instance.OnDialogue1;
            @Dialogue2.started -= instance.OnDialogue2;
            @Dialogue2.performed -= instance.OnDialogue2;
            @Dialogue2.canceled -= instance.OnDialogue2;
            @Dialogue3.started -= instance.OnDialogue3;
            @Dialogue3.performed -= instance.OnDialogue3;
            @Dialogue3.canceled -= instance.OnDialogue3;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSubmitDialogue(InputAction.CallbackContext context);
        void OnDialogue1(InputAction.CallbackContext context);
        void OnDialogue2(InputAction.CallbackContext context);
        void OnDialogue3(InputAction.CallbackContext context);
    }
}
