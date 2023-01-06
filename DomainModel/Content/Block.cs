using System;

namespace DomainModel.Content
{
    public class Block : BaseEntity
    {
        public string StringKey { get; set; }

        public bool IsStatic { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Img { get; set; }

        public int Pozition { get; set; }

        public bool IsHidden { get; set; }

        public bool IsContent { get; set; }

        public int? BlockListId { get; set; }
        public virtual BlockList BlockList { get; set; }
    }
}