using System.Text.Json.Serialization;

namespace stone_21.Data;

public class Person
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Name")]
    public String? Name { get; set; }
    [JsonPropertyName("Surname")]
    public String? Surname { get; set; }
    [JsonPropertyName("Patronymic")]
    public String? Patronymic { get; set; }

    public Person(int Id)
    {
        this.Id = Id;
    }
}
