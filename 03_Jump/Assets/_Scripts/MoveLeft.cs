using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
