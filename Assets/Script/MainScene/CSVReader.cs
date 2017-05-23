using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
 
/// <summary>
/// CSVファイルを読み込み、データを保持するクラス
/// </summary>
public class CSVReader
{
    /// <summary>
    /// CSVファイルの拡張子
    /// </summary>
    public const string _EXTENSION = ".csv";
 
    /// <summary>
    /// セルを区切る為にキャラ
    /// </summary>
    public const char _SPLIT_CHAR = ',';
 
    /// <summary>
    /// 行がコメントだと言う事を表す文字列
    /// </summary>
    string m_commentString = "//";
 
    // 読み込んだデータ
    List<List<string>> m_data = new List<List<string>>();
    TextAsset m_textAsset = null;
 
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="comment">コメントの文字列</param>
    /// <param name="isReadFromDisc">Resourcesでなくディスク(フルパス)から読み込むか</param>
    public CSVReader(string comment = "//")
    {
        m_textAsset = null;
        m_data = new List<List<string>>(10);
        m_commentString = comment;
    }
}