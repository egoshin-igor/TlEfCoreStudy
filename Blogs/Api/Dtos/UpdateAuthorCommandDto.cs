using System.Runtime.Serialization;

namespace Blogs.Api.Dtos
{
    [DataContract]
    public class UpdateAuthorCommandDto
    {
        [DataMember( Name = "name" )]
        public string Name { get; init; }
    }
}
