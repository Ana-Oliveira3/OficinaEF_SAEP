using System.ComponentModel.DataAnnotations;

namespace OficinaEF.Models;

public class Cliente
{
    //Atributos
    public int Id{get;set;}
    [Required, StringLength(100)]
    public string Nome{get;set;}
    public string Cpf{get;set;}
    public string Telefone {get;set;}
}