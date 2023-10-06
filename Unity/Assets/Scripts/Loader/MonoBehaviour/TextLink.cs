using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ET.Client
{
    /// <summary>
    /// </summary>
    public class TextLink: MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public TextMeshProUGUI chatMessageArea;
        private bool isHoveringObject;
        private TMP_MeshInfo[] m_cachedMeshInfoVertexData;
        private int m_lastIndex = -1;
        private int m_selectedLink = -1;
        private int m_selectedWord = -1;
        public UnityAction<string, Vector3> OnClickLink;

        private void LateUpdate()
        {
            if (this.isHoveringObject)
            {
#region Example of Link Handling

                // Check if mouse intersects with any links.
                var linkIndex = TMP_TextUtilities.FindIntersectingLink(this.chatMessageArea, Input.mousePosition, null);

                // Clear previous link selection if one existed.
                if ((linkIndex == -1 && this.m_selectedLink != -1) || linkIndex != this.m_selectedLink)
                    this.m_selectedLink = -1;
                if (linkIndex != -1 && linkIndex != this.m_selectedLink)
                {
                    this.m_selectedLink = linkIndex;

                    var linkInfo = this.chatMessageArea.textInfo.linkInfo[linkIndex];

                    Debug.Log("Link ID: \"" + linkInfo.GetLinkID() + "\"   Link Text: \"" + linkInfo.GetLinkText()
                        + "\""); // Example of how to retrieve the Link ID and Link Text.

                    Vector3 worldPointInRectangle;
                    RectTransformUtility.ScreenPointToWorldPointInRectangle(this.chatMessageArea.rectTransform, Input.mousePosition, null,
                        out worldPointInRectangle);
                    print($"worldPointInRectangle -- {worldPointInRectangle}");
                }

#endregion Example of Link Handling

#region Word Selection Handling

                //Check if Mouse intersects any words and if so assign a random color to that word.
                var wordIndex = TMP_TextUtilities.FindIntersectingWord(this.chatMessageArea, Input.mousePosition, null);

                // Clear previous word selection.
                if (this.m_selectedWord != -1 && (wordIndex == -1 || wordIndex != this.m_selectedWord))
                    this.ClearPreviousWordSelection();

                // Word Selection Handling
                if (wordIndex != -1 && wordIndex != this.m_selectedWord && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    this.WordSelectionHandling(wordIndex);

                    // Update Geometry
                    this.chatMessageArea.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
                }

#endregion Word Selection Handling
            }
            else
            {
                // Restore any character that may have been modified
                if (this.m_lastIndex != -1)
                {
                    this.RestoreCachedVertexAttributes(this.m_lastIndex);
                    this.m_lastIndex = -1;
                }
            }
        }

        private void OnEnable() =>
                // Subscribe to event fired when text object has been regenerated.
                TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this.OnTextChanged);

        private void OnDisable() =>
                // UnSubscribe to event fired when text object has been regenerated.
                TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this.OnTextChanged);

        public void OnPointerClick(PointerEventData eventData)
        {
            var pTextMeshPro = this.GetComponent<TextMeshProUGUI>();

            var linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position,
                null); // If you are not in a Canvas using Screen Overlay, put your camera instead of null
            if (linkIndex != -1)
            {
                var linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
                Debug.Log("Click at POS: " + eventData.position + "  World POS: " + eventData.pointerCurrentRaycast.worldPosition);
                this.OnClickLink?.Invoke(linkInfo.GetLinkID(), eventData.position);
            }
        }

        public void OnPointerEnter(PointerEventData eventData) => this.isHoveringObject = true;

        public void OnPointerExit(PointerEventData eventData)
        {
            this.isHoveringObject = false;
            if (this.m_selectedWord != -1)
                this.ClearPreviousWordSelection();
        }

        private void WordSelectionHandling(int wordIndex)
        {
            this.m_selectedWord = wordIndex;

            var wInfo = this.chatMessageArea.textInfo.wordInfo[wordIndex];

            // Iterate through each of the characters of the word.
            for (var i = 0; i < wInfo.characterCount; i++)
            {
                var characterIndex = wInfo.firstCharacterIndex + i;

                // Get the index of the material / sub text object used by this character.
                var meshIndex = this.chatMessageArea.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                var vertexIndex = this.chatMessageArea.textInfo.characterInfo[characterIndex].vertexIndex;

                // Get a reference to the vertex color
                var vertexColors = this.chatMessageArea.textInfo.meshInfo[meshIndex].colors32;

                var c = vertexColors[vertexIndex + 0].Tint(0.75f);

                vertexColors[vertexIndex + 0] = c;
                vertexColors[vertexIndex + 1] = c;
                vertexColors[vertexIndex + 2] = c;
                vertexColors[vertexIndex + 3] = c;
            }
        }

        private void ClearPreviousWordSelection()
        {
            var wInfo = this.chatMessageArea.textInfo.wordInfo[this.m_selectedWord];

            // Iterate through each of the characters of the word.
            for (var i = 0; i < wInfo.characterCount; i++)
            {
                var characterIndex = wInfo.firstCharacterIndex + i;

                // Get the index of the material / sub text object used by this character.
                var meshIndex = this.chatMessageArea.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                // Get the index of the first vertex of this character.
                var vertexIndex = this.chatMessageArea.textInfo.characterInfo[characterIndex].vertexIndex;

                // Get a reference to the vertex color
                var vertexColors = this.chatMessageArea.textInfo.meshInfo[meshIndex].colors32;

                var c = vertexColors[vertexIndex + 0].Tint(1.33333f);

                vertexColors[vertexIndex + 0] = c;
                vertexColors[vertexIndex + 1] = c;
                vertexColors[vertexIndex + 2] = c;
                vertexColors[vertexIndex + 3] = c;
            }

            // Update Geometry
            this.chatMessageArea.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

            this.m_selectedWord = -1;
        }

        private void RestoreCachedVertexAttributes(int index)
        {
            if (index == -1 || index > this.chatMessageArea.textInfo.characterCount - 1) return;

            // Get the index of the material / sub text object used by this character.
            var materialIndex = this.chatMessageArea.textInfo.characterInfo[index].materialReferenceIndex;

            // Get the index of the first vertex of the selected character.
            var vertexIndex = this.chatMessageArea.textInfo.characterInfo[index].vertexIndex;

            // Restore Vertices
            // Get a reference to the cached / original vertices.
            var src_vertices = this.m_cachedMeshInfoVertexData[materialIndex].vertices;

            // Get a reference to the vertices that we need to replace.
            var dst_vertices = this.chatMessageArea.textInfo.meshInfo[materialIndex].vertices;

            // Restore / Copy vertices from source to destination
            dst_vertices[vertexIndex + 0] = src_vertices[vertexIndex + 0];
            dst_vertices[vertexIndex + 1] = src_vertices[vertexIndex + 1];
            dst_vertices[vertexIndex + 2] = src_vertices[vertexIndex + 2];
            dst_vertices[vertexIndex + 3] = src_vertices[vertexIndex + 3];

            // Restore Vertex Colors
            // Get a reference to the vertex colors we need to replace.
            var dst_colors = this.chatMessageArea.textInfo.meshInfo[materialIndex].colors32;

            // Get a reference to the cached / original vertex colors.
            var src_colors = this.m_cachedMeshInfoVertexData[materialIndex].colors32;

            // Copy the vertex colors from source to destination.
            dst_colors[vertexIndex + 0] = src_colors[vertexIndex + 0];
            dst_colors[vertexIndex + 1] = src_colors[vertexIndex + 1];
            dst_colors[vertexIndex + 2] = src_colors[vertexIndex + 2];
            dst_colors[vertexIndex + 3] = src_colors[vertexIndex + 3];

            // Restore UV0S
            // UVS0
            var src_uv0s = this.m_cachedMeshInfoVertexData[materialIndex].uvs0;
            var dst_uv0s = this.chatMessageArea.textInfo.meshInfo[materialIndex].uvs0;
            dst_uv0s[vertexIndex + 0] = src_uv0s[vertexIndex + 0];
            dst_uv0s[vertexIndex + 1] = src_uv0s[vertexIndex + 1];
            dst_uv0s[vertexIndex + 2] = src_uv0s[vertexIndex + 2];
            dst_uv0s[vertexIndex + 3] = src_uv0s[vertexIndex + 3];

            // UVS2
            var src_uv2s = this.m_cachedMeshInfoVertexData[materialIndex].uvs2;
            var dst_uv2s = this.chatMessageArea.textInfo.meshInfo[materialIndex].uvs2;
            dst_uv2s[vertexIndex + 0] = src_uv2s[vertexIndex + 0];
            dst_uv2s[vertexIndex + 1] = src_uv2s[vertexIndex + 1];
            dst_uv2s[vertexIndex + 2] = src_uv2s[vertexIndex + 2];
            dst_uv2s[vertexIndex + 3] = src_uv2s[vertexIndex + 3];

            // Restore last vertex attribute as we swapped it as well
            var lastIndex = (src_vertices.Length / 4 - 1) * 4;

            // Vertices
            dst_vertices[lastIndex + 0] = src_vertices[lastIndex + 0];
            dst_vertices[lastIndex + 1] = src_vertices[lastIndex + 1];
            dst_vertices[lastIndex + 2] = src_vertices[lastIndex + 2];
            dst_vertices[lastIndex + 3] = src_vertices[lastIndex + 3];

            // Vertex Colors
            src_colors = this.m_cachedMeshInfoVertexData[materialIndex].colors32;
            dst_colors = this.chatMessageArea.textInfo.meshInfo[materialIndex].colors32;
            dst_colors[lastIndex + 0] = src_colors[lastIndex + 0];
            dst_colors[lastIndex + 1] = src_colors[lastIndex + 1];
            dst_colors[lastIndex + 2] = src_colors[lastIndex + 2];
            dst_colors[lastIndex + 3] = src_colors[lastIndex + 3];

            // UVS0
            src_uv0s = this.m_cachedMeshInfoVertexData[materialIndex].uvs0;
            dst_uv0s = this.chatMessageArea.textInfo.meshInfo[materialIndex].uvs0;
            dst_uv0s[lastIndex + 0] = src_uv0s[lastIndex + 0];
            dst_uv0s[lastIndex + 1] = src_uv0s[lastIndex + 1];
            dst_uv0s[lastIndex + 2] = src_uv0s[lastIndex + 2];
            dst_uv0s[lastIndex + 3] = src_uv0s[lastIndex + 3];

            // UVS2
            src_uv2s = this.m_cachedMeshInfoVertexData[materialIndex].uvs2;
            dst_uv2s = this.chatMessageArea.textInfo.meshInfo[materialIndex].uvs2;
            dst_uv2s[lastIndex + 0] = src_uv2s[lastIndex + 0];
            dst_uv2s[lastIndex + 1] = src_uv2s[lastIndex + 1];
            dst_uv2s[lastIndex + 2] = src_uv2s[lastIndex + 2];
            dst_uv2s[lastIndex + 3] = src_uv2s[lastIndex + 3];

            // Need to update the appropriate
            this.chatMessageArea.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }

        private void OnTextChanged(UnityEngine.Object obj)
        {
            if (obj as TextMeshProUGUI == this.chatMessageArea)
                    // Update cached vertex data.
                this.m_cachedMeshInfoVertexData = this.chatMessageArea.textInfo.CopyMeshInfoVertexData();
        }
    }
}