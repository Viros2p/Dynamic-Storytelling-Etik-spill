using UnityEngine;


[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    #region Enums
    private enum Directions { UP, DOWN, LEFT, RIGHT }
    #endregion

    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField] float _moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    #endregion


    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    private Directions _facingDirection = Directions.RIGHT;

    //anden video til animation
    private readonly int _animMoveRight = Animator.StringToHash("Anim_Player_Move_Right");
    private readonly int _animIdleRight = Animator.StringToHash("Anim_Player_Move_Right"); 
    private Animator anim; 


    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
        float HorizontalInput = Input.GetAxis("Horizontal");
            //anden video
        _animator.SetBool("Run", _moveDir.sqrMagnitude != 0);
    }
    private void Awake()
    {
        // Anden video til animation
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
    }


    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        _rb.linearVelocity = _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime;
    }
    #endregion

    #region Animation Logic
    private void CalculateFacingDirection()
    {
        if (_moveDir.x != 0)
        {
            if (_moveDir.x > 0) // Moving Right
            {
                _facingDirection = Directions.RIGHT;
            }
            else if (_moveDir.x < 0) // Moving Left
            {
                _facingDirection = Directions.LEFT;
            }
        }

    }   
    private void UpdateAnimation()
    {
        if (_facingDirection == Directions.LEFT)
        {
            _spriteRenderer.flipX = true;
        }
        else if(_facingDirection == Directions.RIGHT)
        {
            _spriteRenderer.flipX = false;            
        }

        // Anden video bruges til at skifte mellem Animationer
        //if (_moveDir.sqrMagnitude > 0) // we're moving
        {
        //    _animator.CrossFade(_animMoveRight, 0);
          //  print("Går)");
        }
      //  else 
        { 
        //    _animator.CrossFade(_animIdleRight, 0);
          //  print("Står stille");
        }
    }
   #endregion   
}
