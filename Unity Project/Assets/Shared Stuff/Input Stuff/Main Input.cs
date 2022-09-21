// GENERATED AUTOMATICALLY FROM 'Assets/Shared Stuff/Input Stuff/Main Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Main Input"",
    ""maps"": [
        {
            ""name"": ""Default Action Map"",
            ""id"": ""71019050-072a-46a8-811f-bcf7d0296234"",
            ""actions"": [
                {
                    ""name"": ""Left_Stick"",
                    ""type"": ""Value"",
                    ""id"": ""05c116d0-850b-4acb-9bcc-30e6a38fead9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right_Stick"",
                    ""type"": ""Value"",
                    ""id"": ""ced082d6-c81e-42c2-aff2-1a7559319e6a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North_Button"",
                    ""type"": ""Button"",
                    ""id"": ""4fc79605-12d4-48e9-9121-140c3182c834"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""East_Button"",
                    ""type"": ""Button"",
                    ""id"": ""e5d5b242-c109-4a03-9ce5-aa87616326d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South_Button"",
                    ""type"": ""Button"",
                    ""id"": ""64ddb134-7121-4fbf-be9f-23f192cd712d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West_Button"",
                    ""type"": ""Button"",
                    ""id"": ""dc178459-f8c4-4308-899b-57e41c12e5f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left_Bumper"",
                    ""type"": ""Button"",
                    ""id"": ""3294d689-e3ed-4b1e-91a2-2400cf75e6f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right_Bumper"",
                    ""type"": ""Button"",
                    ""id"": ""765b571a-ba67-4d35-9692-fb854bd8fd8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left_Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""6ccb2ece-0100-4a3d-b2fb-989a8203b864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right_Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""66d91c61-2005-4421-a5be-163e47d08b9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f29ce84-6e18-42c9-9c29-b7b1a55e30ba"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Left_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1fe5fc8-a1aa-4dd3-b728-449f4402f11c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Right_Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0f97a54-9078-400f-ad8f-aa9241b076ed"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""North_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""215a8017-cbe5-4709-a690-97329216679b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""East_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""077d2e0a-f9d6-4e00-b0fe-e863616ef76f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""South_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45c6fbff-7861-4d0a-8213-9a549d0b936b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""West_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71eb3849-1cba-480f-936c-89d51675d075"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Left_Bumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7c74a6c-4ce3-4b3a-ad14-863adcc8e198"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Right_Bumper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""429284fe-1e07-4f36-9393-f709baea0a2d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Left_Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""419697e3-2139-48ff-b0b5-d0f6bc6f22be"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Right_Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Default Action Map
        m_DefaultActionMap = asset.FindActionMap("Default Action Map", throwIfNotFound: true);
        m_DefaultActionMap_Left_Stick = m_DefaultActionMap.FindAction("Left_Stick", throwIfNotFound: true);
        m_DefaultActionMap_Right_Stick = m_DefaultActionMap.FindAction("Right_Stick", throwIfNotFound: true);
        m_DefaultActionMap_North_Button = m_DefaultActionMap.FindAction("North_Button", throwIfNotFound: true);
        m_DefaultActionMap_East_Button = m_DefaultActionMap.FindAction("East_Button", throwIfNotFound: true);
        m_DefaultActionMap_South_Button = m_DefaultActionMap.FindAction("South_Button", throwIfNotFound: true);
        m_DefaultActionMap_West_Button = m_DefaultActionMap.FindAction("West_Button", throwIfNotFound: true);
        m_DefaultActionMap_Left_Bumper = m_DefaultActionMap.FindAction("Left_Bumper", throwIfNotFound: true);
        m_DefaultActionMap_Right_Bumper = m_DefaultActionMap.FindAction("Right_Bumper", throwIfNotFound: true);
        m_DefaultActionMap_Left_Trigger = m_DefaultActionMap.FindAction("Left_Trigger", throwIfNotFound: true);
        m_DefaultActionMap_Right_Trigger = m_DefaultActionMap.FindAction("Right_Trigger", throwIfNotFound: true);
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

    // Default Action Map
    private readonly InputActionMap m_DefaultActionMap;
    private IDefaultActionMapActions m_DefaultActionMapActionsCallbackInterface;
    private readonly InputAction m_DefaultActionMap_Left_Stick;
    private readonly InputAction m_DefaultActionMap_Right_Stick;
    private readonly InputAction m_DefaultActionMap_North_Button;
    private readonly InputAction m_DefaultActionMap_East_Button;
    private readonly InputAction m_DefaultActionMap_South_Button;
    private readonly InputAction m_DefaultActionMap_West_Button;
    private readonly InputAction m_DefaultActionMap_Left_Bumper;
    private readonly InputAction m_DefaultActionMap_Right_Bumper;
    private readonly InputAction m_DefaultActionMap_Left_Trigger;
    private readonly InputAction m_DefaultActionMap_Right_Trigger;
    public struct DefaultActionMapActions
    {
        private @MainInput m_Wrapper;
        public DefaultActionMapActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left_Stick => m_Wrapper.m_DefaultActionMap_Left_Stick;
        public InputAction @Right_Stick => m_Wrapper.m_DefaultActionMap_Right_Stick;
        public InputAction @North_Button => m_Wrapper.m_DefaultActionMap_North_Button;
        public InputAction @East_Button => m_Wrapper.m_DefaultActionMap_East_Button;
        public InputAction @South_Button => m_Wrapper.m_DefaultActionMap_South_Button;
        public InputAction @West_Button => m_Wrapper.m_DefaultActionMap_West_Button;
        public InputAction @Left_Bumper => m_Wrapper.m_DefaultActionMap_Left_Bumper;
        public InputAction @Right_Bumper => m_Wrapper.m_DefaultActionMap_Right_Bumper;
        public InputAction @Left_Trigger => m_Wrapper.m_DefaultActionMap_Left_Trigger;
        public InputAction @Right_Trigger => m_Wrapper.m_DefaultActionMap_Right_Trigger;
        public InputActionMap Get() { return m_Wrapper.m_DefaultActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActionMapActions instance)
        {
            if (m_Wrapper.m_DefaultActionMapActionsCallbackInterface != null)
            {
                @Left_Stick.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Stick;
                @Left_Stick.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Stick;
                @Left_Stick.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Stick;
                @Right_Stick.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Stick;
                @Right_Stick.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Stick;
                @Right_Stick.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Stick;
                @North_Button.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnNorth_Button;
                @North_Button.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnNorth_Button;
                @North_Button.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnNorth_Button;
                @East_Button.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnEast_Button;
                @East_Button.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnEast_Button;
                @East_Button.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnEast_Button;
                @South_Button.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSouth_Button;
                @South_Button.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSouth_Button;
                @South_Button.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnSouth_Button;
                @West_Button.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnWest_Button;
                @West_Button.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnWest_Button;
                @West_Button.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnWest_Button;
                @Left_Bumper.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Bumper;
                @Left_Bumper.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Bumper;
                @Left_Bumper.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Bumper;
                @Right_Bumper.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Bumper;
                @Right_Bumper.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Bumper;
                @Right_Bumper.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Bumper;
                @Left_Trigger.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Trigger;
                @Left_Trigger.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Trigger;
                @Left_Trigger.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnLeft_Trigger;
                @Right_Trigger.started -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Trigger;
                @Right_Trigger.performed -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Trigger;
                @Right_Trigger.canceled -= m_Wrapper.m_DefaultActionMapActionsCallbackInterface.OnRight_Trigger;
            }
            m_Wrapper.m_DefaultActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left_Stick.started += instance.OnLeft_Stick;
                @Left_Stick.performed += instance.OnLeft_Stick;
                @Left_Stick.canceled += instance.OnLeft_Stick;
                @Right_Stick.started += instance.OnRight_Stick;
                @Right_Stick.performed += instance.OnRight_Stick;
                @Right_Stick.canceled += instance.OnRight_Stick;
                @North_Button.started += instance.OnNorth_Button;
                @North_Button.performed += instance.OnNorth_Button;
                @North_Button.canceled += instance.OnNorth_Button;
                @East_Button.started += instance.OnEast_Button;
                @East_Button.performed += instance.OnEast_Button;
                @East_Button.canceled += instance.OnEast_Button;
                @South_Button.started += instance.OnSouth_Button;
                @South_Button.performed += instance.OnSouth_Button;
                @South_Button.canceled += instance.OnSouth_Button;
                @West_Button.started += instance.OnWest_Button;
                @West_Button.performed += instance.OnWest_Button;
                @West_Button.canceled += instance.OnWest_Button;
                @Left_Bumper.started += instance.OnLeft_Bumper;
                @Left_Bumper.performed += instance.OnLeft_Bumper;
                @Left_Bumper.canceled += instance.OnLeft_Bumper;
                @Right_Bumper.started += instance.OnRight_Bumper;
                @Right_Bumper.performed += instance.OnRight_Bumper;
                @Right_Bumper.canceled += instance.OnRight_Bumper;
                @Left_Trigger.started += instance.OnLeft_Trigger;
                @Left_Trigger.performed += instance.OnLeft_Trigger;
                @Left_Trigger.canceled += instance.OnLeft_Trigger;
                @Right_Trigger.started += instance.OnRight_Trigger;
                @Right_Trigger.performed += instance.OnRight_Trigger;
                @Right_Trigger.canceled += instance.OnRight_Trigger;
            }
        }
    }
    public DefaultActionMapActions @DefaultActionMap => new DefaultActionMapActions(this);
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    public interface IDefaultActionMapActions
    {
        void OnLeft_Stick(InputAction.CallbackContext context);
        void OnRight_Stick(InputAction.CallbackContext context);
        void OnNorth_Button(InputAction.CallbackContext context);
        void OnEast_Button(InputAction.CallbackContext context);
        void OnSouth_Button(InputAction.CallbackContext context);
        void OnWest_Button(InputAction.CallbackContext context);
        void OnLeft_Bumper(InputAction.CallbackContext context);
        void OnRight_Bumper(InputAction.CallbackContext context);
        void OnLeft_Trigger(InputAction.CallbackContext context);
        void OnRight_Trigger(InputAction.CallbackContext context);
    }
}
