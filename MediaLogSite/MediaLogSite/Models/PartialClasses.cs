using System;
using System.ComponentModel.DataAnnotations;

namespace MediaLogSite.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    [MetadataType(typeof(LogMetadata))]
    public partial class Log
    {
    }
}