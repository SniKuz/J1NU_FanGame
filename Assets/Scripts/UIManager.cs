using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	public GameManager gameManager;
	public GoodsSystem goodsSystem;

	public Image dateImage;
	public Sprite[] guageImage;
	public GameObject battery;
	public TextMeshProUGUI dateText;
	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI goodsText;
	public TextMeshProUGUI viwerText;

	public RectTransform stockPanel;


	private void LateUpdate() {

		dateImage.fillAmount = gameManager.time/20f;
		dateText.text = gameManager.day+"" ;		
		if(gameManager.money > 100000) moneyText.text = string.Format("{0:n0}", gameManager.money/1000)+"k";
		else moneyText.text = string.Format("{0:n0}", gameManager.money);
		if(gameManager.goods > 100000) goodsText.text = gameManager.goods/1000 +"k/" + goodsSystem.maxGoodsCapacity/1000 +"k";
		else goodsText.text = gameManager.goods + "/" + goodsSystem.maxGoodsCapacity;
		if(gameManager.viwer > 100000) viwerText.text = string.Format("{0:n0}", gameManager.viwer/1000)+"k";
		else viwerText.text = string.Format("{0:n0}", gameManager.viwer);

		battery.gameObject.GetComponent<Image>().sprite = guageImage[5 - gameManager.guage]; // battery change
	}

	public void PanelBtn(string panelName){
		if(panelName == "StockPanel"){
			if(stockPanel.localPosition.y == -878){
				stockPanel.DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);
			}else if(stockPanel.localPosition.y == 0){
				stockPanel.DOLocalMoveY(-878, 0.6f).SetEase(Ease.InBack);
			}
		}
	}
}
