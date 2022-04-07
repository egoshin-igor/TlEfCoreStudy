using System.Runtime.Serialization;

namespace Blogs.Api.Dtos
{
    [DataContract]
    public class AddAuthorCommandDto
    {
        [DataMember( Name = "name" )]
        public string Name { get; init; }
    }
}
