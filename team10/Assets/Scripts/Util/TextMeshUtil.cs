using UnityEngine;


public static class TextMeshUtil {

    /// <summary>
    /// TextMeshの幅を返す．
    /// 利用する際はtransform.localscale.xをかけて使うこと．
    /// スケールのサイズの変更には対応してないため．
    /// </summary>
    /// <returns>The width of TextMesh</returns>
    /// <param name="mesh">TextMesh</param>
	public static float GetWidth(TextMesh mesh)
	{
		float width = 0;
		foreach (char symbol in mesh.text)
		{
			CharacterInfo info;
			if (mesh.font.GetCharacterInfo(symbol, out info, mesh.fontSize, mesh.fontStyle))
			{
				width += info.advance;
			}
		}
		return width * mesh.characterSize * 0.1f;
	}
}
