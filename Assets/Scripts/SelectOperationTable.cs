using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;

public class SelectOperationTable : MonoBehaviour
{
    public UILabel inputSelTable;
    public UILabel selectResult;
    MysqlConnector mysqlConnector = new MysqlConnector();
    
    void Start()
    {
        selectResult = GameObject.Find("SelectBG/ScrollView/SelectResult").GetComponent<UILabel>();
        selectResult.text = "";
    }


    public void SelectButtonOnClick()
    {
        SqlAccess sql = new SqlAccess();
        string[] selMessage = new string[3];
        DataSet ds = sql.Select(inputSelTable.text);
        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            int i = 1;
            foreach (DataRow dataRow in table.Rows)
            {
                selectResult.text += i + ":";
                i++;
                foreach (DataColumn dataColumn in table.Columns)
                {
                    //Debug.Log(dataRow[dataColumn]);
                    selectResult.text +="    " + dataRow[dataColumn].ToString();
                }
                selectResult.text += "\n";
            }
        }
        sql.Close();
    }

    public void OnButtonSelectTableClearAllClicek()
    {
        selectResult.text = "";
    }

    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1.0f);
        go.SetActive(false);
    }
}
