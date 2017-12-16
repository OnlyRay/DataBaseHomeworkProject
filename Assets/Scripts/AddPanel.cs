using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;


public class AddPanel : MonoBehaviour {

    public UILabel inputAddMessage;
    public UILabel inputAddMessageValue;
    public UILabel inputAddTable;
    public UISprite addSuccess;
    public UISprite addFailure;
    public Text text;
    void Start()
    {
        //添加的列保存到inputAddMessage
        inputAddMessage = GameObject.Find("InputAddMessage/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //添加的列的值保存到inputAddMessageValue
        inputAddMessageValue = GameObject.Find("InputAddMessageValue/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //添加的表格保存到inputAddTable
        inputAddTable = GameObject.Find("InputAddTable/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //addSuccess = GameObject.Find("AddSuccess").GetComponent<UISprite>();
        //addFailure = GameObject.Find("AddFailure").GetComponent<UISprite>();
        
    }

    public void OnAddClick()
    {
        SqlAccess sql = new SqlAccess();
        string[] addmessage = new string[3];
        string[] addvalue = new string[3];
        addmessage = inputAddMessage.text.Split(',');
        addvalue = inputAddMessageValue.text.Split(',');
        bool InsertFlag = sql.InsertInto(inputAddTable.text, addmessage, addvalue);
        if(InsertFlag == true)
        {
            //添加成功
            addSuccess.gameObject.SetActive(true);
            HideSprite(addSuccess.gameObject);
        }
        else
        {
            //添加失败
            addFailure.gameObject.SetActive(true);
            HideSprite(addFailure.gameObject);
        }
        sql.Close();
    }

    public void OnSuccessClick()
    {
        addSuccess.gameObject.SetActive(false);
    }
    public void OnFailureClick()
    {
        addFailure.gameObject.SetActive(false);
    }


    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1.0f);
        go.SetActive(false);
    }
}
