using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputs : MonoBehaviour
{
    public bool interact;
    public bool mount;
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;
    public Vector2 look;
    public Character character;

    public void OnInteract(InputValue value)
		{
			InteractInput(value.isPressed);
		}
    public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
		}
    private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

    public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}
    public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

    public void EnableMovement(){
      cursorLocked=true;
      cursorInputForLook=true;
      character.enabled=true;
      Cursor.lockState =  CursorLockMode.Locked;
    }
    public void DisableMovement(){
      cursorLocked=false;
      cursorInputForLook=false;
      character.enabled=false;
      Cursor.lockState =  CursorLockMode.None;
    }



#region  CUSTOM_LOOK_INPUT_BY_COOL
    ////////////////////////////////////////////////////////////////////////////////////
    /// CUSTOM LOOK INPUT / CUSTOM LOOK INPUT / CUSTOM LOOK INPUT / CUSTOM LOOK INPUT //
    /// </summary>//////////////////////////////////////////////////////////////////////

    [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        public GameObject CinemachineCameraTarget;

        [Tooltip("How far in degrees can you move the camera up")]
        public float TopClamp = 70.0f;

        [Tooltip("How far in degrees can you move the camera down")]
        public float BottomClamp = -30.0f;

        [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
        public float CameraAngleOverride = 0.0f;

        [Tooltip("For locking the camera position on all axis")]
        public bool LockCameraPosition = false;

        // cinemachine
        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;
        public GameObject _mainCamera;
        private bool IsCurrentDeviceMouse=true;
        private const float _threshold = 0.01f;

        private void Awake()
        {
            // get a reference to our main camera
            if (_mainCamera == null)
            {
                _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }
        private void Start()
        {
            _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
        }
        private void LateUpdate()
        {
            CameraRotation();
        }
        private void CameraRotation()
        {
            // if there is an input and camera position is not fixed
            if (look.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                //Don't multiply mouse input by Time.deltaTime;
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                _cinemachineTargetYaw += look.x * deltaTimeMultiplier;
                _cinemachineTargetPitch += look.y * deltaTimeMultiplier;
            }

            // clamp our rotations so our values are limited 360 degrees
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Cinemachine will follow this target
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
#endregion

    ////////////////////////////////////////////////////////////////////////////////////
    /// CUSTOM LOOK INPUT / CUSTOM LOOK INPUT / CUSTOM LOOK INPUT / CUSTOM LOOK INPUT //
    /// </summary>//////////////////////////////////////////////////////////////////////
     
    public Vector2 move;
    public bool sprint;
    [Header("Movement Settings")]
		public bool analogMovement;
    public float playerSpeed;
    [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        public float MoveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")]
        public float SprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        public float RotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;
        // player
    public float _speed;
    public float _animationBlend;
    public float _targetRotation = 0.0f;
    public float _rotationVelocity;
    public float _verticalVelocity;
    public float _terminalVelocity = 53.0f;
    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        public float Gravity = -15.0f;
  

    public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}
    public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}
    public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
    public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
}
