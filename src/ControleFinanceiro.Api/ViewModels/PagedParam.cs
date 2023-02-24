namespace ControleFinanceiro.Api.ViewModels
{
    public abstract class PagedParam
    {
        public PagedParam()
        {
            PageIndex = 1;
            PageSize = 10;
            OrderBy = null;
            Ascending = true;

        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }
    }
}
