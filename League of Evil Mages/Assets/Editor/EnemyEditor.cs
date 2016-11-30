using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemyEditor : ScriptableWizard {

    public string enemyName;
    public int enemyLifePoint;
    public int enemyDamage;
    public bool isMove;
    public float enemySpeed;

    public Sprite enemySprite;


    [MenuItem("My Tools/Create Enemy.")]
    static void CreateWizard(){
        ScriptableWizard.DisplayWizard<EnemyEditor>("Create Enemy", "Create New");
    }

    void OnWizardCreate(){
        GameObject enemyGO = new GameObject();

        if (isMove){
            EnemyMove enemyMove = enemyGO.AddComponent<EnemyMove>();
            enemyMove.speed = enemySpeed;
        }

        enemyGO.name = enemyName;
        SpriteRenderer spriteRender = enemyGO.AddComponent<SpriteRenderer>();
        spriteRender.sprite = enemySprite;
        Animator anime = enemyGO.AddComponent<Animator>();

        BoxCollider box = enemyGO.AddComponent<BoxCollider>();
        Vector3 boxSize = spriteRender.bounds.size;
        box.size = boxSize;
        float x = Random.Range(210, 230);
        float z = Random.Range(110, 135);

        Debug.Log("Sprite render size: " + spriteRender.bounds.size);

        enemyGO.transform.position = new Vector3(x, 2.47f, z);

    }



}
