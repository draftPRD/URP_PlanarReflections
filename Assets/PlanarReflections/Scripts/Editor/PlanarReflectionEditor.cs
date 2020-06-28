using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

// Declare type of Custom Editor
[CustomEditor(typeof(RecursiveReflectionControl))] //1
public class PlanarReflectionEditor : Editor
{
    float thumbnailWidth = 70;
    float thumbnailHeight = 70;
    public bool boolToogleButton_Ground;
    public bool boolToogleButton_Ceiling;
    public bool boolToogleButton_Left;
    public bool boolToogleButton_Right;
    public bool boolToogleButton_Forward;
    public bool boolToogleButton_Back;
    [SerializeField]
    private RecursiveReflectionControl rrc;
    SerializedObject GetTarget;
    private List<RecursiveReflectionControl.PlanarReflectionSettings> prs =
        new List<RecursiveReflectionControl.PlanarReflectionSettings>();
    private void OnEnable()
    { 
        rrc = ( RecursiveReflectionControl)target;
            GetTarget = new SerializedObject(rrc);
    }
    public void Settingsbuild(RecursiveReflectionControl.PlanarReflectionSettings PlanarLayer)
    {
            PlanarLayer.recursiveReflection = rrc.recursiveReflectionGroups;
            PlanarLayer.recursiveGroup = rrc.recursiveGroup;
            PlanarLayer.frameSkip = rrc.frameSkip;
            PlanarLayer.addBlackColour = rrc.addBlackColour;
            PlanarLayer.enableHdr = rrc.hdr;
            PlanarLayer.clipPlaneOffset = rrc.reflectionOffset;
            PlanarLayer.enableMsaa = rrc.msaa;
            PlanarLayer.occlusion = rrc.occlusion;
            PlanarLayer.shadows = rrc.shadows;
            PlanarLayer.enableLights = rrc.additionalLights;
            PlanarLayer.resolutionMultiplier = rrc.resolutionMultiplier;
            PlanarLayer.reflectLayers = rrc.reflectLayers;
            prs.Add(PlanarLayer);
    }
    public override void OnInspectorGUI() //2
    {
        base.OnInspectorGUI();
        GetTarget.Update();
        boolToogleButton_Ground = rrc.boolToogleButton_Ground;
        boolToogleButton_Ceiling = rrc.boolToogleButton_Ceiling;
        boolToogleButton_Left = rrc.boolToogleButton_Left;
        boolToogleButton_Right = rrc.boolToogleButton_Right;
        boolToogleButton_Back = rrc.boolToogleButton_Back;
        boolToogleButton_Forward = rrc.boolToogleButton_Forward;
        prs = rrc.prs;
        GUILayout.Space(20f);
        GUILayout.Label("STEP #4 - Complete setup by choosing planar direction");
        GUILayout.BeginHorizontal();
        var PlanarLayer = new RecursiveReflectionControl.PlanarReflectionSettings();
        if (boolToogleButton_Ground == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubebottom"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Ground = true;
                PlanarLayer.direction = new float3(0, 1, 0);
                PlanarLayer.shaderName = "_PlanarGround";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Ground = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubebottom"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
        {
            boolToogleButton_Ground = rrc.boolToogleButton_Ground;
            int removalint = 999;
                for (int i =0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarGround")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {
                    boolToogleButton_Ground = false;
                    prs.RemoveRange(removalint, 1);
                    rrc.boolToogleButton_Ground = false;
                    GetTarget.ApplyModifiedProperties();
                }
        }}
        if (boolToogleButton_Ceiling == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubetop"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Ceiling = true;
                PlanarLayer.direction = new float3(0, -1, 0);
                PlanarLayer.shaderName = "_PlanarCeiling";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Ceiling = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubetop"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                int removalint = 999;
                for (int i = 0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarCeiling")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {
                    prs.RemoveRange(removalint, 1);
                    boolToogleButton_Ceiling = false;
                    rrc.boolToogleButton_Ceiling = false;
                    GetTarget.ApplyModifiedProperties();
                }
            }
        }
        if (boolToogleButton_Right == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cuberight"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Right = true;
                PlanarLayer.direction = new float3(1, 0, 0);
                PlanarLayer.shaderName = "_PlanarRight";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Right = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cuberight"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                
                int removalint = 999;
                for (int i = 0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarRight")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {boolToogleButton_Right = false;
                    prs.RemoveRange(removalint, 1);
 rrc.boolToogleButton_Right = false;
 GetTarget.ApplyModifiedProperties();
                }
            }
        }
        if (boolToogleButton_Left == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeleft"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Left = true;
                PlanarLayer.direction = new float3(-1, 0, 0);
                PlanarLayer.shaderName = "_PlanarLeft";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Left = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeleft"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                int removalint = 999;
                for (int i = 0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarLeft")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {
                    prs.RemoveRange(removalint, 1);
                    rrc.boolToogleButton_Left =false;
                    boolToogleButton_Left = false;
                    GetTarget.ApplyModifiedProperties();
                }
            }
        }
        if (boolToogleButton_Forward == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeforward"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Forward = true;
                PlanarLayer.direction = new float3(0, 0, 1);
                PlanarLayer.shaderName = "_PlanarForward";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Forward = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeforward"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                int removalint = 999;
                for (int i = 0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarForward")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {
                    prs.RemoveRange(removalint, 1);
                    rrc.boolToogleButton_Forward = false;
                    boolToogleButton_Forward = false;
                    GetTarget.ApplyModifiedProperties();
                }
            }
        }
        if (boolToogleButton_Back == false)
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeback"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                boolToogleButton_Back = true;
                PlanarLayer.direction = new float3(0, 0, -1);
                PlanarLayer.shaderName = "_PlanarBack";
                Settingsbuild(PlanarLayer);
                rrc.boolToogleButton_Back = true;
                GetTarget.ApplyModifiedProperties();
            }
        }
        else
        {
            if (GUILayout.Button(Resources.Load<Texture>("Thumbnails/cubeback"),
                GUILayout.Width(thumbnailWidth), GUILayout.Height(thumbnailHeight)))
            {
                int removalint = 999;
                for (int i = 0; i < prs.Count; i++)
                {
                    if (prs[i].shaderName == "_PlanarBack")
                    {
                        removalint = i;
                        break;
                    }
                }
                if (removalint != 999)
                {
                    prs.RemoveRange(removalint, 1);
                    boolToogleButton_Back = false;
                    rrc.boolToogleButton_Back = false;
                    GetTarget.ApplyModifiedProperties();
                }
            }
        }
        rrc.planarReflectionLayers = prs.ToArray();
        GetTarget.ApplyModifiedProperties();
        EditorUtility.SetDirty(GetTarget.targetObject);
        GUILayout.EndHorizontal(); //4
    }
}
