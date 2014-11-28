using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell;
using UIExtensionSamples.Models;

namespace OctoberDemo2MVC.Business.UIExtensions.UIDescriptors
{
    [UIDescriptorRegistration]
    public class SamplePageUIDescriptor : UIDescriptor<SamplePageOne>, IEditorDropBehavior
    {
        public SamplePageUIDescriptor()
            : base("customcontenttypeicon")//This string matches a CSS class, either built in or a custom class defined in a style sheet
        //configured to be loaded in the UI. See sample CSS in the end of this class.
        {
            //We configure the system to load the "All properties views" when loading content of this type.
            DefaultView = CmsViewNames.AllPropertiesView;

            //You can turn off specific views for a type.
            DisabledViews = new string[] { CmsViewNames.OnPageEditView };

            //You can also specifically set which views should be available.
            //AvailableViews = new string[] { CmsViewNames.AllPropertiesView };
        }

        public EditorDropBehavior EditorDropBehaviour
        {
            get
            {
                //This tells the UI that when dropping a page of this type into a HTML editor
                //this should result in a content block (instead of creating a link that's the default drop behaviour for pages).
                return EditorDropBehavior.CreateContentBlock;
            }
            set
            {

            }
        }
    }

    //Put the following class in a style sheet loaded in the UI, for instance Styles.css in the Alloy sample site.

    //.Sleek .customcontenttypeicon {
    //  background: url('../Images/customcontenticon.png') no-repeat;
    //  height: 16px;
    //  width: 16px;
    //}
}