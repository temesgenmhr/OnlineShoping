

using System.ComponentModel;

namespace OnlineShoping.Application.Enums
{
    public enum UploadType : byte
    {
        [Description(@"Images\Products")]
        Product,

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document,

        [Description(@"Documents\Proposals")]
        Proposal
    }
}
