using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Assets;
using System.Data;
using UnityEngine.UI;

public class UpdatePanel : MonoBehaviour {

    public UILabel inputUpdateCol;
    public UILabel inputUpdateColValue;
    public UILabel inputUpdateTable;
    public UILabel inputUpdateCondition;
    public UILabel inputUpdateConditionValue;
    public UISprite updateSuccess;
    public UISprite updateFailure;


    void Start()
    {
        //要更新的列保存到inputUpdateCol
        inputUpdateCol = GameObject.Find("InputUpdCol/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //要更新的列值保存到inputUpdateColValue
        inputUpdateColValue = GameObject.Find("InputUpdColValue/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //要修改的表格保存到inputUpdateTable
        inputUpdateTable = GameObject.Find("InputUpdTable/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //要更新的条件列保存到inputUpdateNewMessage
        inputUpdateCondition = GameObject.Find("InputUpdCondition/Control - Simple Input Field/Label").GetComponent<UILabel>();
        //要更新的条件列值保存到inputUpdateNewMessage
        inputUpdateConditionValue = GameObject.Find("InputUpdConditionValue/Control - Simple Input Field/Label").GetComponent<UILabel>();
        updateSuccess = transform.Find("UpdateSuccess").GetComponent<UISprite>();
        updateFailure = transform.Find("UpdateFailure").GetComponent<UISprite>();
    }

    public void OnUpdateClick()
    {
        SqlAccess sql = new SqlAccess();
        string[] updatecol = new string[3];
        string[] updatecolvalue = new string[3];
        updatecol = inputUpdateCol.text.Split(',');
        updatecolvalue = inputUpdateColValue.text.Split(',');
        bool UpdateFlag = sql.UpdateInto(inputUpdateTable.text, updatecol, updatecolvalue, inputUpdateCondition.text, inputUpdateConditionValue.text);
        if(UpdateFlag == true)
        {
            //更新成功
            updateSuccess.gameObject.SetActive(true);
            HideSprite(updateSuccess.gameObject);
        }
        else
        {
            //更新失败
            updateFailure.gameObject.SetActive(true);
            HideSprite(updateFailure.gameObject);
        }
        sql.Close();
    }

    public void OnSuccessClick()
    {
        updateSuccess.gameObject.SetActive(false);
    }
    public void OnFailureClick()
    {
        updateFailure.gameObject.SetActive(false);
    }


    IEnumerator HideSprite(GameObject go)
    {
        yield return new WaitForSeconds(1.0f);
        go.SetActive(false);
    }
}
