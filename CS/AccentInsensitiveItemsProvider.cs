using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Editors.Helpers;
using System.Reflection;

namespace AccentInsensitiveSearch {
    public class AccentInsensitiveItemsProvider : ItemsProvider {
        public AccentInsensitiveItemsProvider(IItemsProviderOwner owner) : base(owner) { }

        public override int FindItemIndexByText(string text, bool isCaseSensitive, bool autoComplete) {
            if (text == null)
                return -1;
            return FindItemIndexByTextInternal(text, isCaseSensitive, autoComplete);
        }
        int FindItemIndexByTextInternal(string text, bool isCaseSensitive, bool autoComplete) {
            if (text.Length == 0) {
                for (int i = 0; i < Count; ++i) {
                    if (string.Empty == GetPrimaryText(this[i])) {
                        return DataController.GetListSourceRowIndex(i);
                    }
                }
            }
            else {
                if (!isCaseSensitive)
                    text = text.ToLower();
                for (int i = 0; i < Count; i++) {
                    string itemText = GetPrimaryText(this[i]);
                    if (itemText == null)
                        continue;
                    if (!isCaseSensitive)
                        itemText = itemText.ToLower();
                    if (autoComplete)
                        itemText = itemText.Substring(0, Math.Min(itemText.Length, text.Length));
                    if (string.Compare(text, itemText, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.IgnoreNonSpace) == 0) {
                        return DataController.GetListSourceRowIndex(i);
                    }
                }
            }
            return -1;
        }
        string GetPrimaryText(object item) {
            object value = GetDisplayValueFromItem(item);
            return value == null ? null : value.ToString();
        }
    }
}
