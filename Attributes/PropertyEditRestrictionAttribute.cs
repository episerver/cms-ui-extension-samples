using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;

namespace UIExtensionSamples.Attributes
{
    public class PropertyEditRestrictionAttribute : ValidationAttribute, IMetadataAware
    {
        public PropertyEditRestrictionAttribute(string[] allowedRoles)
        {
            //This sample shows a custom attribute that does two things:
            //Hides or disables a property when editing.
            //Enforces server side validation when saving data as well to prevent fake requests sending forged updates.
            AllowedRoles = allowedRoles;
        }

        public string[] AllowedRoles { get; set; }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            foreach(string role in AllowedRoles)
            {
                if (EPiServer.Security.PrincipalInfo.CurrentPrincipal.IsInRole(role))
                {
                    return;
                }
            }
            //Comment row below to test validation when saving.

            //Show the property but make it read only
            metadata.IsReadOnly = true;

            //Hide the property entirely when in "All properties" mode.
            //metadata.ShowForEdit = false;
        }

        public override string FormatErrorMessage(string name)
        {
 	         return "You do not have access to change the property: " + name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contentData = validationContext.ObjectInstance as IContentData;
            if(contentData == null)
            {
                //This attribute only handles instances of IContentData.
                return ValidationResult.Success;
            }
            if(!contentData.Property[validationContext.MemberName].IsModified)
            {
                return ValidationResult.Success;
            }
            if( Validate())
            {
                return ValidationResult.Success;
            }
            else { return new ValidationResult("You do not have access"); }
        }

        public override bool RequiresValidationContext
        {
            get
            {
                return true;
            }
        }

        public bool Validate()
        {
            foreach (string role in AllowedRoles)
            {
                if (EPiServer.Security.PrincipalInfo.CurrentPrincipal.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}