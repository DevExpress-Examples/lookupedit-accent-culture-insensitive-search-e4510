using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid.LookUp;

namespace AccentInsensitiveSearch {
    public class AccentInsensitiveEditSettings : LookUpEditSettings {
        protected override DevExpress.Xpf.Editors.Helpers.ItemsProvider CreateItemsProvider() {
            return new AccentInsensitiveItemsProvider(this);
        }
    }
}
