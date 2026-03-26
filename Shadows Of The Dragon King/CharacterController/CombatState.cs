using JetBrains.Annotations;
using UnityEngine;
public class CombatState : State
{
    float gravityValue;
    Vector3 currentVelocity;
    bool grounded;
    bool sheathWeapon;
    float playerSpeed;
    bool attack;
    Vector3 cVelocity;

    //Custom BY Cool
    CharacterInputs _input;
    public CombatState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        character.animator.applyRootMotion = false;

        
        //Custom BY Cool
        _input=character._input;

        sheathWeapon = false;
        input = Vector2.zero;
        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;
        attack = false;
        

        velocity = character.playerVelocity;
        playerSpeed = character.stats.Speed.Value;
        grounded = character.controller.isGrounded;
        gravityValue = character.gravityValue;
        //_input.move = Vector2.zero;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (drawWeaponAction.triggered && character.weaponDrawn)
        {
            sheathWeapon = true;
        }

		if (attackAction.triggered)
		{
            attack = true;
		}
        /*if (_input.move == Vector2.zero){
            character.controler.velocity=Vector3.zero;
        }*/

        /*input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * character.cameraTransform.right.normalized + velocity.z * character.cameraTransform.forward.normalized;
        velocity.y = 0f;*/

        //Custom By Cool
        input = moveAction.ReadValue<Vector2>();
        Move();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        character.animator.SetFloat("speed", input.magnitude, character.speedDampTime, Time.deltaTime);

        if (sheathWeapon)
        {
            character.animator.SetTrigger("sheathWeapon");
            stateMachine.ChangeState(character.standing);
        }

		if (attack)
		{
            character.animator.SetTrigger("attack");
            stateMachine.ChangeState(character.attacking);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        /*gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;

        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTime);
        character.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);

        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity), character.rotationDampTime);
        }*/

    }

    public override void Exit()
    {
        base.Exit();

        gravityVelocity.y = 0f;
        /*character.playerVelocity = new Vector3(input.x, 0, input.y);

        if (velocity.sqrMagnitude > 0)
        {
            character.transform.rotation = Quaternion.LookRotation(velocity);
        }*/

    }






    //Custom
    private void Move()
        {
            // set target speed based on move speed, sprint speed and if sprint is pressed
            float targetSpeed = _input.sprint ? _input.SprintSpeed : _input.MoveSpeed;

            // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

            // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is no input, set the target speed to 0
            if (_input.move == Vector2.zero) targetSpeed = 0.0f;

            // a reference to the players current horizontal velocity
            float currentHorizontalSpeed = new Vector3(character.controler.velocity.x, 0.0f,character.controler.velocity.z).magnitude;

            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // accelerate or decelerate to target speed
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                _input._speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * _input.SpeedChangeRate);

                // round speed to 3 decimal places
                _input._speed = Mathf.Round(_input._speed * 1000f) / 1000f;
            }
            else
            {
                _input._speed = targetSpeed;
            }

            _input._animationBlend = Mathf.Lerp(_input._animationBlend, targetSpeed, Time.deltaTime * _input.SpeedChangeRate);
            if (_input._animationBlend < 0.01f) _input._animationBlend = 0f;

            // normalise input direction
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is a move input rotate player when the player is moving
            if (_input.move != Vector2.zero)
            {
                _input._targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _input._mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(character.transform.eulerAngles.y, _input._targetRotation, ref _input._rotationVelocity,
                    _input.RotationSmoothTime);

                // rotate to face input direction relative to camera position
                character.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }


            Vector3 targetDirection = Quaternion.Euler(0.0f, _input._targetRotation, 0.0f) * Vector3.forward;

            // move the player
            character.controler.Move(targetDirection.normalized * (_input._speed * Time.deltaTime) +
                             new Vector3(0.0f, _input._verticalVelocity, 0.0f) * Time.deltaTime);

            //Custom Garvity Extra
            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_input._verticalVelocity < _input._terminalVelocity)
            {
                _input._verticalVelocity += _input.Gravity * Time.deltaTime;
            }
        }

}
