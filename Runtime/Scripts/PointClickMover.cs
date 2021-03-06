﻿using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Collider2D), typeof(IDragging))]
    public class PointClickMover : MonoBehaviour
    {
        private Transform _transform;
        private Collider2D _collider2D;

        private Camera _camera;

        private Vector3 offset;
        private Vector3 mouseWorldPosition;

        private IDragging draggingItem;

        private Vector3 movingBlockTouchOffset;

        private void Awake()
        {
            _transform = transform;
            _camera = Camera.main;
            _collider2D = GetComponent<Collider2D>();
            draggingItem = GetComponent<IDragging>();

            movingBlockTouchOffset = new Vector3(0f, 1.5f, 0f);
        }

        private void OnMouseDown()
        {
            draggingItem.OnPickUp();

            mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            offset = _transform.position - mouseWorldPosition + movingBlockTouchOffset;
        }

        private void OnMouseDrag()
        {
            mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _transform.position = mouseWorldPosition + offset;

            draggingItem.OnMoving();
        }

        private void OnMouseUp()
        {
            draggingItem.OnRelease();
        }
    }
}