using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;

public class DeletePanel : MonoBehaviour {

    public UILabel inputDeleteMessage;
    public UILabel inputDeleteMessageValue;
    public UILabel inputDeleteTable;
    public UISprite deleteSuccess;
    public UISprite deleteFailure;

    void Start()
    {
        //删除的列保存到inputDeleteMessage
        inputDeleteMessage = GameObject.Find("InputDelMessage/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //删除的列的值保存到inputDeleteMessageValue
        inputDeleteMessageValue = GameObject.Find("InputDelMessageValue/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //删除的表格保存到inputDeleteTable
        inputDeleteTable = GameObject.Find("InputDelTable/Control - Simple Input Field/Label").GetComponent<UILabel>();
        deleteSuccess = transform.Find("DeleteSuccess").GetComponent<UISprite>();
        deleteFailure = transform.Find("DeleteFailure").GetComponent<UISprite>();
    }

    public void OnDeleteClick()
    {
        SqlAccess sql = new SqlAccess();
        string[] deleteMessage = new string[3];
        deleteMessage = inputDeleteMessage.text.Split(',');
        string[] deleteMessageValue = new string[3];
        deleteMessageValue = inputDeleteMessageValue.text.Split(',');
        bool deleteFlag = sql.Delete(inputDeleteTable.text, deleteMessage,deleteMessageValue);
        if (deleteFlag == true)
        {//删除成功
            deleteSuccess.gameObject.SetActive(true);
            HideSprite(deleteSuccess.gameObject);
        }
        else
        { 
        //删除失败
        deleteFailure.gameObject.SetActive(true);
        HideSprite(deleteFailure.gameObject);
        }
        sql.Close();
    }

    public void OnSuccessClick()
    {
        deleteSuccess.gameObject.SetActive(false);
    }
    public void OnFailureClick()
    {
        deleteFailure.gameObject.SetActive(false);
    }

    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1.0f);
        go.SetActive(false);
    }
}
