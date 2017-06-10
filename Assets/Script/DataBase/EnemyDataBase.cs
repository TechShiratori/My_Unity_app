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
        enemys.Add(new Enemy("zombie", 0, "動き回る死体。動きは鈍重だが、ウィルスの影響で筋力が上がっている", 50, 10, 10, 50, database.items[1], 50, Enemy.EnemyStatus.Wait));
        enemys.Add(new Enemy("BlackWolf", 1, "犬をベースにした実験生物。実験の完全な成功はせず、凶暴性と筋力が上がっているが細胞組織が自壊し始めている", 150, 10, 20, 50, database.items[2], 50, Enemy.EnemyStatus.Wait));
        enemys.Add(new Enemy("BlackWorm", 2, "ミミズをベースにした実験生物。兵器用途のため凶暴性が高いが、調整不足のため人間を手当たり次第襲うよう担っている", 150, 10, 5, 500, database.items[2], 10, Enemy.EnemyStatus.Wait));
    }
}
