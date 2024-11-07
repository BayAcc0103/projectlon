//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/MenuInput.inputactions
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

public partial class @MenuInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuInput"",
    ""maps"": [
        {
            ""name"": ""MenuButton"",
            ""id"": ""697ba9c8-391b-42e4-8541-a371ba199b79"",
            ""actions"": [
                {
                    ""name"": ""Start Button"",
                    ""type"": ""Button"",
                    ""id"": ""7e431f6d-7589-4ba8-9871-e4d5b8511505"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""End Button"",
                    ""type"": ""Button"",
                    ""id"": ""66f0dbd3-6dad-4a87-a6ef-737a6ee77fca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause Button"",
                    ""type"": ""Button"",
                    ""id"": ""657f67d5-1836-4615-ba39-3f31bddf439a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59b9473a-1ee9-4013-ba39-c9067ea3f895"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60da4ab3-4367-4dce-9f18-1f16bfa68438"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""End Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc4a217e-fec4-41c6-acca-b4996ef0bb3f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MenuButton
        m_MenuButton = asset.FindActionMap("MenuButton", throwIfNotFound: true);
        m_MenuButton_StartButton = m_MenuButton.FindAction("Start Button", throwIfNotFound: true);
        m_MenuButton_EndButton = m_MenuButton.FindAction("End Button", throwIfNotFound: true);
        m_MenuButton_PauseButton = m_MenuButton.FindAction("Pause Button", throwIfNotFound: true);
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

    // MenuButton
    private readonly InputActionMap m_MenuButton;
    private List<IMenuButtonActions> m_MenuButtonActionsCallbackInterfaces = new List<IMenuButtonActions>();
    private readonly InputAction m_MenuButton_StartButton;
    private readonly InputAction m_MenuButton_EndButton;
    private readonly InputAction m_MenuButton_PauseButton;
    public struct MenuButtonActions
    {
        private @MenuInput m_Wrapper;
        public MenuButtonActions(@MenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartButton => m_Wrapper.m_MenuButton_StartButton;
        public InputAction @EndButton => m_Wrapper.m_MenuButton_EndButton;
        public InputAction @PauseButton => m_Wrapper.m_MenuButton_PauseButton;
        public InputActionMap Get() { return m_Wrapper.m_MenuButton; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuButtonActions set) { return set.Get(); }
        public void AddCallbacks(IMenuButtonActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuButtonActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuButtonActionsCallbackInterfaces.Add(instance);
            @StartButton.started += instance.OnStartButton;
            @StartButton.performed += instance.OnStartButton;
            @StartButton.canceled += instance.OnStartButton;
            @EndButton.started += instance.OnEndButton;
            @EndButton.performed += instance.OnEndButton;
            @EndButton.canceled += instance.OnEndButton;
            @PauseButton.started += instance.OnPauseButton;
            @PauseButton.performed += instance.OnPauseButton;
            @PauseButton.canceled += instance.OnPauseButton;
        }

        private void UnregisterCallbacks(IMenuButtonActions instance)
        {
            @StartButton.started -= instance.OnStartButton;
            @StartButton.performed -= instance.OnStartButton;
            @StartButton.canceled -= instance.OnStartButton;
            @EndButton.started -= instance.OnEndButton;
            @EndButton.performed -= instance.OnEndButton;
            @EndButton.canceled -= instance.OnEndButton;
            @PauseButton.started -= instance.OnPauseButton;
            @PauseButton.performed -= instance.OnPauseButton;
            @PauseButton.canceled -= instance.OnPauseButton;
        }

        public void RemoveCallbacks(IMenuButtonActions instance)
        {
            if (m_Wrapper.m_MenuButtonActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuButtonActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuButtonActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuButtonActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuButtonActions @MenuButton => new MenuButtonActions(this);
    public interface IMenuButtonActions
    {
        void OnStartButton(InputAction.CallbackContext context);
        void OnEndButton(InputAction.CallbackContext context);
        void OnPauseButton(InputAction.CallbackContext context);
    }
}