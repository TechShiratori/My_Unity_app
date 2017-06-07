using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataBase : MonoBehaviour
{

    // Use this for initialization
    public List<Enemy> enemys = new List<Enemy>();

    // Update is called once per frame
    public void SetInitialize(ItemDataBase database)	//初期の敵データ
    {
        enemys.Clear();
        enemys.Add(new Enemy("zombie", 0, "動き回る死体。動きは鈍重だが、ウィルスの影響で筋力が上がっている", 50, 10, -1, 50, database.items[1], 50, Enemy.EnemyStatus.Wait));
    }
}
