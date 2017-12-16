using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour {

    public UILabel inputSelMessage;
    public UILabel inputSelTable;
    public UILabel selectResult;
    public UILabel inputSelCondition;
    public UILabel inputSelConditionValue;
    MysqlConnector mysqlConnector = new MysqlConnector();
    
    void Start()
    {
        /*
        mysqlConnector.SetServer("127.0.0.1");
        mysqlConnector.SetPort("3306");
        mysqlConnector.SetUserID("root");
        mysqlConnector.SetPassword("LeiCaiPing19960907..");
        mysqlConnector.SetDataBase("databasehomework");
        mysqlConnector.SetCharset("utf8");
        */
        //要查询的信息保存到inputSelMessage
        inputSelMessage = GameObject.Find("InputSelMessage/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //要查询的表格保存到inputSelTable
        //inputSelTable = GameObject.Find("InputSelelctTable/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //查询结果
        selectResult = GameObject.Find("SelectBG/ScrollView/SelectResult").GetComponent<UILabel>();
        selectResult.text = "";
        inputSelCondition = GameObject.Find("InputSelectCondition/Control - Simple Input Field/Label").GetComponent<UILabel>();
        inputSelConditionValue = GameObject.Find("InputSelectConditionValue/Control - Simple Input Field/Label").GetComponent<UILabel>();
    }


    public void SelectButtonOnClick()
    {
        SqlAccess sql = new SqlAccess();
        string[] selMessage = new string[3];
        //string[] selCondition = new string[3];
        //string[] selConditionValue = new string[3];
        selMessage = inputSelMessage.text.Split(',');
        //selCondition = inputSelCondition.text.Split(',');
        //selConditionValue = inputSelConditionValue.text.Split(',');
        DataSet ds = sql.Select(inputSelTable.text, selMessage, new string[] { inputSelCondition.text }, new string[] { "=" }, new string[] { inputSelConditionValue.text });
        if (ds != null)
        {
           DataTable table = ds.Tables[0];
           int i = 1;
           foreach (DataRow dataRow in table.Rows)
           {
               foreach (DataColumn dataColumn in table.Columns)
               {
                   //Debug.Log(dataRow[dataColumn]);
                   selectResult.text += "\n" + i + ":" + dataRow[dataColumn].ToString();
                   i++;
               }
            }
         }
        sql.Close();
    }


    public void OnButtonSelectClearAllClicek()
    {
        selectResult.text = "";
    }

    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1.0f);
        go.SetActive(false);
    }
}
