using System;
using Components;
using GameManager;
using UnityEngine;

namespace Bullets
{
    public sealed class Bullet : MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener,
        IGameResumeListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Vector2 _velocity;

        private IGameListener[] _listeners;
        public IGameListener[] GetListeners()
        {
            if(_listeners==null)
                _listeners = GetComponents<IGameListener>();
            return _listeners;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
            
            if (!collision.gameObject.TryGetComponent(out TeamComponent team)) 
                return;

            if (IsPlayer == team.IsPlayer) 
                return;

            if (collision.gameObject.TryGetComponent(out HitPointsComponent hitPoints)) 
                hitPoints.TakeDamage(Damage);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
            rigidbody2D.velocity = _velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetDamage(int damage)
        {
            Damage = damage;
        }

        public void SetOwner(bool isPlayer)
        {
            IsPlayer = isPlayer;
        }

        
        public void OnGameStart()
        {
            rigidbody2D.velocity = _velocity;
        }

        public void OnGameFinish()
        {
            rigidbody2D.velocity = Vector2.zero;
        }

        public void OnGamePause()
        {
            rigidbody2D.velocity = Vector2.zero;
        }

        public void OnGameResume()
        {
            rigidbody2D.velocity = _velocity;
        }
    }
}