using EPiServer.Core.PropertySettings;
using EPiServer.Editor.TinyMCE;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIExtensionSamples.PropertySettings
{
    [ServiceConfiguration(ServiceType = typeof(EPiServer.Core.PropertySettings.PropertySettings))]
    public class SimpleTinyMCESettings : PropertySettings<TinyMCESettings>
    {
        public SimpleTinyMCESettings()
        {
            //This class can be configured to be used for specific properties.
            IsDefault = false;
            DisplayName = "Test of settings from code";
        }

        public override TinyMCESettings GetPropertySettings()
        {
            var settings = new TinyMCESettings();

            var mainToolbar = new ToolbarRow(new List<string>() { "bold" });

            if (PrincipalInfo.CurrentPrincipal.IsInRole("administrators"))
            {
                //Chance to personalize.
                mainToolbar.Buttons.Add("italic");
            }

            settings.ToolbarRows.Add(mainToolbar);

            settings.Height = 20;
            settings.Width = 200;

            return settings;
        }

        public override System.Guid ID
        {
            get { return new System.Guid("a6fe936f-190d-45e2-b83c-ccc0501a7311"); }
        }
    }
}