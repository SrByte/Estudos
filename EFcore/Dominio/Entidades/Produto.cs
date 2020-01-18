namespace Dominio.Entidades
{
    public class Produto
    {
        public int ID{get;set;}
        public string Nome {get;set;}
        public virtual Categoria Categoria{get;set;}
        public int CategoriaID{get;set;}
        public bool Ativo{get;set;}
    }
}