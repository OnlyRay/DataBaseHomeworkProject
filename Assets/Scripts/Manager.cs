using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public TweenScale LoginPanelTween;
    public TweenScale OperationTween;
    public TweenScale AddPanelTween;
    public TweenScale DeletePanelTween;
    public TweenScale UpdatePanelTween;
    public TweenScale SelectPanelTween;
    public TweenScale SelectOperationTableTween;

    // public static LoginPanel loginPanel = null;

    public static OperationPanel operationPanel;
    public static AddPanel addPanel;
    public static DeletePanel deletePanel;
    public static UpdatePanel updatePanel;
    public static SelectPanel selectPanel;
    public static SelectOperationTable selectOperationTable;



    public void OnLoginClick()
    {//点击登陆按钮，跳转到操作界面
     //1.验证账号是否正确TODO
        LoginPanel.Instance.OnLoginClick();
        LoginPanelTween.PlayForward();
        StartCoroutine(HidePanel(LoginPanelTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    } 

    public void OnOperationBackToLoginButton()
    {
        //操作界面返回登陆界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        LoginPanelTween.gameObject.SetActive(true);
        LoginPanelTween.PlayForward();
    }

    public void OnOperationToAddButton()
    {
        //操作界面跳转到添加数据界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        AddPanelTween.gameObject.SetActive(true);
        AddPanelTween.PlayForward();
    }

    public void OnAddBackToOperationButton()
    {
        //添加数据界面跳转到操作界面
        StartCoroutine(HidePanel(AddPanelTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    }

    public void OnOperationToDeleteButton()
    {
        //操作界面跳转到删除数据界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        DeletePanelTween.gameObject.SetActive(true);
        DeletePanelTween.PlayForward();
    }

    public void OnDeleteBackToOperationButton()
    {
        //删除数据界面跳转到操作界面
        StartCoroutine(HidePanel(DeletePanelTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    }

    public void OnOperationToUpdateButton()
    {
        //操作界面跳转到修改数据界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        UpdatePanelTween.gameObject.SetActive(true);
        UpdatePanelTween.PlayForward();
    }

    public void OnUpdatedBackToOperationButton()
    {
        //修改数据界面跳转到操作界面
        StartCoroutine(HidePanel(UpdatePanelTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    }

    public void OnOperationToSelectButton()
    {
        //操作界面跳转到条件查询数据界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        SelectPanelTween.gameObject.SetActive(true);
        SelectPanelTween.PlayForward();
    }

    public void OnSelectBackToOperationButton()
    {
        //条件查询数据界面跳转到操作界面
        StartCoroutine(HidePanel(SelectPanelTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    }

    public void OnOperationToSelectTableButton()
    {
        //操作界面跳转到全表查询数据界面
        StartCoroutine(HidePanel(OperationTween.gameObject));
        SelectOperationTableTween.gameObject.SetActive(true);
        SelectOperationTableTween.PlayForward();
    }

    public void OnSelectTableBackToOperationButton()
    {
        //全表查询数据界面跳转到操作界面
        StartCoroutine(HidePanel(SelectOperationTableTween.gameObject));
        OperationTween.gameObject.SetActive(true);
        OperationTween.PlayForward();
    }
    //隐藏面板
    IEnumerator HidePanel(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        go.SetActive(false);
    }
}
