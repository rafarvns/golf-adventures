using System;
using MediaScripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMainMovement : MonoBehaviour
{
    public bool canMove = true;
    public float speed = 5;
    public StageMusicController stageMusicController;
    public PlayCounter playCounter;
    
    private bool _isMoving = false;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private String _backDirection;
    
    private Vector2 _startTouchPosition = Vector2.zero;
    private Vector2 _endTouchPosition = Vector2.zero;
    
    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }
    
    void Update()
    {
        if (!canMove) return;

        if (!_isMoving)
        {
            bool willPlaySwingSound = true;
            _isMoving = true;

            if (!_setDragDirection())
            {
                if (Input.GetKeyDown("w"))
                {
                    _moveToTop();
                }
                else if (Input.GetKeyDown("s"))
                {
                    _moveToBottom();
                }
                else if (Input.GetKeyDown("a"))
                {
                    _moveToRight();
                }
                else if (Input.GetKeyDown("d"))
                {
                    _moveToLeft();
                }
                else
                {
                    willPlaySwingSound = false;
                    _isMoving = false;
                }
            }
            
            if (willPlaySwingSound)
            {
                stageMusicController.PlaySoundEffect(SoundEffectEnum.GOLF_SWING);
            }
        }
        else
        {
            transform.Translate(_direction * Time.deltaTime);
        }
    }
    
    private bool _setDragDirection()
    {
        float verticalDifference = 0;
        float horizontalDifference = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            verticalDifference = _startTouchPosition.y - _endTouchPosition.y;
            horizontalDifference = _startTouchPosition.x - _endTouchPosition.x;
        }

        float sensitivity = 50f;

        if (Mathf.Abs(verticalDifference) < sensitivity && Mathf.Abs(horizontalDifference) < sensitivity)
            return false;

        if (Mathf.Abs(verticalDifference) > Mathf.Abs(horizontalDifference))
        {
            if (verticalDifference > 0)
                _moveToBottom();
            else
                _moveToTop();
        }
        else
        {
            if (horizontalDifference > 0)
                _moveToRight();
            else
                _moveToLeft();
        }

        _isMoving = true;
        stageMusicController.PlaySoundEffect(SoundEffectEnum.GOLF_SWING);

        return true;
    }

    
    private void _moveToRight()
    {
        _direction = new Vector3(-1f * speed, 0f, 0f);
        _backDirection = "d";
        playCounter.IncrementPlayCount();
    }

    private void _moveToLeft()
    {
        _direction = new Vector3(1f * speed, 0f, 0f);
        _backDirection = "a";
        playCounter.IncrementPlayCount();
    }

    private void _moveToTop()
    {
        _direction = new Vector3(0f, 0f, 1f * speed);
        _backDirection = "s";
        playCounter.IncrementPlayCount();
    }

    private void _moveToBottom()
    {
        _direction = new Vector3(0f, 0f, -1f * speed);
        _backDirection = "w";
        playCounter.IncrementPlayCount();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isMoving && other.gameObject.tag.Equals("Obstacle"))
        {
            _isMoving = false;
            _direction = new Vector3(0f, 0f, 0f);
            stageMusicController.PlaySoundEffect(SoundEffectEnum.WALL_HIT);

            Vector3 goTo = new Vector3(0f, 0f, 0f);
            if (_backDirection.Equals("s"))
            {
                goTo = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
            } else if (_backDirection.Equals("w"))
            {
                goTo = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            } else if (_backDirection.Equals("a"))
            {
                goTo = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            } else if (_backDirection.Equals("d"))
            {
                goTo = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }

            transform.position = goTo;
        }

        if (other.gameObject.tag.Equals("Bonus"))
        {
            Debug.Log("Oie");
            Destroy(other.gameObject);
            stageMusicController.PlaySoundEffect(SoundEffectEnum.BONUS);
            BallMainWin.CollectStar();
            playCounter.UpdateStars();
        }
    }


}
