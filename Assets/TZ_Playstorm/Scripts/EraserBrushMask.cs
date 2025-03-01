using UnityEngine;

public class EraserBrushMask : MonoBehaviour
{
    [SerializeField] GameObject maskPrefab; // ������ �����
    [SerializeField] Camera mainCamera; // ������
    [SerializeField] Transform maskParent; // �������� �����
    [SerializeField] SpriteRenderer fenceSprite; // ������ ������

    private float totalFenceArea; // ����� ������� ������
    private float erasedArea = 0f; // ������� �������
    private int maskCount = 0; // ���������� �����

    void Start() {
        // �������� ������ ������ � ������� �����������
        totalFenceArea = fenceSprite.bounds.size.x * fenceSprite.bounds.size.y;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) // ���� ������ ��� ��� �����
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
            worldPos.z = 0; // ������������� Z � 0, ����� ����� ���� � 2D

            Debug.Log("���� � ������� �����������: " + worldPos);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);
            if (hit != null) {
                Debug.Log("������ � ������: " + hit.gameObject.name);

                if (hit.gameObject == fenceSprite.gameObject) {
                    CreateMask(worldPos);
                }
            } else {
                Debug.Log("�� ������ � �����!");
            }
        }
    }

    void CreateMask(Vector3 position) {
        GameObject mask = Instantiate(maskPrefab, position, Quaternion.identity, maskParent);
        maskCount++; // ����������� ������� �����
        erasedArea += 0.1f; // �������� ���������� ��������� (����� ����������)

    }
}
