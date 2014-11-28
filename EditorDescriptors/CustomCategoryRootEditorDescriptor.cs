using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace UIExtensionSamples.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(CategoryList), UIHint = CustomCategoryRoot, EditorDescriptorBehavior = EditorDescriptorBehavior.ExtendBase)]
    public class CustomCategoryRootEditorDescriptor : EditorDescriptor
    {
        public CustomCategoryRootEditorDescriptor()
        {
            //We set the root property to the editor to alter the root category for the category picker dialog.
            EditorConfiguration["root"] = Category.GetRoot().Categories[0].ID;
        }

        public const string CustomCategoryRoot = "customcategoryroot";
    }
}