using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : BinBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField] protected Image image;
	[SerializeField] protected Transform realParent;

	public virtual void SetRealParent(Transform realParent)
	{
		this.realParent = realParent;
	}
	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadImage();
	}

	protected virtual void LoadImage()
	{
		if (this.image != null) return;
		this.image = GetComponent<Image>();
		Debug.Log(transform.name + ": LoadImage", gameObject);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("On begin drag");
		this.realParent = transform.parent;
		transform.parent = UIHotKeyCtrl.Instance.transform;
		this.image.raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("On drag");

		Vector3 mousePos = InputManager.Instance.MouseWorldPosition;

		mousePos.x = 0;
		mousePos.z = 0;
		transform.position = mousePos;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("On end drag");
		transform.parent = this.realParent;
		this.image.raycastTarget = true;

	}
}
