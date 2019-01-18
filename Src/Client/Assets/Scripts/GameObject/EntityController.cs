using Entities;
using SkillBridge.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Rigidbody m_Rigibody;

    private AnimatorStateInfo m_CurrentBaseState;

    public Entity Entity;

    public Vector3 Position;

    public Vector3 Direction;

    Quaternion m_Rotation;

    public Vector3 LastPosition;

    Quaternion m_LastRotation;

    public float Speed;
    
    [SerializeField]
    private float m_AnimationSpeed = 1.5f;

    [SerializeField]
    private float m_JumpPower = 3.0f;

    public bool IsPlayer = false;


	void Start ()
    {
        if (Entity != null)
        {
            this.UpdateTransform();
        }
        if (!this.IsPlayer) m_Rigibody.useGravity = false;
		
	}

    void UpdateTransform()
    {
        this.Position = GameObjectTool.LogicToWorld(Entity.position);
        this.Direction = GameObjectTool.LogicToWorld(Entity.direction);

        this.m_Rigibody.MovePosition(this.Position);
        this.transform.forward = this.Direction;
        this.LastPosition = this.Position;
        this.m_LastRotation = this.m_Rotation;
    }

    void OnDestroy()
    {
        if (Entity != null)
        {
            Debug.LogFormat("{0} OnDestroy :ID:{1} POS:{2} DIR:{3} SPD:{4}", this.name, Entity.entityId, Entity.position, Entity.direction, Entity.speed);
        }

        if (UIWorldElementManager.Instance != null)
        {
            UIWorldElementManager.Instance.RemoveCharacterInfoBar(this.transform);
        }
    }

    void FixedUpdate()
    {
        if (this.Entity == null) return;

        this.Entity.OnUpdate(Time.fixedDeltaTime);

        if (!this.IsPlayer)
        {
            this.UpdateTransform();
        }
    }

    public void OnEntityEvent(EntityEvent entityEvent)
    {
        switch (entityEvent)
        {
            case EntityEvent.Idle:
                m_Animator.SetBool("Move", false);
                m_Animator.SetTrigger("Idle");
                break;
            case EntityEvent.MoveFwd:
                m_Animator.SetBool("Move", true);
                break;
            case EntityEvent.MoveBack:
                m_Animator.SetBool("Move", true);
                break;
            case EntityEvent.Jump:
                m_Animator.SetTrigger("Jump");
                break;
        }
    }
}
