using System;
using System.Collections.Generic;
using EdiFabric.Core.Annotations.Edi;
using EdiFabric.Core.Annotations.Validation;
using EdiFabric.Core.Model.Edi;

namespace EdiFabric.Examples.FlatFile.Common
{
    [Serializable()]
    [Message("Flat", "Markers")]
    public class FlatMarkers : EdiMessage
    {
        [Required]
        [Pos(1)]
        public FlatHeader Header { get; set; }

        [Required]
        [Pos(2)]
        public List<FlatBody> Body { get; set; }

        [Required]
        [Pos(3)]
        public FlatTrailer Trailer { get; set; }
    }

    [Serializable()]
    [Segment("H", ',')]
    public class FlatHeader
    {
        [Required]
        [Pos(1)]
        public string Tag { get; set; }

        [Required]
        [Pos(2)]
        public string Date { get; set; }
    }

    [Serializable()]
    [Segment("T", ',')]
    public class FlatTrailer
    {
        [Required]
        [Pos(1)]
        public string Tag { get; set; }

        [Required]
        [Pos(2)]
        public string Date { get; set; }
    }

    [Serializable()]
    [Segment("", ',')]
    public class FlatBody
    {
        [Required]
        [Pos(1)]
        public string Tag { get; set; }

        [Required]
        [Pos(2)]
        public string Name { get; set; }

        [Required]
        [Pos(3)]
        public string Surname { get; set; }
        
        [Pos(4)]
        public string Extra { get; set; }
    }
}
