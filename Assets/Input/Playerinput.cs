//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/Playerinput.inputactions
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

public partial class @Playerinput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Playerinput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Playerinput"",
    ""maps"": [
        {
            ""name"": ""ConsoleInput"",
            ""id"": ""31cc9d3b-0f71-4474-bd2e-b6631cf359f5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""980f083a-3310-42f0-af73-c0403cc0bc7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""101f51e5-366a-47a0-8ecf-3c3445ec0c57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8c41bc51-48f1-4cbd-9831-84cb7c0eda44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""aec40da5-833d-4af0-84b8-47a2558e510c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Button"",
                    ""id"": ""b1192ab5-6e49-4e99-be4e-049c43affb71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""7ed862bb-b2f1-4b72-8acb-73425f12c9ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0cc7eab1-9a6c-4475-9135-e9993ba43509"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""018cc55d-baa4-41d8-8e38-06f57619a855"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91f8a168-74e8-47c6-8107-f00216bfd675"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""783dbeae-2d7a-4bf7-8822-a54ce02b5bbf"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d391bcd7-6471-410a-b42a-9ef2b7aec12d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0715e818-3760-4a73-9e7e-d8c3cb19efa4"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HeadTracking"",
            ""id"": ""6803632b-2ee1-4b57-8885-3e66a403c553"",
            ""actions"": [
                {
                    ""name"": ""HeadSet"",
                    ""type"": ""Value"",
                    ""id"": ""6bdd87e9-1652-40ac-9767-129b00d2d6df"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f71a57e4-7063-42be-8364-95db150c16be"",
                    ""path"": ""<XRHMD>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeadSet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ConsoleInput
        m_ConsoleInput = asset.FindActionMap("ConsoleInput", throwIfNotFound: true);
        m_ConsoleInput_Move = m_ConsoleInput.FindAction("Move", throwIfNotFound: true);
        m_ConsoleInput_Jump = m_ConsoleInput.FindAction("Jump", throwIfNotFound: true);
        m_ConsoleInput_Attack = m_ConsoleInput.FindAction("Attack", throwIfNotFound: true);
        m_ConsoleInput_Look = m_ConsoleInput.FindAction("Look", throwIfNotFound: true);
        m_ConsoleInput_Climb = m_ConsoleInput.FindAction("Climb", throwIfNotFound: true);
        m_ConsoleInput_Save = m_ConsoleInput.FindAction("Save", throwIfNotFound: true);
        // HeadTracking
        m_HeadTracking = asset.FindActionMap("HeadTracking", throwIfNotFound: true);
        m_HeadTracking_HeadSet = m_HeadTracking.FindAction("HeadSet", throwIfNotFound: true);
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

    // ConsoleInput
    private readonly InputActionMap m_ConsoleInput;
    private List<IConsoleInputActions> m_ConsoleInputActionsCallbackInterfaces = new List<IConsoleInputActions>();
    private readonly InputAction m_ConsoleInput_Move;
    private readonly InputAction m_ConsoleInput_Jump;
    private readonly InputAction m_ConsoleInput_Attack;
    private readonly InputAction m_ConsoleInput_Look;
    private readonly InputAction m_ConsoleInput_Climb;
    private readonly InputAction m_ConsoleInput_Save;
    public struct ConsoleInputActions
    {
        private @Playerinput m_Wrapper;
        public ConsoleInputActions(@Playerinput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ConsoleInput_Move;
        public InputAction @Jump => m_Wrapper.m_ConsoleInput_Jump;
        public InputAction @Attack => m_Wrapper.m_ConsoleInput_Attack;
        public InputAction @Look => m_Wrapper.m_ConsoleInput_Look;
        public InputAction @Climb => m_Wrapper.m_ConsoleInput_Climb;
        public InputAction @Save => m_Wrapper.m_ConsoleInput_Save;
        public InputActionMap Get() { return m_Wrapper.m_ConsoleInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConsoleInputActions set) { return set.Get(); }
        public void AddCallbacks(IConsoleInputActions instance)
        {
            if (instance == null || m_Wrapper.m_ConsoleInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ConsoleInputActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Climb.started += instance.OnClimb;
            @Climb.performed += instance.OnClimb;
            @Climb.canceled += instance.OnClimb;
            @Save.started += instance.OnSave;
            @Save.performed += instance.OnSave;
            @Save.canceled += instance.OnSave;
        }

        private void UnregisterCallbacks(IConsoleInputActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Climb.started -= instance.OnClimb;
            @Climb.performed -= instance.OnClimb;
            @Climb.canceled -= instance.OnClimb;
            @Save.started -= instance.OnSave;
            @Save.performed -= instance.OnSave;
            @Save.canceled -= instance.OnSave;
        }

        public void RemoveCallbacks(IConsoleInputActions instance)
        {
            if (m_Wrapper.m_ConsoleInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IConsoleInputActions instance)
        {
            foreach (var item in m_Wrapper.m_ConsoleInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ConsoleInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ConsoleInputActions @ConsoleInput => new ConsoleInputActions(this);

    // HeadTracking
    private readonly InputActionMap m_HeadTracking;
    private List<IHeadTrackingActions> m_HeadTrackingActionsCallbackInterfaces = new List<IHeadTrackingActions>();
    private readonly InputAction m_HeadTracking_HeadSet;
    public struct HeadTrackingActions
    {
        private @Playerinput m_Wrapper;
        public HeadTrackingActions(@Playerinput wrapper) { m_Wrapper = wrapper; }
        public InputAction @HeadSet => m_Wrapper.m_HeadTracking_HeadSet;
        public InputActionMap Get() { return m_Wrapper.m_HeadTracking; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeadTrackingActions set) { return set.Get(); }
        public void AddCallbacks(IHeadTrackingActions instance)
        {
            if (instance == null || m_Wrapper.m_HeadTrackingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HeadTrackingActionsCallbackInterfaces.Add(instance);
            @HeadSet.started += instance.OnHeadSet;
            @HeadSet.performed += instance.OnHeadSet;
            @HeadSet.canceled += instance.OnHeadSet;
        }

        private void UnregisterCallbacks(IHeadTrackingActions instance)
        {
            @HeadSet.started -= instance.OnHeadSet;
            @HeadSet.performed -= instance.OnHeadSet;
            @HeadSet.canceled -= instance.OnHeadSet;
        }

        public void RemoveCallbacks(IHeadTrackingActions instance)
        {
            if (m_Wrapper.m_HeadTrackingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHeadTrackingActions instance)
        {
            foreach (var item in m_Wrapper.m_HeadTrackingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HeadTrackingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HeadTrackingActions @HeadTracking => new HeadTrackingActions(this);
    public interface IConsoleInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnClimb(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
    }
    public interface IHeadTrackingActions
    {
        void OnHeadSet(InputAction.CallbackContext context);
    }
}
