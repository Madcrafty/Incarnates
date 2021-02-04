using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IncarnateSpawner))]
public class IncarnateCustomInspector : Editor
{
    int spawnListLength;
    Vector2Int newLevelBounds;
    Vector2Int newNumberBounds;
    //Vector2 newSizeBounds;
    public override void OnInspectorGUI()
    {
        // Initialise Menus
        IncarnateSpawner myTarget = (IncarnateSpawner)target;
        spawnListLength = myTarget.spawnList.Length;
        newLevelBounds = myTarget.levelBounds;
        newNumberBounds = myTarget.spawnNumberBounds;
        //newSizeBounds = myTarget.spawnSizeBounds;
        //Levels
        myTarget.randomizeLevels = EditorGUILayout.Toggle("Randomize Levels", myTarget.randomizeLevels);
        if (!myTarget.randomizeLevels)
        {
            myTarget.level = Mathf.Clamp(EditorGUILayout.IntField("Level", myTarget.level),0,100);
        }
        else
        {
            //myTarget.levelBounds = EditorGUILayout.Vector2IntField("Level Bounds", myTarget.levelBounds);
            newLevelBounds = EditorGUILayout.Vector2IntField("Level Bounds", myTarget.levelBounds);
            if (newLevelBounds.x != myTarget.levelBounds.x)
            {
                newLevelBounds.x = Mathf.Clamp(newLevelBounds.x, 0, 100);
                newLevelBounds.y = Mathf.Clamp(newLevelBounds.y, newLevelBounds.x, 100);
            }
            else if (newLevelBounds.y != myTarget.levelBounds.y)
            {
                newLevelBounds.y = Mathf.Clamp(newLevelBounds.y, 0, 100);
                newLevelBounds.x = Mathf.Clamp(newLevelBounds.x, 0, newLevelBounds.y);
                
            }
            myTarget.levelBounds = newLevelBounds;
        }
        //Spawn Number
        myTarget.randomizeNumber = EditorGUILayout.Toggle("Randomize Number Spawned", myTarget.randomizeNumber);
        if (!myTarget.randomizeNumber)
        {
            myTarget.spawnNumber = Mathf.Clamp(EditorGUILayout.IntField("Spawn Number", myTarget.spawnNumber),0,100);
        }
        else
        {
            //myTarget.spawnNumberBounds = EditorGUILayout.Vector2IntField("Spawn Number Bounds", myTarget.spawnNumberBounds);
            newNumberBounds = EditorGUILayout.Vector2IntField("Spawn Number Bounds", myTarget.spawnNumberBounds);
            if (newNumberBounds.x != myTarget.spawnNumberBounds.x)
            {      
                newNumberBounds.x = Mathf.Clamp(newNumberBounds.x, 0, 100);
                newNumberBounds.y = Mathf.Clamp(newNumberBounds.y, newNumberBounds.x, 100);
            }
            else if (newNumberBounds.y != myTarget.spawnNumberBounds.y)
            {
                newNumberBounds.y = Mathf.Clamp(newNumberBounds.y, 0, 100);
                newNumberBounds.x = Mathf.Clamp(newNumberBounds.x, 0, newNumberBounds.y);

            }
            myTarget.spawnNumberBounds = newNumberBounds;
        }
        //Spawn Size
        myTarget.randomizeSize = EditorGUILayout.Toggle("Randomize Size", myTarget.randomizeSize);
        //if (!myTarget.randomizeSize)
        //{
        //    myTarget.spawnSize = Mathf.Clamp(EditorGUILayout.FloatField("Spawn Size", myTarget.spawnSize), 0.1f, 10f);
        //}
        //else
        //{
        //    //myTarget.spawnNumberBounds = EditorGUILayout.Vector2IntField("Spawn Number Bounds", myTarget.spawnNumberBounds);
        //    newSizeBounds = EditorGUILayout.Vector2Field("Spawn Size Bounds", myTarget.spawnSizeBounds);
        //    if (newSizeBounds.x != myTarget.spawnSizeBounds.x)
        //    {
        //        newSizeBounds.x = Mathf.Clamp(newSizeBounds.x, 0.1f, 10);
        //        newSizeBounds.y = Mathf.Clamp(newSizeBounds.y, newSizeBounds.x, 10);
        //    }
        //    else if (newSizeBounds.y != myTarget.spawnSizeBounds.y)
        //    {
        //        newSizeBounds.y = Mathf.Clamp(newSizeBounds.y, 0.1f, 10);
        //        newSizeBounds.x = Mathf.Clamp(newSizeBounds.x, 0.1f, newSizeBounds.y);

        //    }
        //    myTarget.spawnSizeBounds = newSizeBounds;
        //}
        //Spawn List
        spawnListLength = Mathf.Clamp(EditorGUILayout.IntField("Spawn List Length", spawnListLength),0,100);
        if (myTarget.spawnList.Length != spawnListLength)
        {
            GameObject[] newList = new GameObject[spawnListLength];
            int i = 0;
            while (i < newList.Length && i < myTarget.spawnList.Length)
            {
                newList[i] = myTarget.spawnList[i];
                i++;
            }
            myTarget.spawnList = newList;
        }
        
        for (int i = 0; i < myTarget.spawnList.Length; i++)
        {
            myTarget.spawnList[i] = (GameObject)EditorGUILayout.ObjectField("Incarnate " + (i+1), myTarget.spawnList[i], typeof(GameObject), true);
        }
        
    }
}
