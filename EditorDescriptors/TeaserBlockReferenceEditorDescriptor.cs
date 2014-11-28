using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using UIExtensionSamples.Models;

namespace UIExtensionSamples.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(ContentReference), UIHint = SampleBlockHint)]
    public class SampleBlockReferenceEditorDescriptor : ContentReferenceEditorDescriptor<SampleBlock>
    {
        //This sample shows how to make a custom content reference editor descriptor.
        //This sample makes it possible to pick TeaserBlocks and it also helps the editors
        //by reducing the selection dialog to only show content from defined root(s).

        //Please note that the roots simply is a help function, it does not prevent editors
        //dragging TeaserBlock items from other folders directly from the Blocks gadget.

        public const string SampleBlockHint = "sampleblock";

        public override IEnumerable<ContentReference> Roots
        {
            get
            {
                //168 = Replace with your the folder you want to have as the root for the dialog.
                return new ContentReference[] { new ContentReference(168) };
            }
        }
    }
}