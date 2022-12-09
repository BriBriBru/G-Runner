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
    [SerializeField] private GameObject _leftPath;
    [SerializeField] private GameObject _middlePath;
    [SerializeField] private GameObject _rightPath;

    private Animator _animator;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private Vector3 _leftPathPos;
    private Vector3 _middlePathPos;
    private Vector3 _rightPathPos;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _leftPathPos = new Vector3(_leftPath.transform.position.x, _leftPath.transform.position.y, 0f);
        _middlePathPos = new Vector3(_middlePath.transform.position.x, _middlePath.transform.position.y, 0f);
        _rightPathPos = new Vector3(_rightPath.transform.position.x, _rightPath.transform.position.y, 0f);
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
            _animator.enabled = false;

            // Left swipe
            if (_endTouchPosition.x < _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.LEFT;
                    transform.position = _leftPathPos;
                }

                else if (side == SIDE.RIGHT)
                {
                    side = SIDE.MID;
                    transform.position = _middlePathPos;
                }
            }

            // Right swipe
            else if (_endTouchPosition.x > _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.RIGHT;
                    transform.position = _rightPathPos;
                }

                else if (side == SIDE.LEFT)
                {
                    side = SIDE.MID;
                    transform.position = _middlePathPos;
                }
            }
        }

        _animator.enabled = true;
    }
}
