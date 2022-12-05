using System.Collections;
using UnityEngine;

[System.Serializable]
public enum SIDE
{
    LEFT,
    MID,
    RIGHT
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SIDE side = SIDE.MID;
    [SerializeField] private float _offsetBetweenPaths;

    private Animator _animator;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detect if one finger or more touch the screen then get the phase of the first
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }

        // To get the direction of the swipe we compare the finger's position at the beginning and at the end (when leaving the screen)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            // Left swipe
            if (_endTouchPosition.x < _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.LEFT;
                    _animator.Play("Left Swipe");
                    transform.Translate(-_offsetBetweenPaths * Time.deltaTime, 0f, 0f);
                }

                else if (side == SIDE.RIGHT)
                {
                    side = SIDE.MID;
                    _animator.Play("Left Swipe");
                    transform.Translate(-_offsetBetweenPaths * Time.deltaTime, 0f, 0f);
                }
            }

            // Right swipe
            else if (_endTouchPosition.x > _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.RIGHT;
                    _animator.Play("Right Swipe");
                    transform.Translate(_offsetBetweenPaths, 0f, 0f);

                }

                else if (side == SIDE.LEFT)
                {
                    side = SIDE.MID;
                    _animator.Play("Right Swipe");
                    transform.Translate(_offsetBetweenPaths, 0f, 0f);
                }
            }
        }
    }
}
