using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : BinBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if (transform.childCount > 0) return; //Kiểm tra slot đã có item chưa?
		Debug.Log("OnDrop");
		GameObject dropObj = eventData.pointerDrag;
		DragItem dragItem = dropObj.GetComponent<DragItem>();
		dragItem.SetRealParent(transform);
	}
}
