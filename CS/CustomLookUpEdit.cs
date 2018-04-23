using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Editors.Settings;

namespace AccentInsensitiveSearch {
    public class CustomLookUpEdit : LookUpEdit {
        protected override BaseEditSettings CreateEditorSettings() {
            return new AccentInsensitiveEditSettings();
        }
    }
}
