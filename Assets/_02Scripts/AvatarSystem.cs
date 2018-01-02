using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarSystem : MonoBehaviour
{
    public static AvatarSystem instance;

    private GameObject sourceObj;
    private Transform source;

    private GameObject targetObj;
    private Transform target;

    private Transform[] hips;

    private Dictionary<string, Dictionary<string, Transform>> data = new Dictionary<string, Dictionary<string, Transform>>();
    private Dictionary<string, SkinnedMeshRenderer> targetSmr = new Dictionary<string, SkinnedMeshRenderer>();

    string[,] avatarStr = new string[,] { { "coat", "003" }, { "hair", "003" }, { "pant", "003" }, { "hand", "003" }, { "foot", "003" }, { "head", "003" } };

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }
    private void Start()
    {
        AvatarManager(0.0f);
    }
    void AvatarManager(float pos)
    {
        InstantiateAvatar();
        InstantiateSkeleton(pos);
        hips = target.GetComponentsInChildren<Transform>();
        LoadAvatarData(source);
        Inivatar();
    }
    void InstantiateAvatar()
    {
        sourceObj = Instantiate(Resources.Load("FemaleAvatar")) as GameObject;
        source = sourceObj.transform;
        sourceObj.SetActive(false);
    }
    void InstantiateSkeleton(float pos)
    {
        targetObj = Instantiate(Resources.Load("TargetModel")) as GameObject;
        target = targetObj.transform;
        target.transform.position = new Vector3(pos, 0.0f, 0.0f);
    }
    void LoadAvatarData(Transform source)
    {
        data.Clear();
        targetSmr.Clear();

        if (source == null)
            return;

        SkinnedMeshRenderer[] parts = source.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        foreach (SkinnedMeshRenderer part in parts)
        {
            string[] partName = part.name.Split('-');
            if (!data.ContainsKey(partName[0]))
            {
                data.Add(partName[0], new Dictionary<string, Transform>());
                GameObject partObj = new GameObject();
                partObj.name = partName[0];
                partObj.transform.parent = target;

                targetSmr.Add(partName[0], partObj.AddComponent<SkinnedMeshRenderer>());
            }
            data[partName[0]].Add(partName[1], part.transform);
        }
    }
    void Inivatar()
    {
        int nLength = avatarStr.GetLength(0);
        for (int i = 0; i < nLength; i++)
        {
            ChangeMesh(avatarStr[i, 0], avatarStr[i, 1]);
        }
    }
    public void ChangeMesh(string part,string item)
    {
        SkinnedMeshRenderer smr = data[part][item].GetComponent<SkinnedMeshRenderer>();
        List<Transform> bones = new List<Transform>();
        foreach (Transform bone in smr.bones)
        {
            foreach (Transform hip in hips)
            {
                if (hip.name != bone.name)
                {
                    continue;
                }
                bones.Add(hip);
                break;
            }
        }
        targetSmr[part].sharedMesh = smr.sharedMesh;
        targetSmr[part].bones = bones.ToArray();
        targetSmr[part].materials = smr.materials;
    }
}
