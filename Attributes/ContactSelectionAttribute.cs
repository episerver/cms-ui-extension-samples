using System;
using EPiServer.Shell.ObjectEditing;

namespace UIExtensionSamples.Attributes
{
    public class ContactSelectionAttribute : SelectOneAttribute
    {
        public override Type SelectionFactoryType
        {
            get
            {
                return typeof(SampleSelectionFactory);
            }
            set
            {
            }
        }
    }
}