using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace UIExtensionSamples.EditorDescriptors
{
    [EditorDescriptorRegistrationAttribute(TargetType = typeof(ContentData))]
    public class SiteMetadataExtender : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<System.Attribute> attributes)
        {
            //This sample shows how to attach an editor descriptor that affects ContentData.
            //In this case we are moving the built in category property to the PageHeader group.
            foreach (ExtendedMetadata property in metadata.Properties)
            {
                if (property.PropertyName == "icategorizable_category")
                {
                    property.GroupName = SystemTabNames.PageHeader;
                    property.Order = 9000;
                }
            }
        }
    }
}
