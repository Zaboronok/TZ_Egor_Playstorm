using UnityEngine;

public class EraserBrushMask : MonoBehaviour
{
    [SerializeField] GameObject maskPrefab; // Префаб маски
    [SerializeField] Camera mainCamera; // Камера
    [SerializeField] Transform maskParent; // Родитель масок
    [SerializeField] SpriteRenderer fenceSprite; // Спрайт забора

    private float totalFenceArea; // Общая площадь забора
    private float erasedArea = 0f; // Стертая площадь
    private int maskCount = 0; // Количество масок

    void Start() {
        // Получаем размер забора в мировых координатах
        totalFenceArea = fenceSprite.bounds.size.x * fenceSprite.bounds.size.y;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) // Если нажата ЛКМ или палец
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
            worldPos.z = 0; // Устанавливаем Z в 0, чтобы маска была в 2D

            Debug.Log("Клик в мировых координатах: " + worldPos);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);
            if (hit != null) {
                Debug.Log("Попали в объект: " + hit.gameObject.name);

                if (hit.gameObject == fenceSprite.gameObject) {
                    CreateMask(worldPos);
                }
            } else {
                Debug.Log("Не попали в забор!");
            }
        }
    }

    void CreateMask(Vector3 position) {
        GameObject mask = Instantiate(maskPrefab, position, Quaternion.identity, maskParent);
        maskCount++; // Увеличиваем счетчик масок
        erasedArea += 0.1f; // Условное увеличение стертости (можно подстроить)

    }
}
