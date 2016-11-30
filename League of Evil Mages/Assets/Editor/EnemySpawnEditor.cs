using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemySpawnEditor : ScriptableWizard {

    public GameObject enemyPrefab;

    [MenuItem("My Tools/Create Spawn Point.")]
    static void CreateWizard(){
        ScriptableWizard.DisplayWizard<EnemySpawnEditor>("Create Point");
    }

    void OnWizardCreate(){
        GameObject wayPoint = new GameObject();
        
    }

    void OnWizardOtherButton(){
        
    }

}
