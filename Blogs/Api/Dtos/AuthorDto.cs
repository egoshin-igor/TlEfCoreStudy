using System.Runtime.Serialization;

namespace Blogs.Api.Dtos
{
    [DataContract]
    public class AuthorDto
    {
        [DataMember( Name = "id" )]
        public int Id { get; init; }

        [DataMember( Name = "name" )]
        public string Name { get; init; }
    }
}
