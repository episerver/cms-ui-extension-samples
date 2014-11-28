using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace UIExtensionSamples.Models
{
    [ContentType(DisplayName = "SampleBlock", GUID = "d367a5a3-a045-4fba-be69-22a0a61daaa3", Description = "")]
    public class SampleBlock : BlockData, SampleInterface
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Name { get; set; }
         */
    }
}