using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonePrefab;
    [SerializeField] private UnityEvent _onEat;
    [SerializeField] private float _amountOfFood;
    [Range(0, 4), SerializeField] private float _moveSpeed;
    [Range(0, 90), SerializeField] private float _rotateSpeed;
    private int _amountOfFoodEaten = 0;

    private void Update()
    {
        MoveHead(_moveSpeed);
        MoveTail();
        Rotate(_rotateSpeed);
    }

    private void MoveHead(float speed)
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_bonesDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in _tails)
        {
            if((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else
            {
                break;
            }
        }
    }

    private void Rotate(float speed)
    {
        float directionAngle = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, directionAngle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Eat eat))
        {
            Destroy(other.gameObject);

            GameObject bone = Instantiate(_bonePrefab);
            _tails.Add(bone.transform);

            _amountOfFoodEaten++;

            if (_amountOfFoodEaten == _amountOfFood)
                Camera.main.GetComponent<UIManager>().Win();

            if (_onEat != null)
            {
                _onEat.Invoke();
            }
        }
    }
}
