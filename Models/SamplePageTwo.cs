using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Templates.Alloy.Business.EditorDescriptors;
using EPiServer.Web;
using UIExtensionSamples;
using UIExtensionSamples.Attributes;
using UIExtensionSamples.EditorDescriptors;

namespace UIExtensionSamples.Models
{
    [ContentType(
        GUID = "D178950C-D20E-4A46-90BD-5338B2424746")]
    public class SamplePageTwo : SamplePageBase, SampleInterface
    {
        #region CustomAttributes

        //Example of you SelectOne attribute can be used to get a single selection from
        //a list of predefined items defined in the specified SelectionFactory.
        [SelectOne(SelectionFactoryType = typeof(SampleSelectionFactory))]
        public virtual string Contacts { get; set; } 

        //Here we have used the DRY principle to reduce code to define a specific attribute that extends
        //SelectOne with a predefined selection factory.
        [Display(GroupName = TabNames.CustomAttributes)]
        [ContactSelectionAttribute]
        public virtual string CustomCssClass { get; set; }

        //SelectMany works the same as SelectOne but enables multiple selections.
        [Display(GroupName = TabNames.CustomAttributes)]
        [SelectMany(SelectionFactoryType = typeof(SampleSelectionFactory))]
        public virtual string CustomCssClasses { get; set; }

        //Sample showing how to generate selection from an Enum by creating a custom attribute.
        [Display(GroupName = TabNames.CustomAttributes)]
        [BackingType(typeof(PropertyNumber))]//I have reported a feature request to remove the need for this to dev team.
        [EnumAttribute(typeof(SampleEnum))]
        public virtual SampleEnum Funkiness { get; set; }

        //Prevent editing or hide properties when editing unless you are part of specific roles.
        [Display(GroupName = TabNames.CustomAttributes)]
        [PropertyEditRestriction(new string[] { "Administrators" })]
        public virtual ContentReference RestrictedToEdit { get; set; }

        #endregion

        #region SuggestionEditors

        //The editor has to select one of the predefined choices.
        [Display(GroupName = TabNames.CustomAttributes)]
        [AutoSuggestSelection(typeof(SampleSelectionQuery))]
        public virtual string SelectionEditor1 { get; set; }

        //The editor can select one of the predefined choices but also enter custom values.
        [Display(GroupName = TabNames.CustomAttributes)]
        [AutoSuggestSelection(typeof(SampleSelectionQuery), AllowCustomValues = true)]
        public virtual string SelectionEditor2 { get; set; }

        #endregion

        #region More

        //This property shows how to create a category editor with a custom root node.
        [UIHint(CustomCategoryRootEditorDescriptor.CustomCategoryRoot)]
        public virtual CategoryList CustomCategories { get; set; }

        //Show ContainerPageUIDescriptor with custom icon and default view.

        //Show SiteMetadataExtender

        //Custom View

        //Tiny MCE settings in code

        //Drag and drop items into HTML editor

        #endregion
    }
}
