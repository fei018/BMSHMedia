using System;
using System.ComponentModel.DataAnnotations;

namespace BMSHMedia.Model
{

    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}