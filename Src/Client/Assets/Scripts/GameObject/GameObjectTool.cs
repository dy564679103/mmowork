using SkillBridge.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTool
{

    public static Vector3 LogicToWorld(NVector3 nVector3)
    {
        return new Vector3(nVector3.X / 100f, nVector3.Z / 100f, nVector3.Y / 100f);
    }


    public static Vector3 LogicToWorld(Vector3Int vector3)
    {
        return new Vector3(vector3.x / 100f, vector3.z / 100f, vector3.y / 100f);
    }


    public static float LogicToWorld(int val)
    {
        return val / 100f;
    }


    public static int WorldToLogic(float val)
    {
        return Mathf.RoundToInt(val * 100f);
    }


    public static NVector3 WorldToLogicN(Vector3 vector3)
    {
        return new NVector3()
        {
            X = Mathf.RoundToInt(vector3.x * 100f),
            Y = Mathf.RoundToInt(vector3.z * 100f),
            Z = Mathf.RoundToInt(vector3.y * 100f)
        };
    }


    public static Vector3Int WorldToLogic(Vector3 vector3)
    {
        return new Vector3Int()
        {
            x = Mathf.RoundToInt(vector3.x * 100f),
            y = Mathf.RoundToInt(vector3.z * 100f),
            z = Mathf.RoundToInt(vector3.y * 100f)
        };
    }


    public static bool EntityUpdate(NEntity nEntity, Vector3 position, Quaternion rotation, float speed)
    {
        NVector3 nPossition = WorldToLogicN(position);
        NVector3 nDirection = WorldToLogicN(rotation.eulerAngles);
        int _speed = WorldToLogic(speed);
        bool updated = false;
        if (!nEntity.Position.Equal(nPossition))
        {
            nEntity.Position = nPossition;
            updated = true;
        }
        if (!nEntity.Direction.Equal(nDirection))
        {
            nEntity.Direction = nDirection;
            updated = true;
        }
        if (nEntity.Speed != _speed)
        {
            nEntity.Speed = _speed;
            updated = true;
        }
        return updated;
    }
}
