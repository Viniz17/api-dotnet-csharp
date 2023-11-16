using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefas.Models;

[Table(name: "tarefas")]
public class ApiTarefas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {  get; set; } 

    [Required]
    [StringLength(100)]
    public string Title {  get; set; } 

    [Column(TypeName = "text")]
    public string Description {  get; set; } 

    public bool Done {  get; set; } 



}