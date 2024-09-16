using UnityEngine;
using UnityEngine.UI;
/*参考URL*/
//https://note.com/what_is_picky/n/nf9b5dca6e5b6
//オブジェクトの平行移動だと切れ目が見えてしまうので、
//マテリアルの平行移動で処理する。

public class tBackSkyMove : MonoBehaviour
{
    private const float k_maxLength = 1f;//最大値
    private const string k_propName = "_MainTex";//シェーダー変数名

    [SerializeField]
    private Vector2 m_offsetSpeed;

    private Material m_material;

    private void Start()
    {
        //Imageコンポーネントの中のマテリアルを取得
        if (GetComponent<Image>() is Image i)
        {
            m_material = i.material;
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // xとyの値が0 ～ 1でリピートするようにする
            //Mathf.Repeat(A,B);は、Aに渡した式の結果がBに達する度に0に戻るというもの。
            //A%Bに近い。
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);
            //offsetは表示位置を示しているだけ
            //k_propNameは……シェーダー変数名なので、知っとくしかない。
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // ゲームをやめた後にマテリアルのOffsetを戻しておく
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
