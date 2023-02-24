namespace ControleFinanceiro.Api.Configuration
{
    public record ApplicationConfig
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string Secret { get; set; }
    }
    public record ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
