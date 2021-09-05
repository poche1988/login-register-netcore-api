namespace Models.Shared
{
    public class IdAndNameDto
    {
        public IdAndNameDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get;}

        public string Name { get;}
    }
}
