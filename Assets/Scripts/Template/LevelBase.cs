using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeColor
{
    Blue,
    Purple,
    Red,
    Yellow,
    Green,
    Pink
}
[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelBase : ScriptableObject
{
    public int LevelNumber;
    public GameObject Model;
    public MeshCollider ModelMeshCollider;
    public int CubeSize;
    public CubeColor CubeColor;
    public Material LevelBaseColor;
   // public Color BackgroundColor;
    public int FieldOfView;
    public int feverValue;
    public bool IsChest;


}
