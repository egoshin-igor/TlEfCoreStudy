namespace Blogs.Application.Models
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Author( string name )
        {
            Name = name;
        }

        public void Update( string name )
        {
            Name = name;
        }
    }
}
