using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using UIExtensionSamples.EditorDescriptors;
using UIExtensionSamples.PropertySettings;

namespace UIExtensionSamples.Models
{
    [ContentType(
        GUID = "D178950C-D20E-4A46-90BD-5338B2424747")]
    public class SamplePageOne : SamplePageBase, SampleInterface
    {
        #region BuiltInContentReferences

        //Samples of content references with different hints to be able to pick different content.
        //For Commerce, there is a bunch of more hints to be able to pick different catalog content.

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Block)]
        public virtual ContentReference BlockReference { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.BlockFolder)]//BlockFolder and MediaFolder gives the same result since the folder structure is the same
        public virtual ContentReference Folder { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Image)]//Anything that implements IContentImage
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.Video)]//Anything that implements IContentVideo
        public virtual ContentReference Video { get; set; }

        [Display(GroupName = TabNames.ContentReferences)]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference MediaFileOfAnyType { get; set; }

        #endregion

        #region Url

        //For sites upgrading from EPiServer 7, you will have URL properties.
        //This is also useful if you want to be able to store additional information in
        //the URL, for instance [mediapath]?size=medium

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.MediaFile)]
        public virtual Url FileAsUrl { get; set; }

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.Image)]//Anything that implements IContentImage.
        public virtual Url ImageAsUrl { get; set; }

        [Display(GroupName = TabNames.Url)]
        [UIHint(UIHint.Video)]//Anything that implements IContentVideo.
        public virtual Url VideoAsUrl { get; set; }

        #endregion

        #region CustomReferences

        //You can build your own content reference editors.

        [Display(GroupName = TabNames.CustomReferences)]
        [UIHint(SampleBlockReferenceEditorDescriptor.SampleBlockHint)]
        public virtual ContentReference SampleBlock { get; set; }

        #endregion

        #region AllowedTypes

        //Content Area restricted to TeaserBlocks only.
        [Display(GroupName = TabNames.AllowedTypes)]
        [CultureSpecific]
        [AllowedTypes(new Type[] { typeof(SampleBlock) })]
        public virtual ContentArea RestrictedToSampleBlock { get; set; }

        #endregion

        #region AllowedTypes for Base Types and Interfaces

        //You can add restrictions for base types, but to be able to do this
        //you need to add a UIDescriptor for the base type. See SitePageDataDescriptor.
        [Display(GroupName = TabNames.AllowedTypes)]
        [AllowedTypes(new Type[] { typeof(SamplePageBase) })]
        public virtual ContentArea RestrictedToSamplePageBase { get; set; }

        //Currently, interfaces are not supported out of the box.
        //There is a work around though but it requires us to modify the UI descriptors.
        //See UIDescriptorInitialization for an example to do this.
        [Display(GroupName = TabNames.AllowedTypes)]
        [AllowedTypes(new Type[] { typeof(SampleInterface) })]
        public virtual ContentArea RestrictedToSampleInterface { get; set; }

        #endregion

        #region Property Settings

        [CultureSpecific]
        [PropertySettings(typeof(SimpleTinyMCESettings))]
        public virtual XhtmlString MainBody { get; set; }

        #endregion
    }
}
