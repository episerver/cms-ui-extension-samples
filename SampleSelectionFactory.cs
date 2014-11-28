using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace UIExtensionSamples
{
    public class SampleSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var items = new string[] { "ada", "beta", "cobol", "delta"};

            return items.Select(item => new SelectItem { Text = item, Value = item });
        }
    } 
}